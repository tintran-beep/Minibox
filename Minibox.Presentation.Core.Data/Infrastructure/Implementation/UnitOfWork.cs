using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.ValueGeneration;
using Microsoft.Extensions.Options;
using Minibox.Presentation.Core.Data.Context;
using Minibox.Presentation.Core.Data.Extension;
using Minibox.Presentation.Core.Data.Infrastructure.Interface;
using Minibox.Presentation.Share.Library.Common;
using Minibox.Presentation.Share.Model;
using System.Reflection;

namespace Minibox.Presentation.Core.Data.Infrastructure.Implementation
{
    public class UnitOfWork<TContext>(TContext dbContext, IOptions<AppSettings> appSettings) : IUnitOfWork<TContext> where TContext : BaseDbContext
    {
        private readonly TContext _dbContext = dbContext;
        private readonly AppSettings _appSettings = appSettings.Value;
        private readonly Dictionary<Type, object> _repositories = [];

        /// <summary>
        /// Return Repository of type TEntity
        /// </summary>
        /// <typeparam name="TEntity"></typeparam>
        /// <returns></returns>
        public IRepository<TContext, TEntity> GetRepo<TEntity>() where TEntity : BaseEntity
        {
            var entityType = typeof(TEntity);

            if (_repositories.ContainsKey(entityType) == false)
            {
                var repositoryInstance = new Repository<TContext, TEntity>(_dbContext);
                _repositories.Add(entityType, repositoryInstance);
            }
            return (Repository<TContext, TEntity>)_repositories[entityType];
        }

        /// <summary>
        /// EF Savechanges
        /// </summary>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public virtual async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            return await CommonHelper.RetryAsync(async () =>
            {
                var isSaveChange = _dbContext.ChangeTracker.Entries().Any(x => x.State == EntityState.Added
                                                                            || x.State == EntityState.Deleted
                                                                            || x.State == EntityState.Modified);
                if (isSaveChange)
                {
                    using var transaction = await _dbContext.Database.BeginTransactionAsync(cancellationToken);
                    try
                    {
                        var result = await _dbContext.SaveChangesAsync(cancellationToken);
                        await transaction.CommitAsync(cancellationToken);

                        _dbContext.DetachAllEntities();

                        return result;
                    }
                    catch (Exception)
                    {
                        await transaction.RollbackAsync(cancellationToken);
                        throw;
                    }
                }
                return 0;
            }, TimeSpan.FromSeconds(_appSettings.RetrySettings.RetryIntervalInSeconds), _appSettings.RetrySettings.RetryMaxAttemptCount);
        }

        /// <summary>
        /// Bulk action Savechanges
        /// </summary>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public virtual async Task<int> BulkSaveChangesAsync(CancellationToken cancellationToken = default)
        {
            return await CommonHelper.RetryAsync(async () =>
            {
                var rowEffects = 0;
                var isSaveChange = _dbContext.ChangeTracker.Entries().Any(x => x.State == EntityState.Added
                                                                            || x.State == EntityState.Deleted
                                                                            || x.State == EntityState.Modified);
                if (isSaveChange)
                {
                    if (_dbContext.Database.GetDbConnection() is SqlConnection connection)
                    {
                        if (connection.State != System.Data.ConnectionState.Open)
                            await connection.OpenAsync();

                        using var transaction = await connection.BeginTransactionAsync(cancellationToken) as SqlTransaction;
                        if (transaction != null)
                        {
                            try
                            {
                                var entities = _dbContext.GetEntities();
                                if (entities.Count != 0)
                                {
                                    foreach (var item in entities)
                                    {
                                        var insertedEntities = item.Value.insertedEntities;
                                        if (insertedEntities != null && insertedEntities.Count != 0)
                                        {
                                            rowEffects += await _dbContext.BulkInsertEntitiesAsync(insertedEntities, connection, transaction, _appSettings.DbContextSettings.CmdTimeOutInMiliseconds, _appSettings.DbContextSettings.BatchSize);
                                        }

                                        var updatedEntities = item.Value.updatedEntities;
                                        if (updatedEntities != null && updatedEntities.Count != 0)
                                        {
                                            rowEffects += await _dbContext.BulkUpdateEntitiesAsync(updatedEntities, connection, transaction, _appSettings.DbContextSettings.CmdTimeOutInMiliseconds, _appSettings.DbContextSettings.BatchSize);
                                        }

                                        var deletedEntities = item.Value.deletedEntities;
                                        if (deletedEntities != null && deletedEntities.Count != 0)
                                        {
                                            rowEffects += await _dbContext.BulkDeleteEntitiesAsync(deletedEntities, connection, transaction, _appSettings.DbContextSettings.CmdTimeOutInMiliseconds, _appSettings.DbContextSettings.BatchSize);
                                        }
                                    }
                                }

                                await transaction.CommitAsync(cancellationToken);

                                _dbContext.DetachAllEntities();
                            }
                            catch (Exception)
                            {
                                await transaction.RollbackAsync(cancellationToken);
                                throw;
                            }

                        }
                    }
                }
                return rowEffects;
            }, TimeSpan.FromSeconds(_appSettings.RetrySettings.RetryIntervalInSeconds), _appSettings.RetrySettings.RetryMaxAttemptCount);
        }

        /// <summary>
        /// Exec a StoredProcedure
        /// </summary>
        /// <typeparam name="TResult"></typeparam>
        /// <param name="storedProcedureName"></param>
        /// <param name="parameters"></param>
        /// <returns></returns>
        public virtual async Task<List<TResult>> ExecuteAsync<TResult>(string storedProcedureName, params SqlParameter[] parameters)
        {
            using var command = _dbContext.Database.GetDbConnection().CreateCommand();
            command.CommandText = storedProcedureName;
            command.CommandType = System.Data.CommandType.StoredProcedure;
            if (parameters.Length != 0)
            {
                command.Parameters.Clear();
                command.Parameters.AddRange(parameters);
            }
            await _dbContext.Database.OpenConnectionAsync();

            var result = new List<TResult>();
            using var commandResult = await command.ExecuteReaderAsync();

            while (await commandResult.ReadAsync())
            {
                var obj = Activator.CreateInstance<TResult>();
                var propertyInfos = obj?.GetType()?.GetProperties();
                if (propertyInfos != null)
                {
                    foreach (PropertyInfo prop in propertyInfos)
                    {
                        if (!Equals(commandResult[prop.Name], DBNull.Value))
                        {
                            prop.SetValue(obj, commandResult[prop.Name], null);
                        }
                    }
                    result.Add(obj);
                }
            }
            await _dbContext.Database.CloseConnectionAsync();
            return result;
        }

        #region Implement Dispose Object
        public virtual void Dispose()
        {
            Dispose(disposing: true);
            GC.SuppressFinalize(this);
        }

        public virtual async ValueTask DisposeAsync()
        {
            await DisposeAsyncCore().ConfigureAwait(false);
            Dispose(disposing: false);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (_dbContext is null)
                    return;
                _dbContext.Dispose();
            }
        }

        protected virtual async ValueTask DisposeAsyncCore()
        {
            if (_dbContext is not null)
            {
                await _dbContext.DisposeAsync().ConfigureAwait(false);
            }
        }
        #endregion
    }
}

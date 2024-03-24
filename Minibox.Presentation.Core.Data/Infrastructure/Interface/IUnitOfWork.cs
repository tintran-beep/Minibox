using Microsoft.Data.SqlClient;
using Minibox.Presentation.Core.Data.Context;

namespace Minibox.Presentation.Core.Data.Infrastructure.Interface
{
    public interface IUnitOfWork<TContext> : IDisposable, IAsyncDisposable
    {
        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
        Task<int> BulkSaveChangesAsync(CancellationToken cancellationToken = default);
        IRepository<TContext, TEntity> GetRepo<TEntity>() where TEntity : BaseEntity;
        Task<List<TResult>> ExecuteAsync<TResult>(string storedProcedureName, params SqlParameter[] parameters);
    }
}

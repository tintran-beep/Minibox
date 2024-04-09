using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Minibox.Presentation.Core.Data.Context;

namespace Minibox.Presentation.Core.Data.Infrastructure.Interface
{
    public interface IUnitOfWork<TContext> : IDisposable, IAsyncDisposable
    {
        Task<Guid> NewSequentialGuidValueAsync(EntityEntry entityEntry);
        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
        Task<int> BulkSaveChangesAsync(CancellationToken cancellationToken = default);
        IRepository<TContext, TEntity> GetRepo<TEntity>() where TEntity : BaseEntity;
        Task<List<TResult>> ExecuteAsync<TResult>(string storedProcedureName, params SqlParameter[] parameters);
    }
}

using System;
using System.Threading;
using System.Threading.Tasks;

namespace Crea.SporHojam.Domain.Common
{
    public interface IUnitOfWork : IDisposable
    {
        Task BeginTransaction();

        Task Commit();

        void RollbackTransaction();

        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
    }
}
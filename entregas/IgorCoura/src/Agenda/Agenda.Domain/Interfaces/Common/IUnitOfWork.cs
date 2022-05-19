using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace Agenda.Domain.Interfaces
{
    public interface IUnitOfWork
    {
        Task<bool> CommitAsync(CancellationToken cancellationToken = default(CancellationToken));
        Task DisponseAsync();
        void ClearTracker();
    }
}

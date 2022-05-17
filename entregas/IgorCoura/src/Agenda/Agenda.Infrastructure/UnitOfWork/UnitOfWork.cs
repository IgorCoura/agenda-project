using Agenda.Domain.Interfaces;
using Agenda.Infrastructure.Context;

namespace Agenda.Infrastructure.UnitOfWork
{
    public class UnitOfWork: IUnitOfWork
    {
        public ApplicationContext _context { get; set; }

        public UnitOfWork(ApplicationContext context)
        {
            _context = context;
        }

        public async Task<bool> CommitAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            var result =  await _context.SaveChangesAsync(cancellationToken);
            _context.ChangeTracker.Clear();
            return result > 0;
        }

        public async Task DisponseAsync()
        {
            await _context.DisposeAsync();
        }
    }
}

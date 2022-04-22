namespace Agenda.Domain.Interfaces
{
    public interface IUnitOfWork
    {
        Task SaveChangesAsync();
    }
}

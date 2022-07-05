using Agenda.MVC.Params;
using Agenda.MVC.ViewModel;

namespace Agenda.MVC.Interfaces
{
    public interface IContactService
    {
        Task<IEnumerable<ContactViewModel>> GetAll(ContactParams contactParams);
    }
}

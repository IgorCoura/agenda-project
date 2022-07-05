using Agenda.MVC.ViewModel;

namespace Agenda.MVC.Interfaces
{
    public interface IUserService
    {
        Task<bool> Register(CreateUserViewModel viewModel);
    }
}

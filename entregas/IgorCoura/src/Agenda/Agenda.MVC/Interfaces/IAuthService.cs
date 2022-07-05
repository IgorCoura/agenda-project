using Agenda.MVC.ViewModel;

namespace Agenda.MVC.Interfaces
{
    public interface IAuthService
    {
        Task<string> Login(LoginViewModel viewModel);
    }
}

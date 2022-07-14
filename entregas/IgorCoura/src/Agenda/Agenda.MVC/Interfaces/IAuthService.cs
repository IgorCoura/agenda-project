using Agenda.MVC.ViewModel.User;

namespace Agenda.MVC.Interfaces
{
    public interface IAuthService
    {
        Task<string> Login(LoginViewModel viewModel);
    }
}

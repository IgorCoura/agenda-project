using Agenda.MVC.Params;
using Agenda.MVC.ViewModel.Base;
using Agenda.MVC.ViewModel.User;

namespace Agenda.MVC.Interfaces
{
    public interface IUserService
    {
        Task<bool> Register(CreateUserViewModel viewModel);
        Task<bool> Edit(EditUserViewModel model);
        Task<bool> EditPassword(EditPasswordViewModel model);
        Task<UserViewModel> GetUser();
        Task RemoverUser();
        Task<bool> RegisterAdmin(CreateUserViewModel viewModel);
        Task<bool> EditAdmin(EditUserViewModel model);
        Task<UserViewModel> GetByIdAdmin(int id);
        Task<BasePageResponseViewModel<IEnumerable<UserViewModel>>> GetAllAdmin(UserParams param);
        Task<IEnumerable<InteractionViewModel>> GetAllInteractions();
        Task RemoverByIdAdmin(int id);
    }
}

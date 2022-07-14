using System.ComponentModel.DataAnnotations;

namespace Agenda.MVC.ViewModel.User
{
    public class LoginViewModel
    {
        [Required]
        public string Username { get; set; }
        [Required]
        public string Password { get; set; }
    }
}

using System.ComponentModel.DataAnnotations;

namespace Agenda.MVC.ViewModel
{
    public class LoginViewModel
    {
        [Required]
        public string Username { get; set; }
        [Required]
        public string Password { get; set; }
    }
}

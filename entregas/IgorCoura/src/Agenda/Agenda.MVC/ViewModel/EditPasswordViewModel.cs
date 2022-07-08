using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Agenda.MVC.ViewModel
{
    public class EditPasswordViewModel
    {
        [Required]
        [RegularExpression(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[@$_!%*?&-])[A-Za-z\d@$!_%*?&-]{8,}$", ErrorMessage = "Senha deve conter o mínimo de oito caracteres, pelo menos uma letra maiúscula, uma letra minúscula, um número e um caractere especial.")]
        [DisplayName("Senha")]
        public string Password { get; set; } = string.Empty;
        [Compare("Password")]
        [Required]
        [DisplayName("Confirmar Senha")]
        public string ConfirmPassword { get; set; } = string.Empty;
    }
}

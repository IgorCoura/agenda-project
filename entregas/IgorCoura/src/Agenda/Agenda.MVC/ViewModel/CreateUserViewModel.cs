using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Agenda.MVC.ViewModel
{
    public class CreateUserViewModel
    {
        [Required]
        [StringLength(200, MinimumLength = 3, ErrorMessage = "O nome teve ter um tamanho entre 3 e 200 caracteres.")]
        [DisplayName("Nome")]
        public string Name { get; set; } = string.Empty;
        [Required]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "O nome teve ter um tamanho entre 3 e 50 caracteres.")]
        [DisplayName("Username")]
        public string UserName { get; set; } = string.Empty;
        [Required]
        [EmailAddress]
        [DisplayName("E-Mail")]
        public string Email { get; set; } = string.Empty;
        [Required]
        [DisplayName("Cargo")]
        public int UserRoleId { get; set; }
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

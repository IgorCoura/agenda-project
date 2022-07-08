using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Agenda.MVC.ViewModel
{
    public class EditUserViewModel
    {
        [Key]
        public int Id { get; set; }
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
    }
}

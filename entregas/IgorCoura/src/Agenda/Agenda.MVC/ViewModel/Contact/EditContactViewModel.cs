using System.ComponentModel.DataAnnotations;

namespace Agenda.MVC.ViewModel.Contact
{
    public class EditContactViewModel
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [StringLength(200, MinimumLength = 3 ,ErrorMessage = "O nome deve ter entre 3 e 200 caracteres.")]
        public string Name { get; set; } = string.Empty;
        public List<EditPhoneViewModel> Phones { get; set; } = new List<EditPhoneViewModel>();
    }
}

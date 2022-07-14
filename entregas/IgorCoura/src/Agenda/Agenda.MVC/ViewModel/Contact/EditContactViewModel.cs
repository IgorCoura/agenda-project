using System.ComponentModel.DataAnnotations;

namespace Agenda.MVC.ViewModel.Contact
{
    public class EditContactViewModel
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [StringLength(200, ErrorMessage = "O nome não pode ter mais que 200 caracteres.")]
        public string Name { get; set; } = string.Empty;
        public List<EditPhoneViewModel> Phones { get; set; } = new List<EditPhoneViewModel>();
    }
}

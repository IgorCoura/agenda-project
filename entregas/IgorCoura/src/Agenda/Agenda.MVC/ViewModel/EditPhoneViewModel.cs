using System.ComponentModel.DataAnnotations;

namespace Agenda.MVC.ViewModel
{
    public class EditPhoneViewModel
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [StringLength(200, MinimumLength = 2, ErrorMessage = "Messagem teve ter entre 2 a 200 caracteres.")]
        public string Description { get; set; } = string.Empty;
        [Required]
        public string FormattedPhone { get; set; } = string.Empty;
        [Required]
        public int PhoneTypeId { get; set; }
        public string? PhoneType { get; set; } = string.Empty;
    }
}

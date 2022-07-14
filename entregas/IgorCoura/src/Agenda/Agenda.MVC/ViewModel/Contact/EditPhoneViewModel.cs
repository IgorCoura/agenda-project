using System.ComponentModel.DataAnnotations;


namespace Agenda.MVC.ViewModel.Contact
{
    public class EditPhoneViewModel
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [StringLength(200, MinimumLength = 2, ErrorMessage = "Messagem teve ter entre 2 a 200 caracteres.")]
        public string Description { get; set; } = string.Empty;
        [Required]
        [RegularExpression(@"^\(?[1-9][0-9]\)? ?(9?[0-9])[0-9]{3}\-?[0-9]{4}$", ErrorMessage = "Formato de telefone inválido. (xx) 9xxxx-xxxx para celular e (xx) xxxx-xxxx para residencial")]
        public string FormattedPhone { get; set; } = string.Empty;
        [Required]
        public int PhoneTypeId { get; set; }
        public string? PhoneType { get; set; } = string.Empty;


    }
}

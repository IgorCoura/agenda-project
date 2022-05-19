using System.ComponentModel.DataAnnotations;

namespace Agenda.ConsoleUI.Utils
{
    public record NameRecord
    {
        [Required(ErrorMessage = "Insira um nome.")]
        [MaxLength(200, ErrorMessage = "Insira um nome com no máximo 200.")]
        public string Name { get; set; } = string.Empty;
    }

    public record PhoneRecord
    {
        [Required(ErrorMessage = "Insira um telefone")]
        [RegularExpression(@"^\(?[1-9]{2}\)? ?(?:[1-9]|9[1-9])[0-9]{3}\-?[0-9]{4}$", ErrorMessage = "Informe um telefone em um formato valido ((xx) x?xxxx-xxxx).")]
        public string Phone { get; set; } = string.Empty;
    }


    public record DescriptionRecord()
    {
        [Required(ErrorMessage = "Insira um descrição.")]
        public string Description { get; set; } = string.Empty;
    }

    public record DDDRecord
    {
        [Required(ErrorMessage = "Insira um DDD.")]
        [RegularExpression(@"[1-9]{2}", ErrorMessage = "Informe um DDD em um formato valido (xx).")]
        public string DDD { get; set; } = string.Empty;
    }

    public record NumberRecord 
    {
        [Required(ErrorMessage = "Insira um numero.")]
        [RegularExpression(@"(?:[1-9]|9[1-9])[0-9]{7}$", ErrorMessage = "Informe um numero em um formato valido (x?xxxxxxxx).")]
        public string Number { get; set; } = string.Empty;
    }
}

using System.ComponentModel.DataAnnotations;

namespace Agenda.Application.Model
{
    public record CreateContactModel
    {
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [StringLength(100, ErrorMessage = "O cmapo {0} precisa ter entre {2} e {1} caracteres", MinimumLength = 2)]
        public string Name { get; set; } = string.Empty;
        public IEnumerable<CreatePhoneModel> Phones { get; set; }

    }
}

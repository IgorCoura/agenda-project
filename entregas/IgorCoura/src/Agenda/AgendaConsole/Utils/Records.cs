using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgendaConsole.Utils
{
    public record NameRecord
    {
        [Required(ErrorMessage = "Insira um nome.")]
        public string Name { get; set; }
    }

    public record PhoneRecord
    {
        [Required(ErrorMessage = "Insira um telefone")]
        [RegularExpression(@"^\(?[1-9]{2}\)? ?(?:[2-8]|9[1-9])[0-9]{3}\-?[0-9]{4}$", ErrorMessage = "Informe um telefone valido.")]
        public string Phone { get; set; }
    }

    
    public record DescriptionRecord()
    {
        [Required(ErrorMessage = "Insira um descrição.")]
        public string Description { get; set; }
    }
}

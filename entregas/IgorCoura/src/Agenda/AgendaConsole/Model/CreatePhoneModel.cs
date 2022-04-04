using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgendaConsole.Model
{
    public class CreatePhoneModel
    {
        [Required(ErrorMessage ="Insira um telefone")]
        [RegularExpression(@"^\(?[1-9]{2}\)? ?(?:[2-8]|9[1-9])[0-9]{3}\-?[0-9]{4}$", ErrorMessage = "Informe um telefone valido.")]
        public string FormattedPhone { get; set; }
        [Required(ErrorMessage ="Insira um descrição.")]
        public string Description { get; set; }

    }
}

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
        public string FormattedPhone { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;

    }
}
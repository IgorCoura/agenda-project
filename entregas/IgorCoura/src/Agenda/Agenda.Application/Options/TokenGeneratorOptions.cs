using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agenda.Application.Options
{
    public class TokenGeneratorOptions
    {
        public string SecurityKey { get; set; }
        public int ExpirationMinutes { get; set; }
    }
}

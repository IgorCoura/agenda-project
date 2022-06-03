using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agenda.Application.Model
{
    public abstract record BaseContactModel<T> where T : BasePhoneModel
    {
        public string Name { get; set; } = string.Empty;
        public IEnumerable<T> Phones { get; set; }

    }
}

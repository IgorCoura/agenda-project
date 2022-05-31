using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Agenda.Application.Model;
using Agenda.Domain.Interfaces;

namespace Agenda.Application.Utils
{
    public class PhoneNumberUtils
    {
        public static bool IsValid(string number)
        {
            return new Regex(@"^\(?[1-9]{2}\)? ?(?:[2-8]|9[1-9])[0-9]{3}\-?[0-9]{4}$").IsMatch(number);
        }
        

        
    }
}

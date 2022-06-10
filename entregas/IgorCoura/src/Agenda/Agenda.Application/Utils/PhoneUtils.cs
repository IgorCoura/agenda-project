using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Agenda.Application.Exceptions;
using Agenda.Domain.Entities;

namespace Agenda.Application.Utils
{
    public class PhoneUtils
    {
        public static Phone? splitFormattedPhone(string formattedPhone)
        {
            try
            {
                int ddd;
                int number;
                var stringPhone = Regex.Replace(formattedPhone, "[ ()-]+", "", RegexOptions.Compiled);
                if (int.TryParse(stringPhone.Substring(0, 2), out ddd)
                && int.TryParse(stringPhone.Substring(2), out number))
                {
                    return new Phone { DDD = ddd, Number = number };
                }
                return null;
            }
            catch
            {
                return null;
            }

        }
    }
}

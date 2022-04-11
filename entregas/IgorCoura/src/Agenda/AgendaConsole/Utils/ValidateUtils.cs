using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AgendaConsole.Entities;

namespace AgendaConsole.Utils
{
    public static class ValidateUtils
    {
        public static ICollection<ValidationResult> ValidateModel(object obj)
        {
            ICollection<ValidationResult> validate = new List<ValidationResult>();
            ValidationContext context = new ValidationContext(obj);
            Validator.TryValidateObject(obj, context, validate, true);
            return validate;
            
        }
    }
}


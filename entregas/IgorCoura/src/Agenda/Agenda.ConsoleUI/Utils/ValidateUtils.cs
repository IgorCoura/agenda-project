using System.ComponentModel.DataAnnotations;

namespace Agenda.ConsoleUI.Utils
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


using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AgendaConsole.Model;
using AgendaConsole.Utils;

namespace AgendaConsole.Views
{
    public static class UtilsViews
    {
        public static string GetName()
        {
            while (true)
            {
                Console.WriteLine("Nome:");
                var name = Console.ReadLine()??"";
                var nameRecord = new NameRecord { Name = name};
                if (ValidateModel(nameRecord))
                    return nameRecord.Name;
            }

        }


        public static string GetPhone()
        {
            while (true)
            {
                Console.WriteLine("Phone: ");
                var phone = Console.ReadLine() ?? "";
                var phoneRecord = new PhoneRecord { Phone = phone };
                if (ValidateModel(phoneRecord))
                    return phoneRecord.Phone;
            }
        }

        public static string GetDescription()
        {
            while (true)
            {
                Console.WriteLine("Decription: ");
                var description = Console.ReadLine() ?? "";
                var decriptionRecord = new DescriptionRecord { Description = description };
                if (ValidateModel(decriptionRecord))
                    return decriptionRecord.Description;
            }
        }

        private static bool ValidateModel(object obj)
        {
            ICollection<ValidationResult> validate = new List<ValidationResult>();
            ValidationContext context = new ValidationContext(obj);
            if (!Validator.TryValidateObject(obj, context, validate, true))
            {
                Console.Clear();
                foreach (var a in validate)
                {
                    Console.WriteLine(a.ErrorMessage);
                }
                Console.WriteLine();
                return false;
            }
            else
            {
                return true;
            }

        }

        
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AgendaConsole.Model;
using AgendaConsole.Utils;

namespace AgendaConsole.Utils
{
    public static class ViewsUtils
    {
        public static string GetName()
        {
            while (true)
            {
                Console.WriteLine("Nome:");
                var name = Console.ReadLine()??"";
                var nameRecord = new NameRecord { Name = name};
                var result = ValidateUtils.ValidateModel(nameRecord);
                if (result.Any())
                    ShowErros(result);
                else
                    return nameRecord.Name;
                    
            }

        }


        public static string GetPhone(string defaultValue = "")
        {
            while (true)
            {
                Console.WriteLine("Phone: ");
                var phone = Console.ReadLine();
                phone = string.IsNullOrEmpty(phone) ? defaultValue : phone;
                var phoneRecord = new PhoneRecord { Phone = phone };
                var result = ValidateUtils.ValidateModel(phoneRecord);
                if (result.Any())
                    ShowErros(result);
                else
                    return phoneRecord.Phone;

            }
        }

        public static string GetDescription(string defaultValue = "")
        {
            while (true)
            {
                Console.WriteLine("Decription: ");
                var description = Console.ReadLine();
                description = string.IsNullOrEmpty(description) ? defaultValue : description;
                var descriptionRecord = new DescriptionRecord { Description = description };
                var result = ValidateUtils.ValidateModel(descriptionRecord);
                if (result.Any())
                    ShowErros(result);
                else
                    return descriptionRecord.Description;
            }
        }

        public static int GetId()
        {
            while (true)
            {
                Console.WriteLine("Informe o Id: ");
                var stringId = Console.ReadLine() ?? "";
                if(int.TryParse(stringId, out int id))
                {
                    Console.Clear();
                    return id;
                }
                Console.Clear();
                Console.WriteLine("Informe um id valido.");
            }
        }

        public static int GetDDD()
        {
            while (true)
            {
                Console.WriteLine("Informe o DDD:");
                var ddd = Console.ReadLine() ?? "";
                var dddRecord = new DDDRecord { DDD = ddd };
                var result = ValidateUtils.ValidateModel(dddRecord);
                if (result.Any())
                {
                    Console.Clear();
                    ShowErros(result);
                }   
                else
                {
                    if (int.TryParse(dddRecord.DDD, out int num))
                    {
                        Console.Clear();
                        return num;
                    }
                    Console.Clear();
                    Console.WriteLine("Informe um DDD valido.");

                }
                
            }
        }

        public static int GetNumber()
        {
            while (true)
            {
                Console.WriteLine("Informe o number:");
                var number = Console.ReadLine() ?? "";
                var numberRecord = new NumberRecord { Number = number};
                var result = ValidateUtils.ValidateModel(numberRecord);
                if (result.Any())
                {
                    Console.Clear();
                    ShowErros(result);
                }
                else
                {
                    if (int.TryParse(numberRecord.Number, out int num))
                    {
                        Console.Clear();
                        return num;
                    }
                    Console.Clear();
                    Console.WriteLine("Informe um numero valido.");

                }
            }
        }

        public static void ShowContact(ContactModel model)
        {
            Console.WriteLine($"Id: {model.Id}");
            Console.WriteLine($"Name: {model.Name}");
            foreach (var phone in model.Phones)
            {
                ShowPhone(phone);
            }
            Console.WriteLine();
        }

        public static void ShowPhone(PhoneModel phone)
        {
            Console.WriteLine($"    Id: {phone.Id}");
            Console.WriteLine($"    Phone: {phone.FormattedPhone}");
            Console.WriteLine($"    Description: {phone.Description}");
        }

        private static void ShowErros(ICollection<ValidationResult> erros)
        {
            foreach (var erro in erros)
            {
                Console.Clear();
                Console.WriteLine(erro.ErrorMessage);
            }
        }

        
    }
}

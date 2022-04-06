using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AgendaConsole.Interfaces;
using AgendaConsole.Model;

namespace AgendaConsole.Utils
{
    public class CreateContactView: IView
    {
        private readonly IContactService _contactService;

        public CreateContactView(IContactService contactService)
        {
            _contactService = contactService;
        }

        public void Run()
        {
            Console.WriteLine("\n NOVO CONTATO \n");
            var contact = CreateContact();
            _contactService.Register(contact);
        }
        private CreateContactModel CreateContact()
        {
            var name = ViewsUtils.GetName();
            var model = new CreateContactModel { Name = name };
            model.Phones = new List<CreatePhoneModel>();
            while (true)
            {
                var phone = new CreatePhoneModel{
                    FormattedPhone = ViewsUtils.GetPhone(),
                    Description = ViewsUtils.GetDescription()
                };
                model.Phones.Add(phone);
                Console.WriteLine("Deseja inserir mais um numero (S/N): ");
                if (Console.ReadLine() == "N")
                    break;
            }

            return model;

        }

    }
}

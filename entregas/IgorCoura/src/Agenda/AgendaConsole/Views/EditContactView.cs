using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AgendaConsole.Interfaces;
using AgendaConsole.Model;

namespace AgendaConsole.Views
{
    public class EditContactView
    {
        private readonly IContactService _contactService;

        public EditContactView(IContactService contactService)
        {
            _contactService = contactService;
        }

        public void Run()
        {
            var model = ConvertToUpdateContact(getContact());
            var option = "";
            while (option != "0")
            {
                option = Options(model);

                switch (option)
                {
                    case "0": break;
                    case "1": model = EditName(model); break;
                    case "2": model = AddNewPhone(model); break;
                    case "3": model = EditPhone(model); break;                      
                        
                }
            }
            

        }

        public ContactModel getContact()
        {
            while (true)
            {
                int id;

                Console.WriteLine("Informe o ID do contato de deseja editar: ");

                if (!int.TryParse(Console.ReadLine(), out id))
                {
                    Console.Clear();
                    Console.WriteLine("Inseira um id valido.");
                    continue;
                    
                }

                try
                {
                    return _contactService.RecoverById(id);
                }
                catch (Exception ex)
                {
                    Console.Clear();
                    Console.WriteLine(ex.Message);
                    continue;
                }
            }
            
        }

        public void ShowContact(UpdateContactModel model)
        {
            Console.WriteLine($"Id: {model.Id}");
            Console.WriteLine($"Name: {model.Name}");
            foreach(var phone in model.Phones)
            {
                Console.WriteLine($"    Id: {phone.Id}");
                Console.WriteLine($"    Phone: {phone.FormattedPhone}");
                Console.WriteLine($"    Description: {phone.Description}");
            }
            Console.WriteLine();
        }


        public string Options(UpdateContactModel model)
        {
            ShowContact(model);
            Console.WriteLine($"1-Name.");
            Console.WriteLine("2-Adicionar um novo telefone.");
            Console.WriteLine("3-Editar Telefones");
            Console.WriteLine("4-Remover Telefone");
            Console.WriteLine("0-Voltar.");
            var result = Console.ReadLine()??"";
            Console.Clear();
            return result;
        }

        public UpdateContactModel EditName(UpdateContactModel model)
        {
            var name = UtilsViews.GetName();
            model.Name = name;
            return model;
        }

        public UpdateContactModel AddNewPhone(UpdateContactModel model)
        {
            var phone = new UpdatePhoneModel
            {
                Id = 0,
                ContactId = model.Id,
                FormattedPhone = UtilsViews.GetPhone(),
                Description = UtilsViews.GetDescription()
            };
            model.Phones.Add(phone);
            return model;
        }

        public UpdateContactModel EditPhone(UpdateContactModel model) {
            //TODO: Arruma essa função
            foreach (var phone in model.Phones)
            {
                Console.WriteLine($"    Id: {phone.Id}");
                Console.WriteLine($"    Phone: {phone.FormattedPhone}");
                Console.WriteLine($"    Description: {phone.Description}");
            }
            Console.WriteLine("Digite o id do qual deseja editar: ");
            var id = int.Parse(Console.ReadLine()?? "0");
            var phoneModel = model.Phones.Where(x => x.Id == id).FirstOrDefault();
            phoneModel.FormattedPhone = UtilsViews.GetPhone();
            phoneModel.Description = UtilsViews.GetDescription();
            return model;
        }



        private UpdateContactModel ConvertToUpdateContact(ContactModel model)
        {
            return new UpdateContactModel
            {
                Id = model.Id,
                Name = model.Name,
                Phones = model.Phones.Select(p => new UpdatePhoneModel
                {
                    Id = p.Id,
                    ContactId = p.ContactId,
                    FormattedPhone = p.FormattedPhone,
                    Description = p.Description,
                }).ToList(),
            };
        }

    }
}

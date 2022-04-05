using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AgendaConsole.Interfaces;
using AgendaConsole.Mapper;
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
            var model = GetContact();
            if (model == null)
                return;
            var option = "";
            while (option != "0" && option != "5")
            {
                option = Options(model);

                switch (option)
                {
                    case "0": break;
                    case "1": EditName(model); break;
                    case "2": AddNewPhone(model); break;
                    case "3": EditPhone(model); break;                      
                    case "4": RemovePhone(model); break;                      
                    case "5": SaveChanges(model); break;                      
                }
            }
            

        }

        private UpdateContactModel? GetContact()
        {
            while (true)
            {
                int id;
                Console.WriteLine("\n EDITAR CONTATO.\n");
                Console.WriteLine("0 - Volta.");
                Console.WriteLine("Informe o ID do contato de deseja editar: ");

                if (!int.TryParse(Console.ReadLine(), out id))
                {
                    Console.Clear();
                    Console.WriteLine("Inseira um id valido.");
                    continue;
                    
                }

                if (id == 0)
                    return null;

                try
                {
                    var contactModel = _contactService.RecoverById(id);
                    Console.Clear();
                    return contactModel.ToUpdateModel();
                }
                catch (Exception ex)
                {
                    Console.Clear();
                    Console.WriteLine(ex.Message);
                    continue;
                }
            }
            
        }

        private void ShowContact(UpdateContactModel model)
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


        private string Options(UpdateContactModel model)
        {
            Console.WriteLine("\n EDITAR CONTATO.\n");
            ShowContact(model);
            Console.WriteLine($"1-Name.");
            Console.WriteLine("2-Adicionar um novo telefone.");
            Console.WriteLine("3-Editar Telefones");
            Console.WriteLine("4-Remover Telefone");
            Console.WriteLine("5-Salvar e voltar");
            Console.WriteLine("0-Voltar sem salvar.");
            var result = Console.ReadLine()??"";
            Console.Clear();
            return result;
        }

        private void EditName(UpdateContactModel model)
        {
            Console.WriteLine("\nEDITAR NOME\n");
            var name = UtilsViews.GetName();
            model.Name = name;
            Console.Clear();
        }

        private void AddNewPhone(UpdateContactModel model)
        {
            Console.WriteLine("\nADICIONAR NOVO TELEFONE\n");
            var phone = new UpdatePhoneModel
            {
                Id = 0,
                ContactId = model.Id,
                FormattedPhone = UtilsViews.GetPhone(),
                Description = UtilsViews.GetDescription()
            };
            model.Phones.Add(phone);
            Console.Clear();
        }

        private void EditPhone(UpdateContactModel model) {
            Console.WriteLine("\nEDITAR TELEFONE\n");
            var phoneModel = GetPhone(model.Phones);
                if(phoneModel != null)
                {
                    phoneModel.FormattedPhone = UtilsViews.GetPhone();
                    phoneModel.Description = UtilsViews.GetDescription();
                    return;
                }
            Console.Clear();
        }

        private void RemovePhone(UpdateContactModel model)
        {
            Console.WriteLine("\nREMOVER TELEFONE\n");
            var phoneModel = GetPhone(model.Phones);
            if( phoneModel != null)
            {
                model.Phones.Remove(phoneModel);
            }
            Console.Clear();
        }


        private UpdatePhoneModel? GetPhone(List<UpdatePhoneModel> phoneList) {
            foreach (var phone in phoneList)
            {
                Console.WriteLine($"    Id: {phone.Id}");
                Console.WriteLine($"    Phone: {phone.FormattedPhone}");
                Console.WriteLine($"    Description: {phone.Description}");
            }
            Console.WriteLine("\n0-Voltar");
            while (true)
            {
                int id;
                Console.WriteLine("Digite o id do telefone: ");
                if (!int.TryParse(Console.ReadLine() ?? "", out id))
                {
                    Console.Clear();
                    Console.WriteLine("Insira um id valido.");
                    continue;
                }

                if (id == 0) return null;

                var phoneModel = phoneList.Where(x => x.Id == id).FirstOrDefault();

                if (phoneModel != null)
                {
                    return phoneModel;
                }
                Console.WriteLine($"Telefone com o id {id}, não existe.");
            }

        }

        private void SaveChanges(UpdateContactModel model)
        {
            _contactService.EditAsync(model);
        }

    }
}

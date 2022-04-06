using AgendaConsole.Interfaces;
using AgendaConsole.Mapper;
using AgendaConsole.Model;

namespace AgendaConsole.Utils
{
    public class EditContactView : IView
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
            while (true)
            {
                var option = Options(model);

                switch (option)
                {
                    case "0": return;
                    case "1": EditName(model); break;
                    case "2": AddNewPhone(model); break;
                    case "3": EditPhone(model); break;                      
                    case "4": RemovePhone(model); break;                               
                }
                model = _contactService.Edit(model).ToUpdateModel();
            }
            

        }

        private string Options(UpdateContactModel model)
        {
            Console.WriteLine("\nEDITAR CONTATO.\n");
            ViewsUtils.ShowContact(model.ToModel());
            Console.WriteLine($"1-Name.");
            Console.WriteLine("2-Adicionar um novo telefone.");
            Console.WriteLine("3-Editar Telefones");
            Console.WriteLine("4-Remover Telefone");
            Console.WriteLine("0-Voltar.");
            var result = Console.ReadLine() ?? "";
            Console.Clear();
            return result;
        }

        
        

        private void EditName(UpdateContactModel model)
        {
            Console.WriteLine("\nEDITAR NOME\n");
            var name = ViewsUtils.GetName();
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
                FormattedPhone = ViewsUtils.GetPhone(),
                Description = ViewsUtils.GetDescription()
            };
            model.Phones.Add(phone);
            Console.Clear();
        }

        private void EditPhone(UpdateContactModel model) {
            Console.WriteLine("\nEDITAR TELEFONE");
            Console.WriteLine("Caso não queira editar um campo basta deixa-lo embranco\n");
            var phoneModel = GetPhone(model.Phones);
            if (phoneModel != null)
            {
                phoneModel.FormattedPhone = ViewsUtils.GetPhone(phoneModel.FormattedPhone);
                phoneModel.Description = ViewsUtils.GetDescription(phoneModel.Description);
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
        private UpdatePhoneModel? GetPhone(List<UpdatePhoneModel> phoneList)
        {
            foreach (var phone in phoneList)
            {
                ViewsUtils.ShowPhone(phone.ToModel());
            }
            Console.WriteLine("\n0-Voltar");
            while (true)
            {
                var id = ViewsUtils.GetId();

                if (id == 0)
                    return null;

                var phoneModel = phoneList.Where(x => x.Id == id).FirstOrDefault();

                if (phoneModel != null)
                {
                    return phoneModel;
                }
                Console.WriteLine($"Telefone com o id {id}, não existe.");
            }

        }
        private UpdateContactModel? GetContact()
        {
            while (true)
            {
                Console.WriteLine("\n EDITAR CONTATO.\n");
                Console.WriteLine("0 - Volta.");
                var id = ViewsUtils.GetId();

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

        

    }
}

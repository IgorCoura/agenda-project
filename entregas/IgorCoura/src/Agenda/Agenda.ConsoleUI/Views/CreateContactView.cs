using Agenda.ConsoleUI.Utils;
using Agenda.ConsoleUI.Interfaces;
using Agenda.Application.Interfaces;
using Agenda.Application.Model;

namespace Agenda.ConsoleUI.Views
{
    public class CreateContactView: IView
    {
        private readonly IContactService _contactService;

        public CreateContactView(IContactService contactService)
        {
            _contactService = contactService;
        }

        public async void Run()
        {
            Console.WriteLine("\n NOVO CONTATO \n");
            var contact = CreateContact();
            await _contactService.Register(contact);
        }
        private CreateContactModel CreateContact()
        {
            var name = ViewsUtils.GetName();
            var model = new CreateContactModel { Name = name };
            var phones = new List<CreatePhoneModel>();
            while (true)
            {
                var phone = new CreatePhoneModel{
                    FormattedPhone = ViewsUtils.GetPhone(),
                    Description = ViewsUtils.GetDescription(),
                    PhoneTypeId = ViewsUtils.GetPhoneType(),
                };
                phones.Add(phone);
                if (!ViewsUtils.ReadYesOrNo("Deseja inserir mais um numero (S/N): "))
                    break;
            }
            model.Phones = phones;
            return model;

        }

    }
}

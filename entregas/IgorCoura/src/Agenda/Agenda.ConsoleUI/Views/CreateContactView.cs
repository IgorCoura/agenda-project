using Agenda.ConsoleUI.Utils;
using Agenda.Domain.Interfaces;
using Agenda.Domain.Model;

namespace Agenda.ConsoleUI.Views
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
            var phones = new List<CreatePhoneModel>();
            while (true)
            {
                var phone = new CreatePhoneModel{
                    FormattedPhone = ViewsUtils.GetPhone(),
                    Description = ViewsUtils.GetDescription(),
                    PhoneType = ViewsUtils.GetPhoneType(),
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

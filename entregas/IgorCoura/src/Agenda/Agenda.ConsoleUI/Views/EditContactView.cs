using Agenda.ConsoleUI.Utils;
using Agenda.ConsoleUI.Interfaces;
using Agenda.Application.Interfaces;
using Agenda.Application.Model;
using AutoMapper;

namespace Agenda.ConsoleUI.Views
{
    public class EditContactView : IView
    {
        private readonly IContactService _contactService;
        private readonly Dictionary<string, Action<UpdateContactModel>> _optionsDictionary;
        private readonly IMapper _mapper;

        public EditContactView(IContactService contactService, IMapper mapper)
        {
            _optionsDictionary = new Dictionary<string, Action<UpdateContactModel>>()
            {
                {"1", EditName},
                {"2", AddNewPhone},
                {"3", EditPhone},
                {"4", RemovePhone},
            };
            _contactService = contactService;
            _mapper = mapper;
        }

        public void Run()
        {
            var model = GetContact();
            if (model == null)
                return;

            while (true)
            {
                var option = Options(model);
                if (option == "0")
                    return;

                _optionsDictionary[option].Invoke(model);

                var result = _contactService.Edit(model);
                model = _mapper.Map<UpdateContactModel>(result);
            }
            

        }

        private string Options(UpdateContactModel model)
        {
            Console.WriteLine("\nEDITAR CONTATO.\n");
            ViewsUtils.ShowContact(_mapper.Map<ContactModel>(model));
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
                Description = ViewsUtils.GetDescription(),
                PhoneType = ViewsUtils.GetPhoneType(),
            };
            var phones = model.Phones.ToList();
            phones.Add(phone);
            model.Phones = phones;
            Console.Clear();
        }

        private void EditPhone(UpdateContactModel model) {
            Console.WriteLine("\nEDITAR TELEFONE");
            Console.WriteLine("Caso não queira editar um campo basta deixa-lo embranco\n");
            var phones = model.Phones.ToList();
            var phone = GetPhone(phones);
            if (phone!= null)
            {
                phone.FormattedPhone = ViewsUtils.GetPhone(phone.FormattedPhone);
                phone.Description = ViewsUtils.GetDescription(phone.Description);
                phone.PhoneType = ViewsUtils.GetPhoneType(phone.PhoneType.Id.ToString());
                model.Phones = phones;
                return;
            }
            Console.Clear();
        }

        private void RemovePhone(UpdateContactModel model)
        {
            Console.WriteLine("\nREMOVER TELEFONE\n");
            var phones = model.Phones.ToList();
            var phoneModel = GetPhone(phones);
            if(phoneModel!= null)
            {
                ViewsUtils.ShowPhone(_mapper.Map<PhoneModel>(phoneModel));
                var optio = ViewsUtils.ReadYesOrNo("Realmente deseja remover esse telefone (S/N).");
                if (optio)
                {
                    phones.Remove(phoneModel);
                    model.Phones = phones;
                }
            }
            Console.Clear();
        }
        private UpdatePhoneModel? GetPhone(List<UpdatePhoneModel> phoneList)
        {
            foreach (var phone in phoneList)
            {
                ViewsUtils.ShowPhone(_mapper.Map<PhoneModel>(phone));
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
                    return _mapper.Map<UpdateContactModel>(contactModel);
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

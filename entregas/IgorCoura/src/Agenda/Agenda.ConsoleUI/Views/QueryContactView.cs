using Agenda.ConsoleUI.Utils;
using Agenda.Domain.Interfaces;
using Agenda.Domain.Params;

namespace Agenda.ConsoleUI.Views
{
     public class QueryContactView : IView
    {
        private readonly IContactService _contactService;
        private readonly Dictionary<string, Action> _optionsDictionary;

        public QueryContactView(IContactService contactService)
        {
            _contactService = contactService;
            _optionsDictionary = new Dictionary<string, Action>()
            {
                {"1", RecoverAll},
                {"2", RecoverByName},
                {"3", RecoverByDDD},
                {"4", RecoverByNumber},
            };
        }

        public void Run()
        {
            while (true)
            {
                var option = Options();
                if (option == "0")
                    return;
                _optionsDictionary[option].Invoke();
            }
            
        }

        private string Options()
        {
            Console.WriteLine("1- Buscar todos os contatos.");
            Console.WriteLine("2- Buscar contato por nome.");
            Console.WriteLine("3- Buscar contato por DDD.");
            Console.WriteLine("4- Buscar contato por numero.");
            Console.WriteLine("0- Voltar.");
            var result = Console.ReadLine()??"";
            Console.Clear();
            return result;
        }

        private void RecoverByDDD()
        {
            var ddd = ViewsUtils.GetDDD();
            var query = new ContactParams
            {
                DDD = ddd,
            };
            var models = _contactService.Recover(query).ToList();
            models.ForEach(m => ViewsUtils.ShowContact(m));
        }

        private void RecoverByNumber()
        {
            var number = ViewsUtils.GetNumber();
            var query = new ContactParams
            {
                Number = number,
            };
            var models = _contactService.Recover(query).ToList();
            models.ForEach(m => ViewsUtils.ShowContact(m));
        }
        private void RecoverByName()
        {
            var name = ViewsUtils.GetName();
            var query = new ContactParams
            {
                Name = name,
            };
            var models = _contactService.Recover(query).ToList();
            models.ForEach(m => ViewsUtils.ShowContact(m));
        }

        private void RecoverAll()
        {
            var models = _contactService.RecoverAll().ToList();
            models.ForEach(m => ViewsUtils.ShowContact(m));
        }
    }
}
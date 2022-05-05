using Agenda.ConsoleUI.Utils;
using Agenda.ConsoleUI.Interfaces;
using Agenda.Application.Interfaces;
using Agenda.Application.Params;

namespace Agenda.ConsoleUI.Views
{
    public class QueryContactView : IView
    {
        private readonly IContactService _contactService;
        private readonly Dictionary<string, Func<Task>> _optionsDictionary;

        public QueryContactView(IContactService contactService)
        {
            _contactService = contactService;
            _optionsDictionary = new Dictionary<string, Func<Task>>()
            {
                {"1", RecoverAll},
                {"2", RecoverByName},
                {"3", RecoverByDDD},
                {"4", RecoverByNumber},
            };
        }

        public async Task Run()
        {
            while (true)
            {
                var option = Options();
                if (option == "0")
                    return;
                await _optionsDictionary[option].Invoke();
            }

        }

        private string Options()
        {
            Console.WriteLine("1- Buscar todos os contatos.");
            Console.WriteLine("2- Buscar contato por nome.");
            Console.WriteLine("3- Buscar contato por DDD.");
            Console.WriteLine("4- Buscar contato por numero.");
            Console.WriteLine("0- Voltar.");
            var result = Console.ReadLine() ?? "";
            Console.Clear();
            return result;
        }

        private async Task RecoverByDDD()
        {
            var ddd = ViewsUtils.GetDDD();
            var query = new ContactParams
            {
                DDD = ddd,
            };
            var models = await _contactService.Recover(query);
            models.ToList().ForEach(m => ViewsUtils.ShowContact(m));
        }

        private async Task RecoverByNumber()
        {
            var number = ViewsUtils.GetNumber();
            var query = new ContactParams
            {
                Number = number,
            };
            var models = await _contactService.Recover(query);
            models.ToList().ForEach(m => ViewsUtils.ShowContact(m));
        }
        private async Task RecoverByName()
        {
            var name = ViewsUtils.GetName();
            var query = new ContactParams
            {
                Name = name,
            };
            var models = await _contactService.Recover(query);
            models.ToList().ForEach(m => ViewsUtils.ShowContact(m));
        }

        private async Task RecoverAll()
        {
            var models = await _contactService.RecoverAll();
            models.ToList().ForEach(m => ViewsUtils.ShowContact(m));
        }
    }
}

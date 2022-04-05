using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AgendaConsole.Interfaces;
using AgendaConsole.Model;

namespace AgendaConsole.Views
{
     public class QueryContactView
    {
        private readonly IContactService _contactService;

        public QueryContactView(IContactService contactService)
        {
            _contactService = contactService;
        }

        public void Run()
        {
            
            while (true)
            {
                var option = Options();

                switch (option)
                {
                    case "0": return;
                    case "1": RecoverAll();break;
                    case "2": RecoverByName(); break;
                }
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
            //TODO: Buscar por ddd
        }

        private void RecoverByNumber()
        {
            //TODO: Busca por numero.
        }
        private void RecoverByName()
        {
            var name = UtilsViews.GetName();
            var models = _contactService.Recover(c => c.Name.Contains(name));
            ShowContacts(models);
        }

        private void RecoverAll()
        {
            var models = _contactService.RecoverAll();
            ShowContacts(models);
        }


        private void ShowContacts(IEnumerable<ContactModel> models)
        {
            foreach (var model in models)
            {
                Console.WriteLine($"Id: {model.Id}");
                Console.WriteLine($"Name: {model.Name}");
                foreach (var phone in model.Phones)
                {
                    Console.WriteLine($"    Id: {phone.Id}");
                    Console.WriteLine($"    Phone: {phone.FormattedPhone}");
                    Console.WriteLine($"    Description: {phone.Description}");
                }
                Console.WriteLine();
            }
        }
    }
}

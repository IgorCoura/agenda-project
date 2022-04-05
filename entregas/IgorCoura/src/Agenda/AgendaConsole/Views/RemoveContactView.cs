using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AgendaConsole.Interfaces;

namespace AgendaConsole.Views
{
    public class RemoveContactView
    {
        private readonly IContactService _contactService;

        public RemoveContactView(IContactService contactService)
        {
            _contactService = contactService;
        }

        public void Run()
        {
            Console.WriteLine("\nREMOVER CONTATO\n");
            while (true)
            {
                Console.WriteLine("\n0 - Voltar\n");
                Console.WriteLine("Digite o id do contato de deseja remove: ");
                var response = Console.ReadLine();
                if(response == "0")
                {
                    return;
                }

                if(int.TryParse(response, out int id))
                {
                    _contactService.Remove(id);
                    Console.Clear();
                    Console.WriteLine("Contato removido com sucesso.");
                    return;
                }
                Console.Clear();
                Console.WriteLine("Digite um id valido.");
            }
        }
    }
}

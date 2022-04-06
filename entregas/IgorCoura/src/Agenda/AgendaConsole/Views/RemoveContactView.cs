using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AgendaConsole.Interfaces;

namespace AgendaConsole.Utils
{
    public class RemoveContactView : IView
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

                var id = ViewsUtils.GetId();

                if(id == 0)
                    return;

                _contactService.Remove(id);
                Console.Clear();
                Console.WriteLine("Contato removido com sucesso.");
                return;

            }
        }
    }
}

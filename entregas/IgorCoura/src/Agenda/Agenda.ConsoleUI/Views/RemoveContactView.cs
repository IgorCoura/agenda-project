using Agenda.Domain.Interfaces;

namespace Agenda.ConsoleUI.Utils
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

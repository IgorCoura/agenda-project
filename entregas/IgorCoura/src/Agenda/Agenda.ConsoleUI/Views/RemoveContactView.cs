using Agenda.ConsoleUI.Utils;
using Agenda.ConsoleUI.Interfaces;
using Agenda.Application.Interfaces;

namespace Agenda.ConsoleUI.Views
{
    public class RemoveContactView : IView
    {
        private readonly IContactService _contactService;

        public RemoveContactView(IContactService contactService)
        {
            _contactService = contactService;
        }

        public async Task Run()
        {
            Console.WriteLine("\nREMOVER CONTATO\n");
            while (true)
            {
                Console.WriteLine("\n0 - Voltar\n");

                var id = ViewsUtils.GetId();

                if (id == 0)
                    return;

                var contact = await _contactService.RecoverById(id);
                ViewsUtils.ShowContact(contact);
                if (ViewsUtils.ReadYesOrNo("Realmente deseja remover esse contato (S/N)."))
                {
                    await _contactService.Remove(id);
                    Console.Clear();
                    Console.WriteLine("Contato removido com sucesso.");
                }
                return;
            }
        }
    }
}

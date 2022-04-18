using Agenda.Domain.Interfaces;

namespace Agenda.ConsoleUI.Utils
{
    public class MainView : IView
    {
        private readonly IContactService _contactService;
        private readonly Dictionary<string, IView> _optionsDictionary;

        public MainView(IContactService contactService, IView createContactView, IView editContactView, IView queryContactView, IView removeContactView)
        {
            _contactService = contactService;   
            _optionsDictionary = new Dictionary<string, IView>()
            {
                {"1", createContactView},
                {"2", editContactView},
                {"3", queryContactView},
                {"4", removeContactView},
            };
        }

        public void Run()
        {
            
            while (true)
            {
                var option = Options();
                if (option == "0")
                    return;
                
                try
                {
                    if (option == "5")
                    {
                        SaveChanges();
                        continue;
                    }
                    _optionsDictionary[option].Run();
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Erro: " + ex.Message);
                }
                
            }
        }

        private string Options()
        {
            Console.WriteLine("1-Criar novo contato.");
            Console.WriteLine("2-Editar contato existente.");
            Console.WriteLine("3-Consultar contato.");
            Console.WriteLine("4-Remover contato.");
            Console.WriteLine("5-Salvar todas as alteações.");
            Console.WriteLine("0-Sair (Salve antes de sair).");
            var response = Console.ReadLine() ?? "";
            Console.Clear();
            return response;
        }

        private void SaveChanges()
        {
            _contactService.SaveChangesAsync();
            Console.WriteLine("Todas as Alterações foram salvas.");
        }

    }
}

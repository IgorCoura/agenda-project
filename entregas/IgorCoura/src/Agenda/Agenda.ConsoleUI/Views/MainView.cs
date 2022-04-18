using Agenda.Domain.Interfaces;

namespace Agenda.ConsoleUI.Views
{
    public class MainView : IView
    {
        private readonly IContactService _contactService;
        private readonly Dictionary<string, IView> _optionsDictionary;
        private readonly ViewsAccessor _viewsAccessor;

        public MainView(IContactService contactService, ViewsAccessor viewsAccessor)
        {
            _contactService = contactService;   
            _viewsAccessor = viewsAccessor;
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
                    _viewsAccessor(option).Run();
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

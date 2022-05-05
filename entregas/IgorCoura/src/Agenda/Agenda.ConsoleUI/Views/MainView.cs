using Agenda.ConsoleUI.Interfaces;
using Agenda.Application.Interfaces;
using Microsoft.Extensions.Hosting;

namespace Agenda.ConsoleUI.Views
{
    public class MainView : IView
    {
        private readonly Dictionary<string, IView> _optionsDictionary;
        private readonly ViewsAccessor _viewsAccessor;
        private readonly IHostApplicationLifetime _appLifetime;

        public MainView(IHostApplicationLifetime appLifeTime,  ViewsAccessor viewsAccessor)
        {
            _viewsAccessor = viewsAccessor;
            _appLifetime = appLifeTime;
        }

        public async Task Run()
        {
            
            while (true)
            {
                var option = Options();
                if (option == "0")
                {
                    Exit();
                    break;
                }
                   

                try
                {
                    await _viewsAccessor(option).Run();
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Erro: " + ex.Message);
                }
                
            }
            
        }

        private void Exit()
        {
            _appLifetime.StopApplication();
        }

        private string Options()
        {
            Console.WriteLine("1-Criar novo contato.");
            Console.WriteLine("2-Editar contato existente.");
            Console.WriteLine("3-Consultar contato.");
            Console.WriteLine("4-Remover contato.");
            Console.WriteLine("0-Sair.");
            var response = Console.ReadLine() ?? "";
            Console.Clear();
            return response;
        }

    }
}

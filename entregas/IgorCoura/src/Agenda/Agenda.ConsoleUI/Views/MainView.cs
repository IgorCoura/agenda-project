using Agenda.ConsoleUI.Interfaces;
using Agenda.Application.Interfaces;
using Microsoft.Extensions.Hosting;
using System.Data.Common;
using Agenda.Domain.Interfaces;

namespace Agenda.ConsoleUI.Views
{
    public class MainView : IView
    {
        private readonly ViewsAccessor _viewsAccessor;
        private readonly IHostApplicationLifetime _appLifetime;
        private readonly IInteractionService _interactionService;
        private readonly IUnitOfWork _unitOfWork;

        public MainView(IHostApplicationLifetime appLifeTime,  ViewsAccessor viewsAccessor, IInteractionService interactionService, IUnitOfWork unitOfWork)
        {
            _viewsAccessor = viewsAccessor;
            _appLifetime = appLifeTime;
            _interactionService = interactionService;
            _unitOfWork = unitOfWork;
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

                if(option == "5")
                {
                    SaveJsonInteractions();
                    continue;
                }
                   

                try
                {
                    await _viewsAccessor(option).Run();
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Message erro: " + ex.Message);
                    if(ex.InnerException is not null)
                        Console.WriteLine("Inner Exception message:" + ex.InnerException.Message);
                }
                finally
                {
                    _unitOfWork.ClearTracker();
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
            Console.WriteLine("5-Salvar log em JSON.");
            Console.WriteLine("0-Sair.");
            var response = Console.ReadLine() ?? "";
            Console.Clear();
            return response;
        }

        private void SaveJsonInteractions()
        {
            _interactionService.SaveJsonInteractionsAsync();
            Console.WriteLine("INTERAÇÕES FORAM SALVAS EM JSON");
            Console.Clear();
        }

    }
}

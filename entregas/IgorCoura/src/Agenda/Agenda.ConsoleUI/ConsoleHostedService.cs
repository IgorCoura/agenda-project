using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Agenda.ConsoleUI.Views;
using Agenda.Domain.Interfaces;
using Microsoft.Extensions.Hosting;

namespace Agenda.ConsoleUI
{
    public class ConsoleHostedService: IHostedService
    {
        private readonly IView _mainView;

        public ConsoleHostedService(MainView mainView, IHostApplicationLifetime appLifeTime)
        {
            _mainView = mainView;
            appLifeTime.ApplicationStarted.Register(OnStarted);
            appLifeTime.ApplicationStopping.Register(OnStopping);
            appLifeTime.ApplicationStopped.Register(OnStopped);
        }
        Task IHostedService.StartAsync(CancellationToken cancellationToken)
        {
            _mainView.Run();
            return Task.CompletedTask;
        }

        Task IHostedService.StopAsync(CancellationToken cancellationToken)
        {
            return Task.CompletedTask;
        }
        private void OnStarted()
        {
        }

        private void OnStopping()
        {
        }

        private void OnStopped()
        {
        }
        
    }
}

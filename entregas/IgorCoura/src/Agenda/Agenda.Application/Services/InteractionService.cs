using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Agenda.Application.Interfaces;
using Agenda.Domain.Interfaces.Repositories;

namespace Agenda.Application.Services
{
    public class InteractionService: IInteractionService
    {
        private readonly IInteractionRepository _interactionRepository;

        public InteractionService(IInteractionRepository interactionRepository)
        {
            _interactionRepository = interactionRepository;
        }

        public async void SaveJsonInteractionsAsync()
        {
            await _interactionRepository.SaveJsonInteractionsAsync();
        }
    }
}

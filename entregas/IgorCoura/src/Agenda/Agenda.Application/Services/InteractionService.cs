using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Agenda.Application.Interfaces;
using Agenda.Application.Model;
using Agenda.Domain.Core;
using Agenda.Domain.Entities.Enumerations;
using Agenda.Domain.Interfaces.Repositories;
using AutoMapper;

namespace Agenda.Application.Services
{
    public class InteractionService: IInteractionService
    {
        private readonly IInteractionRepository _interactionRepository;
        private readonly IMapper _mapper;

        public InteractionService(IInteractionRepository interactionRepository, IMapper mapper)
        {
            _interactionRepository = interactionRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<InteractionModel>> RecoverAll()
        {
            var result = await _interactionRepository.GetDataAsync();
            return _mapper.Map<IEnumerable<InteractionModel>>(result);
        }

        public async Task<IEnumerable<InteractionTypeModel>> RecoverTypes()
        {
            return _mapper.Map<IEnumerable<InteractionTypeModel>>(Enumeration.GetAll<InteractionType>());
        }
        public async Task SaveJsonInteractionsAsync()
        {
            await _interactionRepository.SaveJsonInteractionsAsync();
        }
    }
}

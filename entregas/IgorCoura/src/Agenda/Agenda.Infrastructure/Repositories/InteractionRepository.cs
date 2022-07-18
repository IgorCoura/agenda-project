using Agenda.Domain.Entities;
using Agenda.Domain.Interfaces;
using Agenda.Domain.Interfaces.Repositories;
using Agenda.Infrastructure.Context;

namespace Agenda.Infrastructure.Repositories
{
    public class InteractionRepository : BaseRepository<Interaction>, IInteractionRepository
    {
        private readonly IJsonStorage<Interaction> _jsonStorage;

        public InteractionRepository(ApplicationContext context, IJsonStorage<Interaction> jsonStorage) : base(context)
        {
            _jsonStorage = jsonStorage;
        }

        public async Task SaveJsonInteractionsAsync()
        {
            var interactions = await GetDataAsync();
            if (interactions is not null)
                _jsonStorage.CreateMany(interactions);

            await _jsonStorage.SaveAsync();
        }

    }
}

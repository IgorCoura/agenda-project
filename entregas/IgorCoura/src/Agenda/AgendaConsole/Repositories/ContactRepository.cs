using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AgendaConsole.Entities;
using AgendaConsole.Interfaces;

namespace AgendaConsole.Repositories
{
    public class ContactRepository: IContactRepository
    {
        private readonly IJsonStorage<Contact> _jsonStorage;

        public ContactRepository(IJsonStorage<Contact> jsonStorage)
        {
            _jsonStorage = jsonStorage;
        }

        public async Task<Contact> CreateAsync(Contact entity)
        {
            if(entity.Phones.Count > 0)
            {
                entity.Phones.ForEach(x => PhoneExist(x));
                entity.Phones = AddIdPhone(entity.Phones);
            }
            _jsonStorage.Create(entity);
            await _jsonStorage.SaveAsync();
            return entity;
        }

        public async Task<Contact> UpdateAsync(Contact entity)
        {
            if (entity.Phones.Count > 0)
            {
                entity.Phones.ForEach(x => PhoneExist(x));
                entity.Phones = AddIdPhone(entity.Phones);
            }
            var result = _jsonStorage.Update(entity);
            await _jsonStorage.SaveAsync();
            return result;
        }

        public IEnumerable<Contact> GetAll()
        {
            return _jsonStorage.GetAll();
        }

        public Contact GetById(int id)
        {
            return _jsonStorage.GetById(id);
        }

        public Contact Remove(int id)
        {
            return _jsonStorage.Remove(id);
        }

        private List<Phone> AddIdPhone(List<Phone> phones)
        {
            var existingPhones = _jsonStorage.GetAll().SelectMany(c => c.Phones);
            var id = existingPhones.Any() ? existingPhones.LastOrDefault()!.Id + 1 : existingPhones.Count() + 1;
            phones.ForEach(p => p.Id = p.Id == 0 ? id++ : p.Id);
            return phones;
        }

        private void PhoneExist(Phone phone)
        {
            if (_jsonStorage.GetAll().SelectMany(c => c.Phones).Count(p => p.Equals(phone)) > 0)
            {
                throw new Exception($"O telefone {phone} já existe.");
            }
        }

    }
}

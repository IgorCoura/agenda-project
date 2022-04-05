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
            entity.Id = _jsonStorage.CreateId();
            if(entity.Phones.Count > 0)
            {
                entity.Phones.ForEach(x => PhoneExist(x));
                entity.Phones = AddIdPhone(entity.Phones);
                entity.Phones.ForEach(x => x.ContactId = entity.Id);
                entity.Phones.ForEach(x => x.UpdatedAt = DateTime.Now);
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
                entity.Phones.ForEach(p => p.ContactId = entity.Id);
                entity.Phones.ForEach(x => x.UpdatedAt = DateTime.Now);
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

        public async Task<Contact> Remove(int id)
        {
            var result = _jsonStorage.Remove(id);
            await _jsonStorage.SaveAsync();
            return result;
        }

        private List<Phone> AddIdPhone(List<Phone> phones)
        {
            var existingPhones = _jsonStorage.GetAll().SelectMany(c => c.Phones);
            var id = existingPhones.Any() ? existingPhones.LastOrDefault()!.Id + 1 : existingPhones.Count() + 1;
            phones.ForEach(p => {
                p.Id = p.Id == 0 ? id++ : p.Id;
                p.CreatedAt = DateTime.Now;
                });
            return phones;
        }

        private void PhoneExist(Phone phone)
        {
            if (phone.Id == 0 && _jsonStorage.GetAll().SelectMany(c => c.Phones).Count(p => p.Equals(phone)) > 0)
            {
                throw new Exception($"O telefone {phone} já existe.");
            }
        }

    }
}

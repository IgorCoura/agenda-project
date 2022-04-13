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

        public Contact Create(Contact entity)
        {
            entity.Id = _jsonStorage.CreateId();
            if(entity.Phones.ToList().Count > 0)
            {
                entity.Phones = FormatAndVerifyPhones(entity.Phones.ToList(), entity.Id);
            }
            _jsonStorage.Create(entity);
            return entity;
        }

        public Contact Update(Contact entity)
        {
            if (entity.Phones.ToList().Count > 0)
            {
                entity.Phones = FormatAndVerifyPhones(entity.Phones.ToList(), entity.Id);
            }
            var result = _jsonStorage.Update(entity);
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
            var result = _jsonStorage.Remove(id);
            return result;
        }
         
        public List<Phone> FormatAndVerifyPhones(List<Phone> phones, int contactId)
        {
            PhonesExists(phones);
            phones = AddIdPhone(phones);
            phones.ForEach(p => p.ContactId = contactId);
            phones.ForEach(x => x.UpdatedAt = DateTime.Now);
            return phones;
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

        private void PhonesExists(List<Phone> phones)
        {
            foreach(Phone phone in phones)
            {
                var quantEqualNumbersInDb = _jsonStorage.GetAll().SelectMany(c => c.Phones).Count(p => p.Equals(phone));
                var quantEqualNumbersInListPhones = phones.Count(p => p.Equals(phone));
                if (phone.Id == 0
                &&  (quantEqualNumbersInDb > 0
                || quantEqualNumbersInListPhones > 1))
                {
                    throw new Exception($"O telefone {phone} já existe.");
                }
            }
        }

        public async Task SaveChangesAsync()
        {
            await _jsonStorage.SaveAsync();
        }
    }
}

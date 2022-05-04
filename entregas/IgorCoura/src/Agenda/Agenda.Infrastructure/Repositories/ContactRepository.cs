using System.Linq.Expressions;
using Agenda.Domain.Entities;
using Agenda.Domain.Entities.Enumerations;
using Agenda.Domain.Interfaces;
using Agenda.Infrastructure.Context;

namespace Agenda.Infrastructure.Repositories
{
    public class ContactRepository : BaseRepository<Contact>, IContactRepository
    {
        public ContactRepository(ApplicationContext context) : base(context)
        {
            
        }

        public override Task<Contact> RegisterAsync(Contact model)
        {
            if (model.Phones.ToList().Any())
            {
                FormatAndVerifyPhones(model.Phones.ToList());
            }
            return base.RegisterAsync(model);
        }

        public override Task<Contact> UpdateAsync(Contact model)
        {
            if (model.Phones.ToList().Any())
            {
                FormatAndVerifyPhones(model.Phones.ToList());
            }
            return base.UpdateAsync(model);
        }

        public List<Phone> FormatAndVerifyPhones(List<Phone> phones)
        {
            PhonesExists(phones);
            phones.ForEach(x => { x.CreatedAt = DateTime.Now; x.UpdatedAt = DateTime.Now;});
            return phones;
        }


        private void PhonesExists(List<Phone> phones)
        {
            foreach (Phone phone in phones)
            {
                var quantEqualNumbersInListPhones = phones.Count(p => p.Equals(phone));
                if (phone.Id == 0 &&  quantEqualNumbersInListPhones > 1)
                {
                    throw new Exception($"O telefone {phone} já existe.");
                }
            }
        }
    }
}

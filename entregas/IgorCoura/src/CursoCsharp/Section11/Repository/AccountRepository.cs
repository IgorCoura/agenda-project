using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Section11.Entities;
using Section11.Interfaces;

namespace Section11.Repository
{
    public class AccountRepository: IAccountRepository
    {
        private List<Account> _entities;

        public AccountRepository()
        {
            _entities = new List<Account>();
        }
        public void Create(Account account)
        {
            _entities.Add(account);
        }

        public void Update(Account account)
        {
            _entities[_entities.FindIndex(x => x.Agency == account.Agency && x.NumberAccount == account.NumberAccount)] = account;
        }

        public void Delete(int agency, int numberAccount)
        {
            _entities.RemoveAll(x => x.Agency == agency && x.NumberAccount == numberAccount);
        }

        public Account Get(int agency, int numberAccount)
        {
            return _entities.Find(x => x.Agency == agency && x.NumberAccount == numberAccount) ?? throw new Exception($"Agency: {agency} and Account: {numberAccount}, not exist.");
        }

        public IEnumerable<Account> GetAll()
        {
            return _entities;
        }
    }
}

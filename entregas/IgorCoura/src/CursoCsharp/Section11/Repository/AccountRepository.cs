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
        public void Create(Account e)
        {
            _entities.Add(e);
        }

        public void Update(Account e)
        {
            _entities[_entities.FindIndex(x => x.Agency == e.Agency && x.NumberAccount == e.NumberAccount)] = e;
        }

        public void Delete(int agency, int numberAccount)
        {
            _entities.RemoveAll(x => x.Agency == agency && x.NumberAccount == numberAccount);
        }

        public Account get(int agency, int numberAccount)
        {
            return _entities.Find(x => x.Agency == agency && x.NumberAccount == numberAccount) ?? throw new Exception($"Agency: {agency} and Account: {numberAccount}, not exist.");
        }

        public IEnumerable<Account> getAll()
        {
            return _entities;
        }
    }
}

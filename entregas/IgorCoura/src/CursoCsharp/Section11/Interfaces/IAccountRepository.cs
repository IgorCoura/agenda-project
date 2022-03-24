using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Section11.Entities;

namespace Section11.Interfaces
{
    public interface IAccountRepository
    {
        public void Create(Account e);

        public void Update(Account e);

        public void Delete(int agency, int numberAccount);

        public Account get(int agency, int numberAccount);

        public IEnumerable<Account> getAll();
    }
}

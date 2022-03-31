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
        void Create(Account account);

        void Update(Account account);

        void Delete(int agency, int numberAccount);

        Account Get(int agency, int numberAccount);

        IEnumerable<Account> GetAll();
    }
}

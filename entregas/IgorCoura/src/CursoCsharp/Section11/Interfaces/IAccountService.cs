using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Section11.Entities;
using Section11.Model;

namespace Section11.Interfaces
{
    public interface IAccountService
    {
        AccountModel Register(Client client, decimal withdrawLimit);

        void Remove(AccountModel account);

        void Transfer(AccountModel accountOut, AccountModel accountIn, decimal value);

        void Deposit(AccountModel account, decimal value);

        void Withdraw(AccountModel account, decimal value);
        Account Recover(AccountModel account);
        IEnumerable<Account> RecoverAll();
    }
}

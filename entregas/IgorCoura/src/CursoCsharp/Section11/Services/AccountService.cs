using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Section11.Entities;
using Section11.Interfaces;

namespace Section11.Services
{
    public class AccountService
    {
        private readonly IAccountRepository _accountRepository;

        public AccountService(IAccountRepository accountRepository)
        {
            _accountRepository = accountRepository;
        }

        public void Register(Account account)
        {
            _accountRepository.Create(account);
        }

        public void Remove(int agency, int numberAccount)
        {
            _accountRepository.Delete(agency, numberAccount);
        }
    }
}

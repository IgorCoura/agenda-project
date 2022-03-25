using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Section11.Entities;
using Section11.Exceptions;
using Section11.Interfaces;
using Section11.Model;

namespace Section11.Services
{
    public class AccountService: IAccountService
    {
        private readonly IAccountRepository _accountRepository;

        public AccountService(IAccountRepository accountRepository)
        {
            _accountRepository = accountRepository;
        }

        public AccountModel Register(Client client, decimal withdrawLimit)
        {
            var account = accountGenerator(client, withdrawLimit);
            _accountRepository.Create(account);
            return new AccountModel(account.Agency, account.NumberAccount);
        }

        public void Remove(AccountModel account)
        {
            _accountRepository.Delete(account.Agency, account.NumberAccount);
        }

        public void Transfer(AccountModel accountOut, AccountModel accountIn, decimal value)
        {
            var acOut = _accountRepository.get(accountOut.Agency, accountOut.NumberAccount);
            var acIn = _accountRepository.get(accountIn.Agency, accountIn.NumberAccount);
            acOut.Withdraw(value);
            acIn.Deposit(value);
            _accountRepository.Update(acOut);
            _accountRepository.Update(acIn);
        }

        public void Deposit(AccountModel account, decimal value)
        {
            var ac = _accountRepository.get(account.Agency, account.NumberAccount);
            ac.Deposit(value);
            _accountRepository.Update(ac);
        }

        public void Withdraw(AccountModel account, decimal value)
        {
            var ac = _accountRepository.get(account.Agency, account.NumberAccount);
            ac.Withdraw(value);
            _accountRepository.Update(ac);
        }

        public Account Recover(AccountModel account)
        {
            return _accountRepository.get(account.Agency, account.NumberAccount);
        }

        public IEnumerable<Account> RecoverAll()
        {
            return _accountRepository.getAll();
        }

        private Account accountGenerator(Client client, decimal withdrawLimit)
        {
            var random = new Random();
            var timeout = DateTime.UtcNow.AddMinutes(5);
            while (true)
            {
                var agencia = random.Next(1000, 9999);
                var numberAccount = random.Next(10000000, 99999999);
                if (DateTime.UtcNow > timeout)
                {
                    throw new DomainException("Timeout expired. Unable to create an account.");
                }
                try
                {
                    _accountRepository.get(agencia, numberAccount);
                    continue;
                }
                catch
                {
                    return new Account(client, agencia, numberAccount, withdrawLimit);
                }
            }
            
        }
    }
}

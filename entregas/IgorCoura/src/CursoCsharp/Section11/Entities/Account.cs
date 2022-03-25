using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Section11.Exceptions;

namespace Section11.Entities
{
    public class Account
    {
        private decimal _amount = 0;
        public Client Client { get; set; }
        public int Agency { get; set; }
        public int NumberAccount { get; set; }
        public decimal WithdrawLimit { get; set; }

        public Account(Client client, int agency, int numberAccount, decimal withdrawLimit)
        {
            Client = client;
            Agency = agency;
            NumberAccount = numberAccount;
            WithdrawLimit = withdrawLimit;
        }

        public void Deposit(decimal value)
        {
            _amount += value;
        }

        public void Withdraw(decimal value)
        {
            if(value > WithdrawLimit)
            {
                throw new DomainException("The amount exceeds withdraw limit");
            }
            if(_amount > value)
            {
                _amount -= value;
            }
            else
            {
                throw new DomainException("There is no amount enough in account to withdraw");
            }
        }

        public override string ToString()
        {
            return $"{Agency}, {NumberAccount}, {WithdrawLimit}, {_amount}";
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Section11.Entities
{
    public class Account
    {
        public Client Client { get; set; }
        public int Agency { get; set; }
        public int NumberAccount { get; set; }
        public decimal Balance { get; set; }

        public Account(Client client, int agency, int numberAccount, decimal balance)
        {
            Client = client;
            Agency = agency;
            NumberAccount = numberAccount;
            Balance = balance;
        }

        
    }
}

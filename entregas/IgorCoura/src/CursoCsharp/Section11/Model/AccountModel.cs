using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Section11.Model
{
    public record AccountModel
    {
        public int Agency { get; set; }
        public int NumberAccount { get; set; }
        public AccountModel(int agency, int numberAccount)
        {
            Agency = agency;
            NumberAccount = numberAccount;
        }

        
    }
}

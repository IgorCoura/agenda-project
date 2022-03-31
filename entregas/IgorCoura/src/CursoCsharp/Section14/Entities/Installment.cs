using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Section14.Entities
{
    public class Installment
    {

        public DateTime Date { get; set; }
        public decimal Amount { get; set; }

        public Installment(DateTime date, decimal amount)
        {
            Date = date;
            Amount = amount;
        }

       
    }
}

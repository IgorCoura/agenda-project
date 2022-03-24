using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Section14.Entities
{
    public class Contract
    {
        public int Number { get; set; }
        public DateTime Date { get; set; }
        public decimal TotalValue { get; set; }
        public string PaymentMethod { get; set; }
        public Installment[] Installments { get; set; }

        public Contract(int number, DateTime date, decimal totalValue, string paymentMethod, int numberInstallments)
        {
            Number = number;
            Date = date;
            TotalValue = totalValue;
            PaymentMethod = paymentMethod;
            Installments = new Installment[numberInstallments];
        }

        public void InsertInstallment(int index, Installment installment)
        {
            Installments[index] = installment;
        }

        public decimal TotalValueInstallments()
        {
            decimal total = 0;
            foreach(var installment in Installments)
            {
                total += installment.Amount;
            }
            return total;
        }

    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Section14.Entities;
using Section14.Interfaces;

namespace Section14.Services
{
    public class PayPalPaymentService: IPaymentService
    {
        private const decimal FeePercentage = 0.02M;
        private const decimal MonthlyInterest = 0.01M;
        public decimal CalculateInstallment(decimal amount, int month)
        {
            return amount + (amount * MonthlyInterest * month);
        }

        public decimal CalculateFees(decimal amount)
        {
            return amount * (1 + FeePercentage) ;
        }
    }
}

using Section14.Interfaces;

namespace Section14.Services
{
    public class CreditCardPaymentService : IPaymentService
    {
        private const decimal FeePercentage = 0.05M;
        private const decimal MonthlyInterest = 0.15M;
        public decimal CalculateFees(decimal amount)
        {
            return amount *(1+FeePercentage);
        }

        public decimal CalculateInstallment(decimal amount, int month)
        {
            var value = (decimal)Math.Pow((double)(1 + MonthlyInterest), month);
            return amount * value;
        }
    }
}

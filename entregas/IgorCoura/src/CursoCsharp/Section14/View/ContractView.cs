using System;
using System.Collections.Generic;
using Section14.Entities;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Section14.View
{
    public static class ContractView
    {
        public static Contract GetContract()
        {
            Console.WriteLine("Enter contract data.");
            Console.WriteLine("Number:");
            var numberContract = int.TryParse(Console.ReadLine(), out int result1)? result1 : 0;
            Console.WriteLine("Date (dd/MM/yyyy):");
            var dateContract = DateTime.TryParse(Console.ReadLine(), out DateTime result2)? result2 : DateTime.Now;
            Console.WriteLine("Contract value: ");
            var contractValue = decimal.TryParse(Console.ReadLine(), NumberStyles.AllowDecimalPoint, CultureInfo.InvariantCulture, out decimal result3)? result3: 0;
            Console.WriteLine("Enter number of installments: ");
            var numberInstallments = int.TryParse(Console.ReadLine(), out int result4)? result4 : 0;
            Console.WriteLine("Payment method (Paypal, CreditCard): ");
            var methodPayment = (Console.ReadLine() ?? "paypal").ToLower();

            return new Contract(numberContract, dateContract, contractValue, methodPayment, numberInstallments);
        }

        public static void ShowInstallments(this Contract contract)
        {
            foreach(var installment in contract.Installments)
                Console.WriteLine($"{installment.Date.ToString("dd/MM/yyyy")} - {installment.Amount.ToString("0.00", CultureInfo.InvariantCulture)}");
            Console.WriteLine($"Total: {contract.TotalValueInstallments().ToString("0.00", CultureInfo.InvariantCulture)}");
        }
    }
}


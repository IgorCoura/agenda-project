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
            var numberContract = int.Parse(Console.ReadLine() ?? "0");
            Console.WriteLine("Date (dd/MM/yyyy):");
            var dateContract = DateTime.Parse(Console.ReadLine() ?? throw new ArgumentNullException("Date not be null"));
            Console.WriteLine("Contract value: ");
            var contractValue = decimal.Parse(Console.ReadLine() ?? "0", NumberStyles.AllowDecimalPoint, CultureInfo.InvariantCulture);
            Console.WriteLine("Enter number of installments: ");
            var numberInstallments = int.Parse(Console.ReadLine() ?? "0");
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


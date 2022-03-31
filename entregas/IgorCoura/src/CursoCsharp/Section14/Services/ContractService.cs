using System;
using System.Collections.Generic;
using Section14.Entities;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Section14.Interfaces;

namespace Section14.Services
{
    public class ContractService: IContractService
    {
        private readonly IPaymentFactory _paymentFactory;
        public ContractService(IPaymentFactory paymentFactory)
        {
            _paymentFactory = paymentFactory;
        }

        public void ProcessContract(Contract contract)
        {
            var service = _paymentFactory.Create(contract.PaymentMethod);
            var valueInstallment = contract.TotalValue / contract.Installments.Length;
            for(int month = 1; month <= contract.Installments.Length; month++)
            {
                var dateInstallment = contract.Date.AddMonths(month);
                var amount = service.CalculateInstallment(valueInstallment, month);
                var totalAmount = service.CalculateFees(amount);
                contract.InsertInstallment(month-1,new Installment(dateInstallment, totalAmount));
            }
        }
    }
}

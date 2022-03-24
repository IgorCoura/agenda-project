using System.Globalization;
using Section14.Entities;
using Section14.Interfaces;
using Section14.Services;
using Section14.Services.Factory;
using Section14.View;

IPaymentFactory factory = new PaymentFactory();
factory.Register("paypal", new PayPalPaymentService())
       .Register("creditcard", new CreditCardPaymentService());

IContractService _contractService = new ContractService(factory);

try
{

    var contract = ContractView.GetContract();

    _contractService.ProcessContract(contract);

    contract.ShowInstallments();

}
catch (Exception e)
{
    Console.WriteLine(e.Message);
}





// See https://aka.ms/new-console-template for more information
using Section11.Entities;
using Section11.Interfaces;
using Section11.Repository;
using Section11.Services;

IClientRepository _clientRepository = new ClientRepository();
IClientService _clientService = new ClientService(_clientRepository);

IAccountRepository _accountRepository = new AccountRepository();
IAccountService _accountService = new AccountService(_accountRepository);


Console.WriteLine("Welcome");


//Cadastro clientes
var client1 = new Client("Maria", "685.414.310-10", DateOnly.Parse("01/01/1992"));
var client2 = new Client("Jose", "056.341.950-47", DateOnly.Parse("01/01/1985"));

_clientService.Register(client1);
_clientService.Register(client2);

var allClients = _clientService.RecoverAll();
foreach(var client in allClients)
{
    Console.WriteLine(client.ToString());
}

//Criando Conta
var account1 = _accountService.Register(client1, 1000);
var account2 = _accountService.Register(client2, 5000);
printAccounts();

_accountService.Deposit(account1, 555);
_accountService.Deposit(account2, 122);

printAccounts();

_accountService.Transfer(account1, account2 , 55);

printAccounts();

_accountService.Withdraw(account2, 132);

printAccounts();





void printAccounts()
{
    var allAccounts = _accountService.RecoverAll();
    Console.WriteLine("\nAccounts");
    foreach (var account in allAccounts)
    {
        Console.WriteLine(account.ToString());
    }
}

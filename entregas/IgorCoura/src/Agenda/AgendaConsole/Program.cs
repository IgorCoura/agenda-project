
using AgendaConsole.Entities;
using AgendaConsole.Repositories;
using AgendaConsole.Services;
using AgendaConsole.Utils;

var storage = new JsonStorage<Contact>();
var repository = new ContactRepository(storage);
var service = new ContactService(repository);

var createContactView = new CreateContactView(service);
var editContactView = new EditContactView(service);
var queryContactView = new QueryContactView(service);
var removeContactView = new RemoveContactView(service);

var mainView = new MainView(service, createContactView, editContactView, queryContactView, removeContactView);

mainView.Run();

Console.WriteLine("Finished!");

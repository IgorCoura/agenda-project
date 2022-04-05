
using AgendaConsole.Entities;
using AgendaConsole.Options;
using AgendaConsole.Repositories;
using AgendaConsole.Services;
using AgendaConsole.Views;





var storage = new JsonStorage<Contact>();
var repository = new ContactRepository(storage);
var service = new ContactService(repository);

var createContactView = new CreateContactView(service);
var editContactView = new EditContactView(service);
var queryContactView = new QueryContactView(service);
var removeContactView = new RemoveContactView(service);

var mainView = new MainView(createContactView, editContactView, queryContactView, removeContactView);
mainView.Run();

Console.WriteLine("Finished!");

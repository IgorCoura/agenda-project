

using AgendaConsole.Entities;
using AgendaConsole.Options;
using AgendaConsole.Repositories;
using AgendaConsole.Services;

var storage = new JsonStorage<Contact>();
var repository = new ContactRepository(storage);
var service = new ContactService(repository);

var listPhone = new List<Phone>();
listPhone.Add(new Phone(0, 0, "description1", "xxx1", 11, 123456789, DateTime.Now, DateTime.Now));
listPhone.Add(new Phone(0, 0, "description2", "xxx2", 12, 987654321, DateTime.Now, DateTime.Now));

var contact = new Contact(0, "Jose", listPhone, DateTime.Now, DateTime.Now);

await service.RegisterAsync(contact);

Console.WriteLine("Finished!");

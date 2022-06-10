using Agenda.Domain.Core;

namespace Agenda.Domain.Entities
{
    public class Contact: Register 
    {
        public Contact(string name, List<Phone> phones)
        {
            Name = name;
            Phones = phones;
        }

        public Contact(int id, string name, List<Phone> phones, DateTime createdAt, DateTime updatedAt) : base(id, createdAt, updatedAt)
        {
            Name = name;
            Phones = phones;
        }

        public Contact() { }

        public string Name { get; set; } = string.Empty;
        public int UserId { get; set; }
        public User User { get; set; }

        public IEnumerable<Phone> Phones { get; set; }
    }
}

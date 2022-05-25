namespace Agenda.Application.Model
{
    public class ContactModel
    {
        
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public IEnumerable<PhoneModel> Phones { get; set; }
    }
}


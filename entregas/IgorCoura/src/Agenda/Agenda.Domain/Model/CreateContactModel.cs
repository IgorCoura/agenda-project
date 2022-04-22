namespace Agenda.Domain.Model
{
    public class CreateContactModel
    {
        public string Name { get; set; } = string.Empty;
        public IEnumerable<CreatePhoneModel> Phones { get; set; }

    }
}
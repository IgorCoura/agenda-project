namespace Agenda.Application.Model
{
    public record ContactModel: BaseContactModel
    {
        public int Id { get; set; }
        public IEnumerable<PhoneModel> Phones { get; set; }
    }

}


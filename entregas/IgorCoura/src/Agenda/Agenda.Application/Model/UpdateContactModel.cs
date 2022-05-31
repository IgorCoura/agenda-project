namespace Agenda.Application.Model
{
    public record UpdateContactModel: BaseContactModel
    {
        public int Id { get; set; }
        public IEnumerable<UpdatePhoneModel> Phones { get; set; }
    }
}


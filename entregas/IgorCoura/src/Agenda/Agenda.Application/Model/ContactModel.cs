namespace Agenda.Application.Model
{
    public record ContactModel: BaseContactModel<PhoneModel>
    {
        public int Id { get; set; }
    }

}


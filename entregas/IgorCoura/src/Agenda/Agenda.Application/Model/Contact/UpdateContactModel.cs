namespace Agenda.Application.Model
{
    public record UpdateContactModel: BaseContactModel<UpdatePhoneModel>
    {
        public int Id { get; set; }
        
    }
}


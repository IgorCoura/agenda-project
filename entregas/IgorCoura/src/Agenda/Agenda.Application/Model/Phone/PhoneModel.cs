namespace Agenda.Application.Model
{
    public record PhoneModel: BasePhoneModel
    {
        public int Id { get; set; }
        public string PhoneType { get; set; } = string.Empty;

    }
}

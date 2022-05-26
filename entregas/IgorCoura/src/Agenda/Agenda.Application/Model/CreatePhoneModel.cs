namespace Agenda.Application.Model
{

    public record CreatePhoneModel
    {
        public string FormattedPhone { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public int PhoneTypeId { get; set; }

    }
}

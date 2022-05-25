namespace Agenda.Application.Model
{
    public class UpdatePhoneModel
    {
        public int Id { get; set; }
        public string Description { get; set; } = string.Empty;
        public string FormattedPhone { get; set; } = string.Empty;
        public int PhoneTypeId { get; set; }
    }
}


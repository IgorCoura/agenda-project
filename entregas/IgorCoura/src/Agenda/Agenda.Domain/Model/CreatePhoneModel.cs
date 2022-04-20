namespace Agenda.Domain.Model
{

    public class CreatePhoneModel
    {
        public string FormattedPhone { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public PhoneTypeModel PhoneType { get; set; }
        public int PhoneTypeId { get; set; }

    }
}

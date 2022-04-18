namespace Agenda.Domain.Model
{
    public class PhoneModel
    {
        public int Id { get; set; }
        public int ContactId { get; set; }
        public string Description { get; set; } = string.Empty;
        public string FormattedPhone { get; set; } = string.Empty;
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}

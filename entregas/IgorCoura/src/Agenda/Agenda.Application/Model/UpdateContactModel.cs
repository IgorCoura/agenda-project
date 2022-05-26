namespace Agenda.Application.Model
{
    public record UpdateContactModel
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public IEnumerable<UpdatePhoneModel> Phones { get; set; }
    }
}

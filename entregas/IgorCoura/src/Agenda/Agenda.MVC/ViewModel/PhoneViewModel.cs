using System.ComponentModel.DataAnnotations;

namespace Agenda.MVC.ViewModel
{
    public class PhoneViewModel
    {
        [Key]
        public int Id { get; set; }
        public string Description { get; set; } = string.Empty;
        public string FormattedPhone { get; set; } = string.Empty;
        public int PhoneTypeId { get; set; }
        public string PhoneType { get; set; } = string.Empty;
    }
}

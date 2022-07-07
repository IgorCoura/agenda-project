using System.ComponentModel.DataAnnotations;

namespace Agenda.MVC.ViewModel
{
    public class ContactViewModel
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public List<PhoneViewModel> Phones { get; set; }
    }
}

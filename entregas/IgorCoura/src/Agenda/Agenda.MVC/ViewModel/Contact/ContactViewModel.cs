using System.ComponentModel.DataAnnotations;

namespace Agenda.MVC.ViewModel.Contact
{
    public class ContactViewModel
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public List<PhoneViewModel> Phones { get; set; }
    }
}

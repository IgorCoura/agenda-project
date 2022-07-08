namespace Agenda.MVC.ViewModel
{
    public class BaseAdminContactViewModel<T>
    {
        public int UserId { get; set; }
        public T Contact { get; set; }
    }
}

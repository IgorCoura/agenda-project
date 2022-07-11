namespace Agenda.MVC.ViewModel
{
    public class BasePageResponseViewModel<T>
    {
        public bool Success { get; set; }
        public int TotalItems { get; set; }
        public T Data { get; set; }
    }
}

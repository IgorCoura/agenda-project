namespace Agenda.MVC.ViewModel
{
    public class BaseResponseViewModel<T>
    {
        public bool Success { get; set; }
        public T Data { get; set; }
    }
}

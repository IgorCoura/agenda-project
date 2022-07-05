namespace Agenda.MVC.ViewModel
{
    public class BaseResponseViewModel<T>
    {
        public bool Success { get; set; }
        public IEnumerable<T> Data { get; set; }
    }
}

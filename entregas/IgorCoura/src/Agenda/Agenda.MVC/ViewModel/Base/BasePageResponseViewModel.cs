namespace Agenda.MVC.ViewModel.Base
{
    public class BasePageResponseViewModel<T>
    {
        public bool Success { get; set; }
        public int TotalItems { get; set; }
        public T Data { get; set; }
    }
}

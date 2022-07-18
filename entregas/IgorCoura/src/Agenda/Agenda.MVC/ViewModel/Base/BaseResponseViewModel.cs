namespace Agenda.MVC.ViewModel.Base
{
    public class BaseResponseViewModel<T>
    {
        public bool Success { get; set; }
        public T Data { get; set; }
    }
}

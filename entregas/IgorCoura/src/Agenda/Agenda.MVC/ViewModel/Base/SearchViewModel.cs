using Microsoft.AspNetCore.Mvc.Rendering;

namespace Agenda.MVC.ViewModel.Base
{
    public class SearchViewModel<T>
    {
        public string? Key { get; set; }
        public string? Value { get; set; }
        public T Data { get; set; }
        public int TotalPages { get; set; } = 0;
        public int CurrentPage { get; set; } = 1;
        public int Take { get; set; } = 10;
        public IEnumerable<SelectListItem> SearchKeys { get; set; }

    }
}

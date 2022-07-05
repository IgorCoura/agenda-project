namespace Agenda.MVC.Params
{
    public class UserParams
    {
        public string? Name { get; set; }
        public string? Username { get; set; }
        public string? Email { get; set; }
        public int? Skip { get; set; }
        public int? Take { get; set; }
        public  Dictionary<string, string>? Query()
        {
            var query = new Dictionary<string, string>();

            if (!string.IsNullOrEmpty(Name))
                query["Name"] = Name;

            if (!string.IsNullOrEmpty(Username))
                query["Username"] = Username;

            if (!string.IsNullOrEmpty(Email))
                query["Email"] = Email;

            if (Skip.HasValue)
                query["Skip"] = Skip.ToString()!;

            if (Take.HasValue)
                query["Take"] = Take.ToString()!;

            if (query.Count > 0)
            {
                return query;
            }
            return null;
            
        }
    }
}

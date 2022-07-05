

namespace Agenda.MVC.Params
{
    public class ContactParams
    {
        public string? Name { get; set; }
        public int? DDD { get; set; }
        public int? Number { get; set; }
        public int? Skip { get; set; }
        public int? Take { get; set; }

        public Dictionary<string, string>? Query()
        {
            var query = new Dictionary<string, string>();

            if (!string.IsNullOrEmpty(Name))
               query["Name"] = Name;

            if (DDD.HasValue)
                query["DDD"] = DDD.ToString()!;

            if (Number.HasValue)
                query["Number"] = Number.ToString()!;

            if(Skip.HasValue)
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

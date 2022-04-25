using System.Linq.Expressions;
using Agenda.Domain.Entities;
using LinqKit;

namespace Agenda.Application.Params
{
    public class ContactParams:BaseParams<Contact>
    {
        public string? Name { get; set; }
        public int? DDD { get; set; }
        public int? Number { get; set; }

        public override Expression<Func<Contact, bool>> Filter()
        {
            var predicate = PredicateBuilder.New<Contact>();

            if (!string.IsNullOrEmpty(Name))
                predicate = predicate.And(x => x.Name.ToLower().Contains(Name.ToLower()));

            if (DDD.HasValue)
                predicate = predicate.And(x => x.Phones.Any(x => x.DDD == DDD));

            if (Number.HasValue)
                predicate = predicate.And(x => x.Phones.Any(x => x.Number == Number));

            return predicate;
        }
    }
}

using System.Linq.Expressions;
using Agenda.Domain.Core;

namespace Agenda.Application.Params
{
    public abstract class BaseParams<T> where T : Register
    {
        public abstract Expression<Func<T, bool>> Filter();
        protected BaseParams() { }

    }
}

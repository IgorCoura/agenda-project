using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Agenda.Domain.Core;

namespace Agenda.Domain.Params
{
    public abstract class BaseParams<T> where T : Register
    {
        public abstract Expression<Func<T, bool>> Filter();
        protected BaseParams() { }

    }
}

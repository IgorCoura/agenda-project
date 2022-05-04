using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Agenda.Domain.Interfaces;

namespace Agenda.Domain.Core
{
    public interface IRepository<T> where T: Register
    {
        IUnitOfWork UnitOfWork { get; }
    }
}

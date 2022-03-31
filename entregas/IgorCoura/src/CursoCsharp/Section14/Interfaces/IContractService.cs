using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Section14.Entities;

namespace Section14.Interfaces
{
    public interface IContractService
    {
        void ProcessContract(Contract contract);
    }
}

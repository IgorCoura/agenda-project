using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Section14.Interfaces
{
    public interface IPaymentService
    {
        decimal CalculateInstallment(decimal amount, int month);
        decimal CalculateFees(decimal amount);
    }
}

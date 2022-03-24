using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Section14.Interfaces
{
    public interface IPaymentFactory
    {
        IPaymentService Create(string paymentMethod);
        IPaymentFactory Register(string paymentMethod, IPaymentService service);
    }
}

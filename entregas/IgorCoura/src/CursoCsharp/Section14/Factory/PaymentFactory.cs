using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Section14.Interfaces;

namespace Section14.Services.Factory
{
    public class PaymentFactory: IPaymentFactory
    {
        private readonly IDictionary<string, IPaymentService> _services = new Dictionary<string, IPaymentService>();
        public IPaymentService Create(string paymentMethod)
        {
            return _services[paymentMethod];
        }

        public IPaymentFactory Register(string paymentMethod, IPaymentService service)
        {
            if(_services.TryAdd(paymentMethod, service) is false)
            {
                _services[paymentMethod] = service;
            }

            return this;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Section11.Entities;
using Section11.ValueType;

namespace Section11.Interfaces
{
    public interface IClientService
    {
        public void Register(Client client);

        public void Modify(Client client);

        public void Remove(CPF cpf);

        public Client Recover(CPF cpf);

        public IEnumerable<Client> RecoverAll();
    }
}

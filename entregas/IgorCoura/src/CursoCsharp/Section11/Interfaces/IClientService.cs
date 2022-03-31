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
        void Register(Client client);

        void Modify(Client client);

        void Remove(CPF cpf);

        Client Recover(CPF cpf);

        IEnumerable<Client> RecoverAll();
    }
}

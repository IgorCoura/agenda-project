using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Section11.Entities;
using Section11.ValueType;

namespace Section11.Interfaces
{
    public interface IClientRepository
    {
        void Create(Client e);

        void Update(Client e);

        void Delete(CPF cpf);

        Client Get(CPF cpf);

        IEnumerable<Client> GetAll();
    }
}

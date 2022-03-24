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
        public void Create(Client e);

        public void Update(Client e);

        public void Delete(CPF cpf);

        public Client get(CPF cpf);

        public IEnumerable<Client> getAll();
    }
}

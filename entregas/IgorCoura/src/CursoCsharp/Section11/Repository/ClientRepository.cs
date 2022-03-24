using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Section11.Entities;
using Section11.Interfaces;
using Section11.ValueType;

namespace Section11.Repository
{
    public class ClientRepository: IClientRepository
    {
        private List<Client> _entities;

        public ClientRepository()
        {
            _entities = new List<Client>();
        }
        public void Create(Client e)
        {
            _entities.Add(e);
        }

        public void Update(Client e)
        {
            _entities[_entities.FindIndex(x => x.Cpf == e.Cpf)] = e;
        }

        public void Delete(CPF cpf)
        {
            _entities.RemoveAll(x => x.Cpf == cpf);
        }

        public Client get(CPF cpf)
        {
            return _entities.Find(x => x.Cpf == cpf) ?? throw new Exception($"Client with cpf {cpf}, not exist.");
        }

        public IEnumerable<Client> getAll()
        {
            return _entities;
        }
    }
}

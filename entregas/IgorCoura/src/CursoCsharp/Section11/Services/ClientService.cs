using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Section11.Entities;
using Section11.Interfaces;
using Section11.ValueType;

namespace Section11.Services
{
    public class ClientService: IClientService
    {
        private readonly IClientRepository _clientRepository;

        public ClientService(IClientRepository repository)
        {
            _clientRepository = repository;
        }

        public void Register(Client client)
        {
            _clientRepository.Create(client);
        }

        public void Modify(Client client)
        {
            _clientRepository.Update(client);
        }

        public void Remove(CPF cpf)
        {
            _clientRepository.Delete(cpf);
        }

        public Client Recover(CPF cpf)
        {
            return _clientRepository.get(cpf);
        }

        public IEnumerable<Client> RecoverAll()
        {
            return _clientRepository.getAll();
        }
    }
}

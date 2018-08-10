using AutoMapper;
using Bank.Application.Features.Clients.Commands;
using Bank.Application.Features.Clients.Queries;
using Bank.Domain.Exceptions;
using Bank.Domain.Features.Clients;
using System.Linq;

namespace Bank.Application.Features.Clients
{
    public class ClientService : IClientService
    {
        private IClientRepository _clientRepository;

        public ClientService(IClientRepository clientRepository)
        {
            _clientRepository = clientRepository;
        }
        public long Add(ClientRegisterCommand clientCmd)
        {
            var client = Mapper.Map<ClientRegisterCommand, Client>(clientCmd);

            var newClient = _clientRepository.Add(client);

            return newClient.Id;
        }

        public IQueryable<Client> GetAll(ClientQuery query)
        {
            IQueryable<Client> result;

            if (query == null)
                result = _clientRepository.GetAll(null);
            else
                result = _clientRepository.GetAll(query.Quantity);

            return result;
        }

        public Client GetById(long id)
        {
            if (id < 1)
                throw new NotFoundException();

            var client = _clientRepository.GetById(id) ?? throw new NotFoundException();

            return client;
        }

        public bool Remove(ClientRemoveCommand cmd)
        {
            var client = _clientRepository.GetById(cmd.Id) ?? throw new NotFoundException();

            return _clientRepository.Remove(client);
        }

        public bool Update(ClientUpdateCommand cmd)
        {
            var clientDb = _clientRepository.GetById(cmd.Id) ?? throw new NotFoundException();

            Mapper.Map(cmd, clientDb);

            return _clientRepository.Update(clientDb);
        }
    }
}

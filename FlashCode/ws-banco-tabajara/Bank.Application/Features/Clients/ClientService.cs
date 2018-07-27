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
        public long Add(Client entity)
        {
            entity = _clientRepository.Add(entity);

            return entity.Id;
        }

        public IQueryable<Client> GetAll(int? quantity = null)
        {
            return _clientRepository.GetAll(quantity);
        }

        public Client GetById(long id)
        {
            var client = _clientRepository.GetById(id) ?? throw new NotFoundException();

            return _clientRepository.GetById(id);
        }

        public bool Remove(Client entity)
        {
            var client = _clientRepository.GetById(entity.Id) ?? throw new NotFoundException();

            return _clientRepository.Remove(entity);
        }

        public bool Update(Client entity)
        {
            var clientDb = _clientRepository.GetById(entity.Id) ?? throw new NotFoundException();

            clientDb.Name = entity.Name;
            clientDb.Rg = entity.Rg;
            clientDb.Cpf = entity.Cpf;
            clientDb.Birthday = entity.Birthday;

            return _clientRepository.Update(clientDb);
        }
    }
}

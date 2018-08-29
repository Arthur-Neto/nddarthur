using Bank.Application.Features.Clients.Commands;
using Bank.Application.Features.Clients.Queries;
using Bank.Domain.Features.Clients;
using System.Linq;

namespace Bank.Application.Features.Clients
{
    public interface IClientService
    {
        long Add(ClientRegisterCommand cmd);

        bool Update(ClientUpdateCommand cmd);

        Client GetById(long id);

        IQueryable<Client> GetAll(ClientQuery query);

        bool Remove(ClientRemoveCommand cmd);
    }
}

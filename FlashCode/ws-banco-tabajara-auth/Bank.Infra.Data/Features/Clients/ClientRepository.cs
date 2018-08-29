using Bank.Domain.Features.Clients;
using Bank.Infra.Data.Base;

namespace Bank.Infra.Data.Features.Clients
{
    public class ClientRepository : AbstractRepository<Client>, IClientRepository
    {
        public ClientRepository(BankContext context) : base(context)
        {
        }
    }
}

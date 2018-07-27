using Bank.Domain.Base;
using System;

namespace Bank.Domain.Features.Clients
{
    public class Client : Entity
    {
        public string Cpf { get; set; }
        public string Name { get; set; }
        public string Rg { get; set; }
        public DateTime Birthday { get; set; }
    }
}

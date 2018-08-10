using System;

namespace Bank.Application.Features.Clients.ViewModels
{
    public class ClientViewModel
    {
        public long Id { get; set; }
        public string Cpf { get; set; }
        public string Name { get; set; }
        public string Rg { get; set; }
        public DateTime Birthday { get; set; }
    }
}

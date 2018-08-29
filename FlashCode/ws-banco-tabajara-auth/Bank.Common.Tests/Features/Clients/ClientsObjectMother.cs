using Bank.Domain.Features.Clients;
using System;
using System.Diagnostics.CodeAnalysis;

namespace Bank.Common.Tests.Features.ObjectMothers
{
    [ExcludeFromCodeCoverage]
    public static partial class ObjectMother
    {
        public static Client GetClientValid()
        {
            return new Client()
            {
                Id = 1,
                Birthday = DateTime.Now,
                Cpf = "123123123",
                Name = "Fulano",
                Rg = "123123123"
            };
        }
    }
}

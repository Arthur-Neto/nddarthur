using Pizzaria.Dominio.Features.Clientes;
using Pizzaria.Dominio.Features.Enderecos;
using System;

namespace Pizzaria.Common.Testes.Features
{
    public static partial class ObjetoMae
    {
        public static Cliente ObterClienteValidoComCpf()
        {
            return new Cliente
            {
                CPF = "11111111111",
                DataDeNascimento = DateTime.Now,
                Endereco = new Endereco() { Bairro = "1", Cep = "1", Cidade = "1", Estado = "1", Numero = 1, Rua = "1" },
                Nome = "Fulano Cpf",
                Telefone = "988889999"
            };
        }

        public static Cliente ObterClienteValidoComCpfSemVinculos()
        {
            return new Cliente
            {
                CPF = "11111111111",
                DataDeNascimento = DateTime.Now,
                Endereco = new Endereco() { Bairro = "1", Cep = "1", Cidade = "1", Estado = "1", Numero = 1, Rua = "1" },
                Nome = "Fulano Cpf",
                Telefone = "988889999",
            };
        }

        public static Cliente ObterClienteValidoComCnpj()
        {
            return new Cliente
            {
                CNPJ = "11111111111111",
                DataDeNascimento = new DateTime(),
                Endereco = new Endereco() { Id = 1, Bairro = "1", Cep = "1", Cidade = "1", Estado = "1", Numero = 1, Rua = "1" },
                Nome = "Fulano Cnpj",
                Telefone = "988889999"
            };
        }

        public static Cliente ObterClienteInvalidoSemCpfECnpj()
        {
            return new Cliente
            {
                DataDeNascimento = new DateTime(),
                Endereco = new Endereco() { Id = 1, Bairro = "1", Cep = "1", Cidade = "1", Estado = "1", Numero = 1, Rua = "1" },
                Nome = "Fulano Cnpj",
                Telefone = "988889999"
            };
        }

        public static Cliente ObterClienteInvalidoSemDataNascimento()
        {
            return new Cliente
            {
                CPF = "11111111111",
                Endereco = new Endereco() { Id = 1, Bairro = "1", Cep = "1", Cidade = "1", Estado = "1", Numero = 1, Rua = "1" },
                Nome = "Fulano Cnpj",
                Telefone = "988889999"
            };
        }

        public static Cliente ObterClienteInvalidoSemEndereco()
        {
            return new Cliente
            {
                CPF = "11111111111",
                DataDeNascimento = new DateTime(),
                Endereco = null,
                Nome = "Fulano Cpf",
                Telefone = "988889999"
            };
        }

        public static Cliente ObterClienteInvalidoSemNome()
        {
            return new Cliente
            {
                CPF = "11111111111",
                DataDeNascimento = new DateTime(),
                Endereco = new Endereco() { Id = 1, Bairro = "1", Cep = "1", Cidade = "1", Estado = "1", Numero = 1, Rua = "1" },
                Telefone = "988889999"
            };
        }

        public static Cliente ObterClienteInvalidoSemTelefone()
        {
            return new Cliente
            {
                CPF = "11111111111",
                DataDeNascimento = new DateTime(),
                Endereco = new Endereco() { Id = 1 },
                Nome = "Fulano Cpf",
            };
        }
    }
}

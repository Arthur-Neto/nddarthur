using Pizzaria.Dominio.Features.Enderecos;

namespace Pizzaria.Common.Testes.Features
{
    public static partial class ObjetoMae
    {
        public static Endereco ObterEnderecoValido()
        {
            return new Endereco
            {
                Bairro = "Centro",
                Cep = "88888888",
                Cidade = "Lages",
                Estado = "SC",
                Numero = 1234,
                Rua = "Alguma"
            };
        }

        public static Endereco ObterEnderecoValidoSemVinculos()
        {
            return new Endereco
            {
                Bairro = "Centro",
                Cep = "88888888",
                Cidade = "Lages",
                Estado = "SC",
                Numero = 1234,
                Rua = "Alguma"
            };
        }

        public static Endereco ObterEnderecoInvalidoSemBairro()
        {
            return new Endereco
            {
                Cep = "88888888",
                Cidade = "Lages",
                Estado = "SC",
                Numero = 1234,
                Rua = "Alguma"
            };
        }

        public static Endereco ObterEnderecoInvalidoSemCep()
        {
            return new Endereco
            {
                Bairro = "Centro",
                Cidade = "Lages",
                Estado = "SC",
                Numero = 1234,
                Rua = "Alguma"
            };
        }

        public static Endereco ObterEnderecoInvalidoSemCidade()
        {
            return new Endereco
            {
                Bairro = "Centro",
                Cep = "88888888",
                Estado = "SC",
                Numero = 1234,
                Rua = "Alguma"
            };
        }

        public static Endereco ObterEnderecoInvalidoSemEstado()
        {
            return new Endereco
            {
                Bairro = "Centro",
                Cep = "88888888",
                Cidade = "Lages",
                Numero = 1234,
                Rua = "Alguma"
            };
        }

        public static Endereco ObterEnderecoInvalidoSemNumero()
        {
            return new Endereco
            {
                Bairro = "Centro",
                Cep = "88888888",
                Cidade = "Lages",
                Estado = "SC",
                Rua = "Alguma"
            };
        }

        public static Endereco ObterEnderecoInvalidoSemRua()
        {
            return new Endereco
            {
                Bairro = "Centro",
                Cep = "88888888",
                Cidade = "Lages",
                Estado = "SC",
                Numero = 1234,
            };
        }
    }
}

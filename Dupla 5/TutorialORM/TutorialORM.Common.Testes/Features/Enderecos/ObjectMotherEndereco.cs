using TutorialORM.Dominio.Features.Enderecos;

namespace TutorialORM.Common.Testes.Features
{
    public static partial class ObjectMother
    {
        public static Endereco ObterEnderecoValido()
        {
            return new Endereco()
            {
                Bairro = "Sagrado",
                Cidade = "Lages",
                Complemento = "Nao tem",
                Logradouro = "Rua nao sei",
                Numero = 123,
                UF = "SC"
            };
        }

        public static Endereco ObterEnderecoComBairroVazio()
        {
            return new Endereco()
            {
                Bairro = "",
                Cidade = "Lages",
                Complemento = "Nao tem",
                Logradouro = "Rua nao sei",
                Numero = 123,
                UF = "SC"
            };
        }

        public static Endereco ObterEnderecoComCidadeVazia()
        {
            return new Endereco()
            {
                Bairro = "Sagrado",
                Cidade = "",
                Complemento = "Nao tem",
                Logradouro = "Rua nao sei",
                Numero = 123,
                UF = "SC"
            };
        }

        public static Endereco ObterEnderecoComLogradouroVazio()
        {
            return new Endereco()
            {
                Bairro = "Sagrado",
                Cidade = "Lages",
                Complemento = "Nao tem",
                Logradouro = "",
                Numero = 123,
                UF = "SC"
            };
        }

        public static Endereco ObterEnderecoComNumeroInvalido()
        {
            return new Endereco()
            {
                Bairro = "Sagrado",
                Cidade = "Lages",
                Complemento = "Nao tem",
                Logradouro = "Rua nao sei",
                Numero = 0,
                UF = "SC"
            };
        }

        public static Endereco ObterEnderecoComUFVazio()
        {
            return new Endereco()
            {
                Bairro = "Sagrado",
                Cidade = "Lages",
                Complemento = "Nao tem",
                Logradouro = "Rua nao sei",
                Numero = 123,
                UF = ""
            };
        }
    }
}

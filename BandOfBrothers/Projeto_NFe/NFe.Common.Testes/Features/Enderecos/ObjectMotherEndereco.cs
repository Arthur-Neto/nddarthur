using NFe.Dominio.Features.Enderecos;

namespace NFe.Common.Testes.Features
{
    public static partial class ObjectMother
    {
        public static Endereco ObterEnderecoValido()
        {
            return new Endereco
            {
                Id = 1,
                Bairro = "Sagrado Coração de Jesus",
                Estado = "SC",
                Logradouro = "Coronel Zeca Athanasio",
                Municipio = "Lages",
                Numero = "547",
                Pais = "Brasil"
            };
        }

        public static Endereco ObterEnderecoValidoSemVinculo()
        {
            return new Endereco
            {
                Id = 2,
                Bairro = "Sagrado Coração de Jesus",
                Estado = "SC",
                Logradouro = "Coronel Zeca Athanasio",
                Municipio = "Lages",
                Numero = "547",
                Pais = "Brasil"
            };
        }

        public static Endereco ObterEnderecoBairroVazio()
        {
            return new Endereco
            {
                Id = 1,
                Bairro = "",
                Estado = "SC",
                Logradouro = "Coronel Zeca Athanasio",
                Municipio = "Lages",
                Numero = "547",
                Pais = "Brasil"
            };
        }

        public static Endereco ObterEnderecoEstadoVazio()
        {
            return new Endereco
            {
                Id = 1,
                Bairro = "Sagrado Coração de Jesus",
                Estado = "",
                Logradouro = "Coronel Zeca Athanasio",
                Municipio = "Lages",
                Numero = "547",
                Pais = "Brasil"
            };
        }

        public static Endereco ObterEnderecoLogradouroVazio()
        {
            return new Endereco
            {
                Id = 1,
                Bairro = "Sagrado Coração de Jesus",
                Estado = "SC",
                Logradouro = "",
                Municipio = "Lages",
                Numero = "547",
                Pais = "Brasil"
            };
        }

        public static Endereco ObterEnderecoMunicipioVazio()
        {
            return new Endereco
            {
                Id = 1,
                Bairro = "Sagrado Coração de Jesus",
                Estado = "Santa Catarina",
                Logradouro = "Coronel Zeca Athanasio",
                Municipio = "",
                Numero = "547",
                Pais = "Brasil"
            };
        }

        public static Endereco ObterEnderecoNumeroVazio()
        {
            return new Endereco
            {
                Id = 1,
                Bairro = "Sagrado Coração de Jesus",
                Estado = "Santa Catarina",
                Logradouro = "Coronel Zeca Athanasio",
                Municipio = "Lages",
                Numero = "",
                Pais = "Brasil"
            };
        }

        public static Endereco ObterEnderecoPaisVazio()
        {
            return new Endereco
            {
                Id = 1,
                Bairro = "Sagrado Coração de Jesus",
                Estado = "Santa Catarina",
                Logradouro = "Coronel Zeca Athanasio",
                Municipio = "Lages",
                Numero = "547",
                Pais = ""
            };
        }

        public static Endereco ObterEnderecoIdInvalido()
        {
            return new Endereco
            {
                Id = 0,
                Bairro = "Sagrado Coração de Jesus",
                Estado = "Santa Catarina",
                Logradouro = "Coronel Zeca Athanasio",
                Municipio = "Lages",
                Numero = "547",
                Pais = "Brasil"
            };
        }
    }
}

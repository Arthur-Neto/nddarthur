using Projeto_NFe.Domain.Funcionalidades.Enderecos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto_NFe.Common.Tests.Funcionalidades
{
    public static partial class ObjectMother
    {
        public static Endereco PegarEnderecoValido()
        {
            return new Endereco()
            {
                Bairro = "Amaciota",
                Estado = "SC",
                Logradouro = "02",
                Municipio = "Lages",
                Numero = 803,
                Pais = "Brasil"
            };
        }

        public static Endereco PegarEnderecoSemBairro()
        {
            return new Endereco()
            {
                Bairro = "",
                Estado = "SC",
                Logradouro = "02",
                Municipio = "Lages",
                Numero = 803,
                Pais = "Brasil"
            };
        }

        public static Endereco PegarEnderecoSemMunicipio()
        {
            return new Endereco()
            {
                Bairro = "Santa Catarina",
                Estado = "SC",
                Logradouro = "02",
                Municipio = "",
                Numero = 803,
                Pais = "Brasil"
            };
        }

        public static Endereco PegarEnderecoSemPais()
        {
            return new Endereco()
            {
                Bairro = "Santa Catarina",
                Estado = "SC",
                Logradouro = "02",
                Municipio = "Lages",
                Numero = 803,
                Pais = ""
            };
        }

        public static Endereco PegarEnderecoSemEstado()
        {
            return new Endereco()
            {
                Bairro = "Santa Catarina",
                Estado = "",
                Logradouro = "02",
                Municipio = "Lages",
                Numero = 803,
                Pais = "Brasil"
            };
        }

        public static Endereco PegarEnderecoSemLogradouro()
        {
            return new Endereco()
            {
                Bairro = "Santa Catarina",
                Estado = "SC",
                Logradouro = "",
                Municipio = "Lages",
                Numero = 803,
                Pais = "Brasil"
            };
        }

        public static Endereco PegarEnderecoSemNumero()
        {
            return new Endereco()
            {
                Bairro = "Santa Catarina",
                Estado = "SC",
                Logradouro = "logradouro",
                Municipio = "Lages",
                Pais = "Brasil"
            };
        }
    }
}

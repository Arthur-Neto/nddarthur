using Projeto_NFe.Domain.Funcionalidades.Documentos;
using Projeto_NFe.Domain.Funcionalidades.Documentos.CNPJs;
using Projeto_NFe.Domain.Funcionalidades.Emitentes;
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
        public static Emitente PegarEmitenteValido(Endereco endereco, CNPJ cnpj)
        {
            return new Emitente
            {
                Id = 10,
                NomeFantasia = "nome fantasia",
                RazaoSocial = "razão social",
                CNPJ = cnpj,
                InscricaoEstadual = "478648383",
                InscricaoMunicipal = "478548383",
                Endereco = endereco
            };
        }

        public static Emitente PegarEmitenteValidoSemDependencias()
        {
            return new Emitente
            {
                Id = 10,
                NomeFantasia = "nome fantasia",
                RazaoSocial = "razão social",
                CNPJ = new Documento("99.327.235/0001-50", TipoDocumento.CNPJ),
                InscricaoEstadual = "478648383",
                InscricaoMunicipal = "478548383",
                Endereco = new Endereco()
                {
                    Logradouro = "Logradouro",
                    Numero = 1,
                    Bairro = "Bairro",
                    Municipio = "Município",
                    Estado = "Estado",
                    Pais = "País"
                }
            };
        }

        public static Emitente PegarEmitenteSemNome(Endereco endereco, CNPJ cnpj)
        {
            return new Emitente
            {
                Id = 10,
                NomeFantasia ="",
                RazaoSocial = "razão social",
                CNPJ = cnpj,
                InscricaoEstadual = "478648383",
                InscricaoMunicipal = "478548383",
                Endereco = endereco
            };
        }

        public static Emitente PegarEmitenteSemRazaoSocial(Endereco endereco, CNPJ cnpj)
        {
            return new Emitente
            {
                Id = 10,
                NomeFantasia = "nome fantasia",
                RazaoSocial = "",
                CNPJ = cnpj,
                InscricaoEstadual = "478648383",
                InscricaoMunicipal = "478548383",
                Endereco = endereco
            };
        }

        public static Emitente PegarEmitenteSemCNPJ(Endereco endereco)
        {
            return new Emitente
            {
                Id = 10,
                NomeFantasia = "nome fantasia",
                RazaoSocial = "razão social",
                CNPJ = null,
                InscricaoEstadual = "478648383",
                InscricaoMunicipal = "478548383",
                Endereco = endereco
            };
        }

        public static Emitente PegarEmitenteSemInscricaoEstadual(Endereco endereco, CNPJ cnpj)
        {
            return new Emitente
            {
                Id = 10,
                NomeFantasia = "nome fantasia",
                RazaoSocial = "razão social",
                CNPJ = cnpj,
                InscricaoEstadual = "",
                InscricaoMunicipal = "478548383",
                Endereco = endereco
            };
        }

        public static Emitente PegarEmitenteSemInscricaoMunicipal(Endereco endereco, CNPJ cnpj)
        {
            return new Emitente
            {
                Id = 10,
                NomeFantasia = "nome fantasia",
                RazaoSocial = "razão social",
                CNPJ = cnpj,
                InscricaoEstadual = "478648383",
                InscricaoMunicipal = "",
                Endereco = endereco
            };
        }

        public static Emitente PegarEmitenteSemEndereco(CNPJ cnpj)
        {
            return new Emitente
            {
                Id = 10,
                NomeFantasia = "nome fantasia",
                RazaoSocial = "razão social",
                CNPJ = cnpj,
                InscricaoEstadual = "478648383",
                InscricaoMunicipal = "478548383",
                Endereco = null
            };
        }

        public static Emitente PegarEmitenteComNomeDe3Letras(Endereco endereco, CNPJ cnpj)
        {
            return new Emitente
            {
                Id = 10,
                NomeFantasia = "nom",
                RazaoSocial = "razão social",
                CNPJ = cnpj,
                InscricaoEstadual = "478648383",
                InscricaoMunicipal = "478548383",
                Endereco = endereco
            };
        }

        public static Emitente PegarEmitenteComRazaoSocialDe3Letras(Endereco endereco, CNPJ cnpj)
        {
            return new Emitente
            {
                Id = 10,
                NomeFantasia = "nome fantasia",
                RazaoSocial = "raz",
                CNPJ = cnpj,
                InscricaoEstadual = "478648383",
                InscricaoMunicipal = "478548383",
                Endereco = endereco
            };
        }

        public static Emitente PegarEmitenteComInscricaoEstadualInvalida(Endereco endereco, CNPJ cnpj)
        {
            return new Emitente
            {
                Id = 10,
                NomeFantasia = "nome fantasia",
                RazaoSocial = "razao social",
                CNPJ = cnpj,
                InscricaoEstadual = "2137653456547654",
                InscricaoMunicipal = "478548383",
                Endereco = endereco
            };
        }

        public static Emitente PegarEmitenteComInscricaoEstadualComLetras(Endereco endereco, CNPJ cnpj)
        {
            return new Emitente
            {
                Id = 10,
                NomeFantasia = "nome fantasia",
                RazaoSocial = "razao social",
                CNPJ = cnpj,
                InscricaoEstadual = "dsasdadsa",
                InscricaoMunicipal = "478478548383",
                Endereco = endereco
            };
        }

        public static Emitente PegarEmitenteComInscricaoMunicipalComLetras(Endereco endereco, CNPJ cnpj)
        {
            return new Emitente
            {
                Id = 10,
                NomeFantasia = "nome fantasia",
                RazaoSocial = "razao social",
                CNPJ = cnpj,
                InscricaoEstadual = "478478548",
                InscricaoMunicipal = "assffaf",
                Endereco = endereco
            };
        }

    }
}

using Projeto_NFe.Domain.Funcionalidades.Destinatarios;
using Projeto_NFe.Domain.Funcionalidades.Documentos;
using Projeto_NFe.Domain.Funcionalidades.Documentos.CNPJs;
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
        public static Destinatario PegarDestinatarioValidoComDependencias(Endereco endereco, Documento documento)
        {
            return new Destinatario()
            {
                NomeRazaoSocial = "Nome",
                Documento = documento,
                InscricaoEstadual = "636.330.646.110",
                Endereco = endereco
            };

        }
        public static Destinatario PegarDestinatarioValidoComCNPJ(Endereco endereco, Documento cnpj)
        {
            return new Destinatario()
            {
                NomeRazaoSocial = "Nome",
                Documento = cnpj,
                InscricaoEstadual = "636.330.646.110",
                Endereco = endereco

            };

        }
        public static Destinatario PegarDestinatarioValidoComCNPJSemDependencias()
        {
            return new Destinatario()
            {
                NomeRazaoSocial = "Nome",
                InscricaoEstadual = "636.330.646.110",
                Documento = new Documento("99.327.235/0001-50",TipoDocumento.CNPJ),
                Endereco = new Endereco()
                {
                    Logradouro = "Logradouro",
                    Numero = 1,
                    Bairro = "Bairro",
                    Municipio = "Município",
                    Estado = "Estado",
                    Pais = "País"
                },

            };

        }

        public static Destinatario PegarDestinatarioSemNome(Endereco endereco, Documento cnpj)
        {
            return new Destinatario()
            {
                NomeRazaoSocial = "",
                Documento = cnpj,
                InscricaoEstadual = "636.330.646.110",
                Endereco = endereco
            };

        }

        public static Destinatario PegarDestinatarioSemDocumento(Endereco endereco, Documento cpf)
        {
            return new Destinatario()
            {
                NomeRazaoSocial = "Nome",
                Documento = null,
                Endereco = endereco

            };

        }

        public static Destinatario PegarDestinatarioComCNPJSemInscricaoEstadual(Endereco endereco, Documento cnpj)
        {
            return new Destinatario()
            {
                NomeRazaoSocial = "Nome",
                Documento = cnpj,
                InscricaoEstadual = "",
                Endereco = endereco
            };

        }

        public static Destinatario PegarDestinatarioComInscricaoEstadualAcimaDoPadrao(Endereco endereco, Documento cnpj)
        {
            return new Destinatario()
            {
                NomeRazaoSocial = "Nome",
                Documento = cnpj,
                InscricaoEstadual = "636.330.646.000000000",
                Endereco = endereco
            };

        }
        public static Destinatario PegarDestinatarioValidoComCPF()
        {
            return new Destinatario()
            {
                NomeRazaoSocial = "Nome",
                Documento = new Documento("603.486.029-60", TipoDocumento.CPF),
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

        public static Destinatario PegarDestinatarioSemEndereco(Endereco endereco, Documento cnpj)
        {
            return new Destinatario()
            {
                NomeRazaoSocial = "Nome",
                Documento = cnpj,
                Endereco = endereco,
                InscricaoEstadual = "636.330.646.0"
            };
        }
    }
}

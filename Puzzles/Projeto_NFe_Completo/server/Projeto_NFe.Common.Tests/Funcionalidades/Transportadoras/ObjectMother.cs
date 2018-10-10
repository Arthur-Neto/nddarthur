using Projeto_NFe.Domain.Funcionalidades.Documentos;
using Projeto_NFe.Domain.Funcionalidades.Enderecos;
using Projeto_NFe.Domain.Funcionalidades.Transportadoras;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto_NFe.Common.Tests.Funcionalidades
{
    public static partial class ObjectMother
    {
        public static Transportador PegarTransportadorValidoComDependencias(Endereco endereco, Documento documento)
        {
            return new Transportador()
            {
                NomeRazaoSocial = "Razão Social",
                InscricaoEstadual = "636.330.646.110",
                ResponsabilidadeFrete = true,
                Documento = documento,
                Endereco = endereco
            };
        }

        public static Transportador PegarTransportadorValidoSemDependencias()
        {
            return new Transportador()
            {
                NomeRazaoSocial = "Razão Social",
                InscricaoEstadual = "636.330.646.110",
                ResponsabilidadeFrete = true,
                Documento = new Documento("99.327.235/0001-50", TipoDocumento.CNPJ),
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

        public static Transportador PegarTransportadorValidoComCNPJ(Endereco endereco, Documento cnpj)
        {
            return new Transportador()
            {
                NomeRazaoSocial = "Razão Social",
                InscricaoEstadual = "636.330.646.110",
                ResponsabilidadeFrete = true,
                Documento = cnpj,
                Endereco = endereco
            };
        }

        public static Transportador PegarTransportadorValidoComCPF(Endereco endereco, Documento cpf)
        {
            return new Transportador()
            {
                NomeRazaoSocial = "Razão Social",
                InscricaoEstadual = "636.330.646.110",
                ResponsabilidadeFrete = true,
                Documento = cpf,
                Endereco = endereco
            };
        }

        public static Transportador PegarTransportadorComInscricaoEstadualAcimaDoLimite(Endereco endereco, Documento cnpj)
        {
            return new Transportador()
            {
                NomeRazaoSocial = "Razão Social",
                InscricaoEstadual = "636.330.646.11000",
                ResponsabilidadeFrete = true,
                Endereco = endereco, 
                Documento = cnpj
            };
        }


        public static Transportador PegarTransportadorSemNome(Endereco endereco, Documento cnpj)
        {
            return new Transportador()
            {
                NomeRazaoSocial = "",
                Documento = cnpj,
                InscricaoEstadual = "636.330.646.110",
                ResponsabilidadeFrete = true,
                Endereco = endereco
            };
        }

        public static Transportador PegarTransportadorSemEndereco(Endereco endereco, Documento cnpj)
        {
            return new Transportador()
            {
                NomeRazaoSocial = "Razao Social",
                InscricaoEstadual = "636.330.646.110",
                ResponsabilidadeFrete = true,
                Documento = cnpj,
                Endereco = endereco
            };
        }

        public static Transportador PegarTransportadorComInscricaoEstadualNula(Endereco endereco, Documento cnpj)
        {
            return new Transportador()
            {
                NomeRazaoSocial = "Razao Social",
                InscricaoEstadual = "",
                ResponsabilidadeFrete = true,
                Endereco = endereco,
                Documento = cnpj
            };
        }

        public static Transportador PegarTransportadorSemDocumento(Endereco endereco, Documento cnpj)
        {
            return new Transportador()
            {
                NomeRazaoSocial = "Razao Social",
                InscricaoEstadual = "636.330.646.110",
                ResponsabilidadeFrete = true,
                Endereco = endereco,
                Documento = null
            };
        }
    }
}

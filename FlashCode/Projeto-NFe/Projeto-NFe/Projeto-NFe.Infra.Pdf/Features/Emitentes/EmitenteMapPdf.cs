using DanfeSharp.Modelo;
using Projeto_NFe.Dominio.Features.Emitentes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto_NFe.Infra.Pdf.Features.Emitentes
{
    public static class EmitenteMapPdf
    {
        public static EmpresaViewModel MapParaEmitenteViewModel(Emitente emitente)
        {
            return new EmpresaViewModel()
            {
                CnpjCpf = emitente.CNPJ.ToString(),
                Email = String.Empty,
                EnderecoBairro = emitente.Endereco.Bairro,
                EnderecoCep = emitente.Endereco.Cep,
                EnderecoComplemento = String.Empty,
                EnderecoLogadrouro = emitente.Endereco.Rua,
                EnderecoNumero = emitente.Endereco.Numero.ToString(),
                EnderecoUf = emitente.Endereco.UF,
                Ie = emitente.InscricaoEstadual,
                IeSt = String.Empty,
                IM = emitente.InscricaoMunicipal,
                Municipio = emitente.Endereco.Cidade,
                NomeFantasia = emitente.NomeFantasia,
                RazaoSocial = emitente.RazaoSocial,
                Telefone = String.Empty
            };

        }
    }
}

using DanfeSharp.Modelo;
using Projeto_NFe.Dominio.Features.Destinatarios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto_NFe.Infra.Pdf.Features.Destinatarios
{
    public static class DestinatarioMapPdf
    {
        public static EmpresaViewModel MapParaDestinatarioViewModel(Destinatario destinatario)
        {
            return new EmpresaViewModel()
            {
                CnpjCpf = destinatario.Cpf != null ? destinatario.Cpf.ToString() : destinatario.Cnpj.ToString(),
                Email = String.Empty,
                EnderecoBairro = destinatario.Endereco.Bairro,
                EnderecoCep = destinatario.Endereco.Cep,
                EnderecoComplemento = String.Empty,
                EnderecoLogadrouro = destinatario.Endereco.Rua,
                EnderecoNumero = destinatario.Endereco.Numero.ToString(),
                EnderecoUf = destinatario.Endereco.UF,
                Municipio = destinatario.Endereco.Cidade,
                NomeFantasia = destinatario.Nome,
                RazaoSocial = destinatario.RazaoSocial,
                Telefone = String.Empty,
                Ie = destinatario.InscricaoEstadual,
                IM = String.Empty,
                IeSt = String.Empty
            };

        }
    }
}

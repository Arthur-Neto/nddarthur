using Projeto_NFe.Dominio.Features.Destinatarios;
using Projeto_NFe.Dominio.Features.Enderecos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Projeto_NFe.Comuns.Testes.Features.Cnpjs;
using Projeto_NFe.Comuns.Testes.Features.Cpfs;
using Projeto_NFe.Comuns.Testes.Features.Enderecos;
using Projeto_NFe.Dominio.Base;

namespace Projeto_NFe.Comuns.Testes.Features.Destinatarios
{
    public static class DestinatarioObjetoMae
    {
        public static Destinatario ObterValidoEmpresa()
        {
            return new Destinatario
            {
                ID = 1,
                Tipo = EPessoa.Juridica,
                Cnpj = CnpjObjetoMae.ObterValidoComPontosTracos(),
                InscricaoEstadual = "1124432",
                Endereco = EnderecoObjetoMae.ObterValido(),
                RazaoSocial = "LLLLLLKL",
            };
        }
        public static Destinatario ObterValidoPessoa()
        {
            return new Destinatario
            {
                ID = 1,
                Tipo = EPessoa.Fisica,
                Cpf = CpfObjetoMae.ObterValidoComPontosTracos(),
                Endereco = EnderecoObjetoMae.ObterValido(),
                Nome = "zé as",
            };
        }
    }
}

using Projeto_NFe.Dominio.Features.Enderecos;
using Projeto_NFe.Dominio.Features.Transportadores;
using Projeto_NFe.Comuns.Testes.Features.Cnpjs;
using Projeto_NFe.Comuns.Testes.Features.Cpfs;
using Projeto_NFe.Comuns.Testes.Features.Enderecos;
using Projeto_NFe.Dominio.Base;

namespace Projeto_NFe.Comuns.Testes.Features.Transportadores
{
    public static class TransportadorObjetoMae
    {
        public static Transportador ObterValidoEmpresa()
        {
            return new Transportador
            {
                ID = 1,
                Tipo = EPessoa.Juridica,
                Cnpj = CnpjObjetoMae.ObterValidoComPontosTracos(),
                Endereco = EnderecoObjetoMae.ObterValido(),
                InscricaoEstadual = "1124432",
                RazaoSocial = "razao",
                Responsabilidade_Frete = true,
                Nome =""
            };
        }

        public static Transportador ObterValidoPessoa()
        {
            return new Transportador
            {
                ID = 1,
                Tipo = EPessoa.Fisica,
                Cpf = CpfObjetoMae.ObterValidoComPontosTracos(),
                Endereco = EnderecoObjetoMae.ObterValido(),
                Nome = "zé as",
                RazaoSocial = "",
                Responsabilidade_Frete = true
            };
        }
    }
}

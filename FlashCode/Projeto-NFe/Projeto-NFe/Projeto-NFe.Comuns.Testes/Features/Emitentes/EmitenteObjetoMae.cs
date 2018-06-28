using Projeto_NFe.Dominio.Features.Emitentes;
using Projeto_NFe.Comuns.Testes.Features.Cnpjs;
using Projeto_NFe.Comuns.Testes.Features.Enderecos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto_NFe.Comuns.Testes.Features.Emitentes
{
    public static class EmitenteObjetoMae
    {
        public static Emitente ObterValido()
        {
            return new Emitente
            {
                ID = 1,
                CNPJ = CnpjObjetoMae.ObterValidoComPontosTracos(),
                Endereco = EnderecoObjetoMae.ObterValido(),
                InscricaoEstadual = "123456789",
                InscricaoMunicipal = "123456789",
                NomeFantasia = "fantasia",
                RazaoSocial = "razao"
            };
        }
    }
}

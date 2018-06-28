using Projeto_NFe.Dominio.Base;
using Projeto_NFe.Dominio.Excecoes;
using Projeto_NFe.Dominio.Features.Emitentes.Excercoes;
using Projeto_NFe.Dominio.Features.Enderecos;
using Projeto_NFe.Infra.Documentos.Features.Cnpjs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto_NFe.Dominio.Features.Emitentes
{
    public class Emitente : Entidade
    {
        public string NomeFantasia { get; set; }
        public string RazaoSocial { get; set; }
        public Cnpj CNPJ { get; set; }
        public string InscricaoEstadual { get; set; }
        public string InscricaoMunicipal { get; set; }
        public Endereco Endereco { get; set; }
        
        public override void Validar()
        {
            if(Endereco == null)
                throw new ExcecaoEnderecoEmBranco();

            Endereco.Validar();

            if (String.IsNullOrEmpty(NomeFantasia))
                throw new ExcecaoNomeEmBranco();


            if (CNPJ == null)
                throw new ExcecaoCNPJInvalido();

            CNPJ.Validar();

            if (String.IsNullOrEmpty(RazaoSocial))
                throw new ExcecaoRazaoSocialInvalida();

            if (String.IsNullOrEmpty(InscricaoEstadual))
                throw new ExcecaoInscricaoEstadualInvalido();

            if (String.IsNullOrEmpty(InscricaoMunicipal))
                throw new ExcecaoInscricaoMunicipalInvalido();
        }
    }
}

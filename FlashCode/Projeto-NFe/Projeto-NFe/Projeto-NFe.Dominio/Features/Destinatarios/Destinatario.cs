using Projeto_NFe.Dominio.Base;
using Projeto_NFe.Dominio.Excecoes;
using Projeto_NFe.Dominio.Features.Enderecos;
using Projeto_NFe.Infra.Documentos.Features.Cnpjs;
using Projeto_NFe.Infra.Documentos.Features.Cpfs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto_NFe.Dominio.Features.Destinatarios
{
    public class Destinatario : Entidade
    {
        public EPessoa Tipo { get; set; }
        public string Nome { get; set; }
        public string RazaoSocial { get; set; }
        public Cnpj Cnpj { get; set; }
        public Cpf Cpf { get; set; }
        public Endereco Endereco { get; set; }
        public string InscricaoEstadual { get; set; }

        public Destinatario()
        {

        }

        public override void Validar()
        {

            if (Endereco == null)
                throw new ExcecaoEnderecoEmBranco();
            Endereco.Validar();

            if (Tipo == EPessoa.Juridica)
            {
                if (string.IsNullOrEmpty(RazaoSocial))
                    throw new ExcecaoRazaoSocialInvalida();
                if (Cpf != null)
                    throw new ExcecaoEmpresaComCpf();
                if (Cnpj == null)
                    throw new ExcecaoCNPJInvalido();

                Cnpj.Validar();

            }
            else
            {
                if (String.IsNullOrEmpty(Nome.Trim()))
                    throw new ExcecaoNomeEmBranco();
                if (Cpf == null)
                    throw new ExcecaoCpfNaoDefinido();
                Cpf.Validar();
                if (Cnpj != null)
                    throw new ExcecaoPessoaComCnpj();
                if (!String.IsNullOrEmpty(RazaoSocial))
                    throw new ExcecaoPessoaComRazaoSocial();
                //if(!String.IsNullOrEmpty(InscricaoEstadual))
                    //throw new ExcecaoPessoaComRazaoSocial();
            }


        }
    }
}

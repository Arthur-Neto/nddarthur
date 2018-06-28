using Projeto_NFe.Dominio.Base;
using Projeto_NFe.Dominio.Features.Enderecos.Excecoes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto_NFe.Dominio.Features.Enderecos
{
    public class Endereco : Entidade
    {
        public string Cep { get; set; }

        public string Rua { get; set; }

        public long Numero { get; set; }

        public string Bairro { get; set; }

        public string Cidade { get; set; }

        public string UF { get; set; }

        public string Pais { get; set; }

        public override void Validar()
        {
            if (string.IsNullOrEmpty(Cep))
                throw new ExcecaoCepInvalido();

            if (string.IsNullOrEmpty(Rua))
                throw new ExcecaoRuaInvalida();

            if (string.IsNullOrEmpty(Bairro))
                throw new ExcecaoBairroInvalido();

            if (string.IsNullOrEmpty(Cidade))
                throw new ExcecaoCidadeInvalida();

            if (string.IsNullOrEmpty(UF))
                throw new ExcecaoUFInvalido();

            if (string.IsNullOrEmpty(Pais))
                throw new ExcecaoPaisInvalido();

            if (Numero < 1)
                throw new ExcecaoNumeroInvalido();
        }
    }
}

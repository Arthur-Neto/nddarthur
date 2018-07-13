using Pizzaria.Dominio.Base;
using Pizzaria.Dominio.Features.Produtos.Excecoes;
using System;

namespace Pizzaria.Dominio.Features.Produtos
{
    public abstract class Produto : Entidade
    {
        public string Sabor { get; set; }
        public double Valor { get; set; }
        public virtual TamanhoEnum Tamanho { get; set; }

        public Produto()
        {
        }

        public override void Validar()
        {
            if (string.IsNullOrEmpty(Sabor))
                throw new SaborInvalidoExcecao();

            if (Valor < 0.01)
                throw new ValorInvalidoExcecao();

            if (Tamanho == 0)
                throw new TamanhoInvalidoExcecao();
        }

        public override string ToString()
        {
            return String.Format("Produto: {0} - Sabor: {1} - Valor: {2} - Tamanho: {3}",this.GetType().Name, Sabor, Valor, Tamanho.ToString());
        }
    }
}
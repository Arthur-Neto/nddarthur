using Pizzaria.Dominio.Base;
using Pizzaria.Dominio.Features.ItensPedidos.Excecoes;
using Pizzaria.Dominio.Features.Pedidos;
using Pizzaria.Dominio.Features.Produtos;
using Pizzaria.Dominio.Features.Produtos.Adicionais;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Pizzaria.Dominio.Features.ItensPedidos
{
    public class ItemPedido : Entidade
    {
        public virtual ICollection<Produto> Produtos { get; set; }
        public double ValorParcial { get; set; }
        public virtual Pedido Pedido { get; set; }

        public void CalcularValorParcial()
        {
            ValorParcial = Produtos.Max(x => x.Valor);

            foreach (var item in Produtos)
            {
                if (item is Adicional)
                    ValorParcial += item.Valor;
            }

        }

        public ItemPedido()
        {
            Produtos = new List<Produto>();
        }

        public void Adicionar(params Produto[] produtos)
        {
            foreach (var produto in produtos)
            {
                if (produto != null)
                    Produtos.Add(produto);
            }
        }

        public override void Validar()
        {
            if (Produtos.Count < 1)
                throw new ListaProdutosVaziaExcecao();

            if (ValorParcial < 0.01)
                throw new ValorParcialInvalidoExcecao();

            if (Pedido == null)
                throw new PedidoNuloExcecao();
        }

        public override string ToString()
        {
            string retorno = "{0}: {1}{2}{3}";
            string nomeProduto, produto, adicional;
            double valorSabor;

            MontarToString(out nomeProduto, out produto, out valorSabor, out adicional);

            retorno = string.Format(retorno, nomeProduto, produto + " R$ " + valorSabor.ToString(), adicional, ", Valor Parcial: " + ValorParcial);
            return retorno;
        }

        private void MontarToString(out string nomeProduto, out string produto, out double valorSabor, out string adicional)
        {
            var list = Produtos.ToList();

            nomeProduto = string.Empty;
            produto = string.Empty;
            valorSabor = 0;
            adicional = string.Empty;
            foreach (var item in list)
            {

                if (item is Adicional)
                    adicional += ", Adicional: " + item.Sabor + " R$ " + item.Valor;
                else if (string.IsNullOrEmpty(produto))
                {
                    produto = item.Sabor;
                    valorSabor = item.Valor;
                    nomeProduto = item.GetType().Name.Split('_')[0];
                }
                else
                {
                    if (item.Valor > valorSabor)
                        valorSabor = item.Valor;
                    produto += "/" + item.Sabor; ;
                }

            }
        }
    }
}
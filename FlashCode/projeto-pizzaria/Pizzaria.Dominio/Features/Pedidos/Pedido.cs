using Pizzaria.Dominio.Base;
using Pizzaria.Dominio.Features.Clientes;
using Pizzaria.Dominio.Features.ItensPedidos;
using Pizzaria.Dominio.Features.Pedidos.Excecoes;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Pizzaria.Dominio.Features.Pedidos
{
    public class Pedido : Entidade
    {
        private double _valorTotal;
        public DateTime Data { get; set; }
        public virtual Cliente Cliente { get; set; }
        public TipoPagamentoEnum TipoPagamento { get; set; }
        public virtual ICollection<ItemPedido> Itens { get; set; }
        public bool NF { get; set; }
        public StatusPedidoEnum Status { get; set; }

        public double ValorTotal
        {
            get
            {
                _valorTotal = Itens.Sum(x => x.ValorParcial);
                return _valorTotal;
            }
            set => _valorTotal = value;
        }

        public Pedido()
        {
            Itens = new List<ItemPedido>();
        }

        public void AdicionarItems(params ItemPedido[] items)
        {
            foreach (var item in items)
            {
                if (item != null)
                {
                    item.CalcularValorParcial();
                    Itens.Add(item);
                }
            }
        }
        public void RemoverItem(ItemPedido itemPedido)
        {
            if (itemPedido != null)
                Itens.Remove(itemPedido);
        }

        public override void Validar()
        {
            if (Data > DateTime.Now)
                throw new DataInvalidaExcecao();

            if (Cliente == null)
                throw new ClienteInvalidoExcecao();

            if (TipoPagamento == 0)
                throw new TipoPagamentoInvalidoExcecao();

            if (Itens.Count < 1)
                throw new ListaDeProdutosVaziaExcecao();
        }

        public override string ToString()
        {
            return String.Format("Cliente: {0} - Data: {1} - Valor Total: {2} - Status: {3}", Cliente.Nome, Data, ValorTotal, Status.ToString());
        }
    }
}
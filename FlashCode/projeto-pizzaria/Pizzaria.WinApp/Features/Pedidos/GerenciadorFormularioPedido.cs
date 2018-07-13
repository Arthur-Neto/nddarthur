using Pizzaria.Aplicacao.Base;
using Pizzaria.Aplicacao.Features.Clientes;
using Pizzaria.Aplicacao.Features.Pedidos;
using Pizzaria.Aplicacao.Features.Produtos;
using Pizzaria.Dominio.Features.Pedidos;
using Pizzaria.Infra.Base;
using Pizzaria.WinApp.Base;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Pizzaria.WinApp.Features.Pedidos
{
    public class GerenciadorFormularioPedido : GerenciadorFormulario<Pedido>
    {
        private UserControlBasico<Pedido> _controle;
        private PedidoServico _pedidoServico;
        private ProdutoServico _produtoServico;
        private ClienteServico _clienteServico;

        public GerenciadorFormularioPedido(ProdutoServico produtoServico, ClienteServico clienteServico)
        {
            _produtoServico = produtoServico;
            _clienteServico = clienteServico;
            _pedidoServico = ObterServico() as PedidoServico;
        }
        public override void Atualizar()
        {
            var pedido = _controle.ObterItemSelecionado();
            if(pedido == null)
            {
                MessageBox.Show("Selecione um pedido para alterar");
                return;
            }
            FormAtualizarStatus formAtualizar = new FormAtualizarStatus(pedido);
            if(formAtualizar.ShowDialog() == DialogResult.OK)
            {
                ObterServico().Atualizar(formAtualizar.Entidade);
                IEnumerable<Pedido> entidades = ObterServico().ObterTodos();

                ObterLista().PopularListagem(entidades);
            }
        }
        public override FormCadastroBasico<Pedido> ObterDialogoCadastro()
        {

            return new FormRealizarPedido(_pedidoServico, _produtoServico, _clienteServico);
        }

        public override EstadoBotao ObterEstadoBotao()
        {
            return new EstadoBotao()
            {
                Adicionar = true,
                Atualizar = true,
                Excluir = true,
                Pesquisar = false
            };
        }

        public override UserControlBasico<Pedido> ObterLista()
        {
            if (_controle == null)
            {
                _controle = new UserControlBasico<Pedido>();
                IEnumerable<Pedido> pedidos = ObterServico().ObterTodos();

                ObterLista().PopularListagem(pedidos);
            }

            return _controle;
        }

        public override IServico<Pedido> ObterServico()
        {
            if (_pedidoServico == null)
                _pedidoServico = new PedidoServico(RepositorioIoC.RepositorioPedido);
            return _pedidoServico;
        }


        public override string ObterTitulo()
        {
            return "Cadastro de pedidos";
        }

        public override TituloBotao ObterTituloBotao()
        {
            return new TituloBotao()
            {
                Adicionar = "Adicionar pedido",
                Atualizar = "Atualizar status",
                Excluir = "Excluir pedido",
                Pesquisar = "Pesquisar pedido"
            };
        }

        public override VisibilidadeBotao ObterVisibilidadeBotao()
        {
            return new VisibilidadeBotao()
            {
                Adicionar = true,
                Atualizar = true,
                Excluir = true,
                Pesquisar = true
            };
        }
    }
}

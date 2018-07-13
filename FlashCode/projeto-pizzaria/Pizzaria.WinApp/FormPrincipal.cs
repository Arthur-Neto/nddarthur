using Pizzaria.Aplicacao.Features.Clientes;
using Pizzaria.Aplicacao.Features.Produtos;
using Pizzaria.Infra.Base;
using Pizzaria.WinApp.Base;
using Pizzaria.WinApp.Features.Clientes;
using Pizzaria.WinApp.Features.Pedidos;
using Pizzaria.WinApp.Features.Produtos;
using System;
using System.Windows.Forms;

namespace ExemploProjeto.WinApp
{
    public partial class FormPrincipal : Form
    {
        GerenciadorFormularioPedido pedidoGerenciadorForm;
        GerenciadorFormularioCliente clienteGerenciadorForm;
        GerenciadorFormularioProduto produtoGerenciadorForm;

        ProdutoServico servicoProduto;
        ClienteServico servicoCliente;

        private dynamic _manager;

        public FormPrincipal()
        {
            InitializeComponent();

            servicoProduto = new ProdutoServico(RepositorioIoC.RepositorioProduto);
            servicoCliente = new ClienteServico(RepositorioIoC.RepositorioCliente);

            pedidoGerenciadorForm = new GerenciadorFormularioPedido(servicoProduto, servicoCliente);

            getCadastro(pedidoGerenciadorForm);
        }

        private void getCadastro(dynamic manager)
        {
            _manager = manager;

            toolStripLabelTipoCadastro.Text = _manager.ObterTitulo();

            UserControl listagem = _manager.ObterLista();

            TituloBotao buttonsTitle = _manager.ObterTituloBotao();
            VisibilidadeBotao buttonsVisibility = _manager.ObterVisibilidadeBotao();
            EstadoBotao buttonsStatus = _manager.ObterEstadoBotao();

            AdjustDisplayedButton(buttonAdicionar, buttonsTitle.Adicionar, buttonsStatus.Adicionar, buttonsVisibility.Adicionar);
            AdjustDisplayedButton(buttonAtualizar, buttonsTitle.Atualizar, buttonsStatus.Atualizar, buttonsVisibility.Atualizar);
            AdjustDisplayedButton(buttonExcluir, buttonsTitle.Excluir, buttonsStatus.Excluir, buttonsVisibility.Excluir);

            listagem.Dock = DockStyle.Fill;

            panelControl.Controls.Clear();

            panelControl.Controls.Add(listagem);
        }

        private void AdjustDisplayedButton(ToolStripButton button, string title, bool enabled, bool visible)
        {
            button.Text = title;
            button.Enabled = enabled;
            button.Visible = visible;
        }

        private void toolStripButtonAdicionar_Click(object sender, EventArgs e)
        {
            this._manager.Adicionar();
        }

        private void toolStripButtonAtualizar_Click(object sender, EventArgs e)
        {
            this._manager.Atualizar();
        }

        private void toolStripButtonExcluir_Click(object sender, EventArgs e)
        {
            this._manager.Excluir();
        }

        private void pedidoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (pedidoGerenciadorForm == null)
                pedidoGerenciadorForm = new GerenciadorFormularioPedido(servicoProduto, servicoCliente);
            getCadastro(pedidoGerenciadorForm);
        }

        private void clienteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (clienteGerenciadorForm == null)
                clienteGerenciadorForm = new GerenciadorFormularioCliente(servicoCliente);
            getCadastro(clienteGerenciadorForm);
        }

        private void produtoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (produtoGerenciadorForm == null)
                produtoGerenciadorForm = new GerenciadorFormularioProduto(servicoProduto);
            getCadastro(produtoGerenciadorForm);
        }
    }
}

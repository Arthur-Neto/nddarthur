using ArthurProva.WinApp.Base;
using ArthurProva.WinApp.Features.CompromissoModule;
using ArthurProva.WinApp.Features.ContatoModule;
using System.Windows.Forms;

namespace ArthurProva.WinApp
{
    public partial class FormPrincipal : Form
    {
        private dynamic _manager;

        public FormPrincipal()
        {
            InitializeComponent();
        }

        private void getCadastro(dynamic manager)
        {
            _manager = manager;

            toolStripLabelTipoCadastro.Text = _manager.ObterTitulo();

            UserControl listagem = _manager.ObterLista();

            TituloBotao buttonsTitle = _manager.ObterTituloBotao();
            VisibilidadeBotao buttonsVisibility = _manager.ObterVisibilidadeBotao();
            EstadoBotao buttonsStatus = _manager.ObterEstadoBotao();

            AdjustDisplayedButton(toolStripButtonAdicionar, buttonsTitle.Adicionar, buttonsStatus.Adicionar, buttonsVisibility.Adicionar);
            AdjustDisplayedButton(toolStripButtonAtualizar, buttonsTitle.Atualizar, buttonsStatus.Atualizar, buttonsVisibility.Atualizar);
            AdjustDisplayedButton(toolStripButtonExcluir, buttonsTitle.Excluir, buttonsStatus.Excluir, buttonsVisibility.Excluir);

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

        private void toolStripButtonAdicionar_Click(object sender, System.EventArgs e)
        {
            this._manager.Adicionar();
        }

        private void toolStripButtonAtualizar_Click(object sender, System.EventArgs e)
        {
            this._manager.Atualizar();
        }

        private void toolStripButtonExcluir_Click(object sender, System.EventArgs e)
        {
            this._manager.Excluir();
        }

        private void contatoToolStripMenuItem_Click(object sender, System.EventArgs e)
        {
            getCadastro(ContatoGerenciadorFormulario.ObterInstancia());
        }

        private void compromissoToolStripMenuItem_Click(object sender, System.EventArgs e)
        {
            getCadastro(CompromissoGerenciadorFormulario.ObterInstancia());
        }
    }
}

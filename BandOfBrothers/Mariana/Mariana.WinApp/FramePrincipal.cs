using Mariana.WinApp.Features.DisciplinaModule;
using Mariana.WinApp.Features.MateriaModule;
using Mariana.WinApp.Features.QuestaoModule;
using Mariana.WinApp.Features.SerieModule;
using Mariana.WinApp.Features.TesteModule;
using Mariana.WinApp.Nucleo;
using System;
using System.IO;
using System.Windows.Forms;

namespace Mariana.WinApp
{
    public partial class FramePrincipal : Form
    {
        private dynamic _manager;

        public FramePrincipal()
        {
            InitializeComponent();
        }

        private void getCadastro(dynamic manager)
        {
            _manager = manager;

            lblTipoCadastro.Text = _manager.ObterTitulo();

            if (tbPesquisar.Visible == false)
            {
                tbPesquisar.Enabled = true;
                tbPesquisar.Visible = true;
            }

            UserControl listagem = _manager.ObterLista();

            TituloBotao buttonsTitle = _manager.ObterTituloBotao();
            VisibilidadeBotao buttonsVisibility = _manager.ObterVisibilidadeBotao();
            EstadoBotao buttonsStatus = _manager.ObterEstadoBotao();

            AdjustDisplayedButton(btnAdicionar, buttonsTitle.Adicionar, buttonsStatus.Adicionar, buttonsVisibility.Adicionar);
            AdjustDisplayedButton(btnAtualizar, buttonsTitle.Atualizar, buttonsStatus.Atualizar, buttonsVisibility.Atualizar);
            AdjustDisplayedButton(btnExcluir, buttonsTitle.Excluir, buttonsStatus.Excluir, buttonsVisibility.Excluir);
            AdjustDisplayedButton(btnPesquisar, buttonsTitle.Pesquisar, buttonsStatus.Pesquisar, buttonsVisibility.Pesquisar);

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

        private void disciplinasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            getCadastro(DisciplinaGerenciadorFormulario.ObterInstancia());
        }

        private void materiaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            getCadastro(MateriaGerenciadorFormulario.ObterInstancia());
        }

        private void btnAdicionar_Click(object sender, EventArgs e)
        {
            this._manager.Adicionar();
        }

        private void btnAtualizar_Click(object sender, EventArgs e)
        {
            this._manager.Atualizar();
        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            this._manager.Excluir();
        }

        private void serieToolStripMenuItem_Click(object sender, EventArgs e)
        {
            getCadastro(SerieGerenciadorFormulario.ObterInstancia());
            tbPesquisar.Visible = false;
            tbPesquisar.Enabled = true;
        }

        private void questoesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            getCadastro(QuestaoGerenciadorFormulario.ObterInstancia());
        }

        private void exerciciosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            getCadastro(TesteGerenciadorFormulario.ObterInstancia());
            pDFToolStripMenuItem.Enabled = true;
            cSVToolStripMenuItem.Enabled = true;
            xMLToolStripMenuItem.Enabled = true;
        }

        private void sairToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void pDFToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                var _testeGerenciador = TesteGerenciadorFormulario.ObterInstancia();

                _testeGerenciador.GerarPDF();
            }
            catch (NullReferenceException)
            {
                MessageBox.Show("Deve selecionar um teste na lista");
            }
            catch (IOException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void cSVToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFile = new SaveFileDialog();
            saveFile.Filter = "CSV File|*.csv";
            saveFile.Title = "Salve o Arquivo CSV";
            saveFile.ShowDialog();

            var _testeGerenciador = TesteGerenciadorFormulario.ObterInstancia();

            _testeGerenciador.GerarCSV(saveFile.FileName);
        }

        private void xMLToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFile = new SaveFileDialog();
            saveFile.Filter = "XML File|*.xml";
            saveFile.Title = "Salve o Arquivo XML";
            saveFile.ShowDialog();

            var _testeGerenciador = TesteGerenciadorFormulario.ObterInstancia();

            _testeGerenciador.GerarXML(saveFile.FileName);
        }

        private void btnPesquisar_Click(object sender, EventArgs e)
        {
            _manager.Pesquisar(tbPesquisar.Text);
        }
    }
}

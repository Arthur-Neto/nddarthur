using GeradorTestes.Cadastros;
using GeradorTestes.Cadastros.Disciplinas;
using GeradorTestes.Cadastros.Matérias;
using GeradorTestes.Cadastros.Questões;
using GeradorTestes.Cadastros.Series;
using GeradorTestes.Cadastros.Testes;
using GeradorTestes.Servicos;
using GeradorTestes.UserControls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GeradorTestes
{
    public partial class Principal : Form
    {

        private DisciplinaServico _disciplinaService;
        private SerieServico _serieService;
        private MateriaServico _materiaServico = new MateriaServico();
        private GerenciadorFormulario _gerente;
        
        public Principal()
        {
            InitializeComponent();
            _serieService = new SerieServico();
            _disciplinaService = new DisciplinaServico();

        }
        private void disciplinaMenuItem_Click(object sender, EventArgs e)
        {
            _gerente = new DisciplinaGerenciadorFormulario();
            CarregarCadastro(_gerente);

        }

        private void serieToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _gerente = new SerieGerenciadorFormulario();
            CarregarCadastro(_gerente);

        }

        private void Principal_Load(object sender, EventArgs e)
        {

        }

        private void sairToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void CarregarCadastro(GerenciadorFormulario gerenciador)
        {
            _gerente = gerenciador;
            AtivaBotoes();
            LabelDeControle.Text = _gerente.ObtemTipoCadastro();
            
            UserControl _userControl = _gerente.ObterTipoUserControl();

            btnCadastrar.Text = _gerente.btnCad;
            btnEditar.Text = _gerente.btnEdit;
            btnExcluir.Text = _gerente.btnDel;

            _userControl.Dock = DockStyle.Fill;

            panel.Controls.Clear();

            panel.Controls.Add(_userControl);
        }

        private void btnCadastrar_Click(object sender, EventArgs e)
        {
            _gerente.Adicionar();
        }
        private void AtivaBotoes()
        {
            btnCadastrar.Enabled = true;
            btnEditar.Enabled = true;
            btnExcluir.Enabled = true;
        }
        private void btnEditar_Click_1(object sender, EventArgs e)
        {
            try
            {
                _gerente.Editar();
                //MessageBox.Show("Salvo com sucesso", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
        }

        private void matériasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CarregarCadastro(new MateriaGerenciadorFormulario());
        }

        private void questõesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CarregarCadastro(new QuestoesGerenciadorFormulario());
        }

        private void btnExcluir_Click_1(object sender, EventArgs e)
        {
            _gerente.Excluir();
            
        }

        private void gerarTesteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GerarTestesDialog gerarTestesDialog = new GerarTestesDialog();
            gerarTestesDialog.InsertDisciplinaInComomBox(_disciplinaService.GetAll());
            gerarTestesDialog.InsertSerieInComomBox(_serieService.GetAllSeries());
            gerarTestesDialog.InsertMateriaInComomBox(_materiaServico.GetAllMaterias());
            gerarTestesDialog.ShowDialog();
        }

        private void testesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CarregarCadastro(new TesteGerenciadorFormulario());
        }
    }
}

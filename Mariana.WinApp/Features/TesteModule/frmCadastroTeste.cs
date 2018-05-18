using Mariana.Dominio;
using Mariana.Dominio.Utils;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Mariana.WinApp.Features.TesteModule
{
    public partial class frmCadastroTeste : Form
    {
        private Teste teste;

        Disciplina disciplina = new Disciplina();
        Materia materia = new Materia();
        Serie serie = new Serie();

        IList<Disciplina> ListaDisciplinas;
        IList<Serie> ListaSeries;
        IList<Materia> ListaMaterias;

        public frmCadastroTeste(IList<Disciplina> disciplinas, IList<Serie> series, IList<Materia> materias)
        {
            InitializeComponent();
            ListaDisciplinas = disciplinas;
            ListaSeries = series;
            ListaMaterias = materias;

            cmbDisciplina.Items.Clear();
            cmbSerie.Items.Clear();
            cmbMateria.Items.Clear();

            foreach (var item in ListaDisciplinas)
                cmbDisciplina.Items.Add(item);

            foreach (var item in ListaSeries)
                cmbSerie.Items.Add(item);
        }

        public Teste NovoTeste
        {
            get
            {
                return teste;
            }
            set
            {
                teste = value;

                txtId.Text = teste.Id.ToString();

                if (teste.Nome != null)
                {
                    if (teste.Serie != null)
                    {
                        if (teste.Serie.NumeroSerie != 0)
                            cmbSerie.Text = teste.Serie.ToString();
                    }

                    if (teste.Disciplina != null)
                        cmbDisciplina.Text = teste.Disciplina.Nome.ToString();

                    if (teste.Materia != null)
                        cmbMateria.Text = teste.Materia.Nome.ToString();

                    txtNome.Text = teste.Nome.ToString();
                    nupNumeroQuestoes.Value = teste.NumeroQuestoes;
                    txtCaminhoDestino.Text = teste.CaminhoDestino;
                    EnableFields();
                    btnCadastrar.Text = "Atualizar/Gerar Teste";
                }
                else
                {
                    btnCadastrar.Text = "Gerar Teste";
                }
            }
        }

        private void EnableFields()
        {
            txtNome.Enabled = true;
            cmbSerie.Enabled = true;
            cmbDisciplina.Enabled = true;
            cmbMateria.Enabled = true;
        }

        private void cmbDisciplina_SelectedIndexChanged(object sender, EventArgs e)
        {
            teste.Disciplina = cmbDisciplina.SelectedItem as Disciplina;
            cmbMateria.Items.Clear();
            cmbMateria.Text = "";
            teste.Materia = null;

            foreach (var item in ListaMaterias)
            {
                if (item.Disciplina.Id == teste.Disciplina.Id && item.Serie.Id == teste.Serie.Id)
                    cmbMateria.Items.Add(item);
            }
                        
            cmbMateria.Enabled = true;
        }

        private void cmbSerie_SelectedIndexChanged(object sender, EventArgs e)
        {
            teste.Serie = cmbSerie.SelectedItem as Serie;

            cmbDisciplina.Enabled = true;
        }

        private void cmbMateria_SelectedIndexChanged(object sender, EventArgs e)
        {
            teste.Materia = cmbMateria.SelectedItem as Materia;
        }

        private void btnCadastrar_Click(object sender, EventArgs e)
        {
            try
            {
                teste.Nome = txtNome.Text;
                teste.NumeroQuestoes = Convert.ToInt32(nupNumeroQuestoes.Value);
                teste.DataTesteGerado = DateTime.Now;
                teste.CaminhoDestino = txtCaminhoDestino.Text;

                DominioHelper.ValidarEspaçoVazioETamanho(teste.Nome);
                DominioHelper.ValidarNomeComNumero(teste.Nome);
                DominioHelper.ValidarDisciplinaSerieMateria(teste.Disciplina, teste.Serie, teste.Materia);
                teste.Nome = DominioHelper.FormatarNome(teste.Nome);

                teste.Validate();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);

                DialogResult = DialogResult.None;
            }
        }
        private void txtNome_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
                btnCadastrar.PerformClick();

            if (e.KeyData == Keys.Escape)
                this.Close();
        }

        private void btnCaminho_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFile = new SaveFileDialog();
            saveFile.Filter = "Pdf File|*.pdf";
            saveFile.Title = "Salve o Arquivo PDF";
            saveFile.ShowDialog();

            txtCaminhoDestino.Text = saveFile.FileName;
        }
        
    }
}


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

namespace Mariana.WinApp.Features.MateriaModule
{
    public partial class frmCadastroMateria : Form
    {
        private Materia materia;

        Disciplina disciplina = new Disciplina();
        Serie serie = new Serie();

        IList<Disciplina> ListaDisciplinas;
        IList<Serie> ListaSeries;

        public frmCadastroMateria(IList<Disciplina> disciplinas, IList<Serie> series)
        {
            InitializeComponent();
            ListaDisciplinas = disciplinas;
            ListaSeries = series;

            cmbDisciplina.Items.Clear();
            cmbSerie.Items.Clear();

            foreach (var item in ListaDisciplinas)
            {
                cmbDisciplina.Items.Add(item);
            }
            foreach (var item in ListaSeries)
            {
                cmbSerie.Items.Add(item);
            }
        }
        public Materia NovaMateria
        {
            get
            {
                return materia;
            }
            set
            {
                materia = value;

                txtId.Text = materia.Id.ToString();
                
                if (materia.Nome != null)
                {
                    if (materia.Disciplina != null)
                        cmbDisciplina.Text = materia.Disciplina.ToString();
                    if (materia.Serie != null)
                    {
                        if (materia.Serie.NumeroSerie != 0)
                            cmbSerie.Text = ma  teria.Serie.ToString();
                    }

                    txtNome.Text = materia.Nome.ToString();
                    btnCadastrar.Text = "Atualizar";

                }
                else
                {
                    btnCadastrar.Text = "Cadastrar";
                }
            }
        }

        private void cmbDisciplina_SelectedIndexChanged(object sender, EventArgs e)
        {
            materia.Disciplina = cmbDisciplina.SelectedItem as Disciplina;
        }

        private void cmbSerie_SelectedIndexChanged(object sender, EventArgs e)
        {
            materia.Serie = cmbSerie.SelectedItem as Serie;
        }

        private void btnCadastrar_Click(object sender, EventArgs e)
        {
            try
            {
                materia.Nome = txtNome.Text;

                DominioHelper.ValidarEspaçoVazioETamanho(materia.Nome);
                DominioHelper.ValidarNomeComNumero(materia.Nome);
                DominioHelper.ValidarDisciplinaSerieMateria(materia.Disciplina, materia.Serie);

                materia.Nome = DominioHelper.FormatarNome(materia.Nome);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);

                DialogResult = DialogResult.None;
            }
        }
        private void txtNome_KeyDown(object sender,KeyEventArgs e)
        {
            if(e.KeyData == Keys.Enter)
            {
                btnCadastrar.PerformClick();
            }
            if(e.KeyData == Keys.Escape)
            {
                this.Close();
            }
        }
    }
}

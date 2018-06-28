using GeradorTestes.Domain;
using GeradorTestes.Servicos;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GeradorTestes.Cadastros.Matérias
{
    public partial class CadastroMateriasDialog : Form
    {
        MateriaServico _materiaServico;
        IList<Serie> _listaSeries;
        IList<Disciplina> _listaDisciplinas;

        public CadastroMateriasDialog(MateriaServico materiaServico, string titulo, Materia materia = null)
        {
            InitializeComponent();
            _materiaServico = materiaServico;
            NovaMateria = materia;
            this.Text = titulo;
        }

        private Materia _novaMateria;
        public Materia NovaMateria
        {
            get
            {
                return _novaMateria;
            }
            set
            {
                _novaMateria = value;
            }
        }
        private void PopulaCmbSerie()
        {
            cmbSerie.Items.Clear();
            foreach (var item in _listaSeries)
            {
                cmbSerie.Items.Add(item);
            }
            SelectCmb();
        }

        private void PopulaCmbDisciplina()
        {
            cbmDisciplina.Items.Clear();
            foreach (var item in _listaDisciplinas)
            {
                cbmDisciplina.Items.Add(item);
            }
            SelectCmbDisciplina();
        }

        private void SelectCmbDisciplina()
        {
            if (NovaMateria != null)
            {
                foreach (var disciplina in _listaDisciplinas)
                {
                    if (NovaMateria.disciplina.ID == disciplina.ID)
                    {
                        cbmDisciplina.SelectedItem = disciplina as Disciplina;
                    }
                }

            }
        }

        public void SelectCmb()
        {
            if (NovaMateria != null)
            {
                foreach (var serie in _listaSeries)
                {
                    if (NovaMateria.serie.ID == serie.ID)
                    {
                        cmbSerie.SelectedItem = serie as Serie;
                        txtNome.Text = NovaMateria.Nome;
                    }
                }

            }
        }
        public void CriaListaSerie(IList<Serie> listaSeries)
        {
            _listaSeries = listaSeries;
            PopulaCmbSerie();
        }

        public void CriaListaDisciplina(IList<Disciplina> listaDisciplina)
        {
            _listaDisciplinas = listaDisciplina;
            PopulaCmbDisciplina();
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
            try
            {
                if (NovaMateria != null)
                {
                    if (NovaMateria.Nome.Trim() == txtNome.Text.Trim() && NovaMateria.serie.Nome == cmbSerie.Text)
                        return;

                    NovaMateria.serie = cmbSerie.SelectedItem as Serie;
                    NovaMateria.disciplina = cbmDisciplina.SelectedItem as Disciplina;
                    NovaMateria.Nome = txtNome.Text.Trim();
                    try
                    {
                        _materiaServico.Update(NovaMateria);
                        MessageBox.Show("Matéria Editada com sucesso", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch(Exception ex)
                    {
                        DialogResult = DialogResult.None;
                        MessageBox.Show(ex.Message, "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    NovaMateria = new Materia();
                    NovaMateria.serie = cmbSerie.SelectedItem as Serie;
                    NovaMateria.disciplina = cbmDisciplina.SelectedItem as Disciplina;
                    NovaMateria.Nome = txtNome.Text.Trim();
                    _materiaServico.Adicionar(NovaMateria);
                    MessageBox.Show("Matéria Adicionada com sucesso", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }
            }
            catch (Exception ex)
            {
                DialogResult = DialogResult.None;
                NovaMateria = null;
                MessageBox.Show(ex.Message, "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void CadastroMateriasDialog_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void txtNome_TextChanged(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }
    }
}

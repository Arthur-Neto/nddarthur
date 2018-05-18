using Mariana.Aplicacao;
using Mariana.Dominio;
using Mariana.Dominio.Exceptions;
using Mariana.WinApp.Nucleo.CadastroDialog;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Mariana.WinApp.Features.MateriaModule
{
    public partial class FormCadastroMateria : CadastroBasicoDialog<Materia>
    {
        private MateriaService _servico;

        public FormCadastroMateria(MateriaService servico, DisciplinaService disciplinaService, SerieService serieService) : base()
        {
            InitializeComponent();
            if (_entidade == null)
            {
                _entidade = new Materia();
            }
            _servico = servico;

            PopularComboBoxs(disciplinaService.BuscarTodos(), serieService.BuscarTodos());
        }

        private void PopularComboBoxs(IList<Disciplina> disciplinas, IList<Serie> series)
        {
            cmbDisciplina.Items.Clear();
            cmbSerie.Items.Clear();
            foreach (var item in disciplinas)
            {
                cmbDisciplina.Items.Add(item);
            }
            foreach (var item in series)
            {
                cmbSerie.Items.Add(item);

            }
        }

        protected override void Salvar()
        {
            try
            {
                AtribuirValores();
                _entidade.Validar();
                ((MateriaService)_servico).ValidarExistenciaNome(_entidade.Nome, _entidade.Serie.Id);
            }
            catch (ValidacaoException ex)
            {
                DialogResult = DialogResult.None;
                labelStatus.Text = ex.Message;
            }
            catch (Exception exc)
            {
                DialogResult = DialogResult.None;
                labelStatus.Text = exc.Message;
            }
        }

        protected override void AtribuirValores()
        {
            if (_entidade == null)
            {
                _entidade = new Materia();
            }
            _entidade.Nome = txtNome.Text;
            _entidade.Disciplina = cmbDisciplina.SelectedItem as Disciplina;
            _entidade.Serie = cmbSerie.SelectedItem as Serie;

        }

        protected override void MostrarValores()
        {
            txtId.Text = Convert.ToString(_entidade.Id);
            txtNome.Text = _entidade.Nome;
            cmbDisciplina.Text = _entidade.Disciplina.ToString();
            cmbSerie.Text = _entidade.Serie.ToString();
        }

        protected override void LimparValores()
        {
            txtId.Clear();
            txtNome.Clear();
            cmbDisciplina.Items.Clear();
            cmbSerie.Items.Clear();
        }

        private void cmbDisciplina_SelectedIndexChanged(object sender, EventArgs e)
        {
            _entidade.Disciplina = cmbDisciplina.SelectedItem as Disciplina;
        }

        private void cmbSerie_SelectedIndexChanged(object sender, EventArgs e)
        {
            _entidade.Serie = cmbSerie.SelectedItem as Serie;
        }
    }
}

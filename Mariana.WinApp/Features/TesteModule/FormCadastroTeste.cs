using Mariana.Aplicacao;
using Mariana.Dominio;
using Mariana.Dominio.Exceptions;
using Mariana.WinApp.Nucleo.CadastroDialog;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Mariana.WinApp.Features.TesteModule
{
    public partial class FormCadastroTeste : CadastroBasicoDialog<Teste>
    {
        private TesteService _servico;

        private IList<Materia> _listaMaterias;
        private IList<Disciplina> _listaDisciplinas;
        private IList<Serie> _listaSerie;

        public FormCadastroTeste(TesteService servico, DisciplinaService disciplinaService, MateriaService materiaService, SerieService serieService) : base()
        {
            InitializeComponent();
            if (_entidade == null)
                _entidade = new Teste();

            _servico = servico;

            _listaDisciplinas = disciplinaService.BuscarTodos();
            _listaMaterias = materiaService.BuscarTodos();
            _listaSerie = serieService.BuscarTodos();

            PopularComboBoxs(_listaDisciplinas, _listaMaterias, _listaSerie);
        }

        private void PopularComboBoxs(IList<Disciplina> disciplinas, IList<Materia> materias, IList<Serie> serie)
        {
            cmbDisciplina.Items.Clear();
            cmbMateria.Items.Clear();
            cmbSerie.Items.Clear();
            foreach (var item in disciplinas)
            {
                cmbDisciplina.Items.Add(item);
            }
            foreach (var item in materias)
            {
                cmbMateria.Items.Add(item);
            }
            foreach (var item in serie)
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
                _servico.ValidarExistenciaNome(_entidade.Nome, _entidade.Id);
                //((TesteService)_servico).ValidarExistenciaNome(_entidade.Nome, _entidade.Id);
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
                _entidade = new Teste();
            }

            _entidade.Nome = txtNome.Text;
            _entidade.Serie = cmbSerie.SelectedItem as Serie;
            _entidade.Disciplina = cmbDisciplina.SelectedItem as Disciplina;
            _entidade.Materia = cmbMateria.SelectedItem as Materia;
            _entidade.NumeroQuestoes = (int)nupNumeroQuestoes.Value;
            _entidade.CaminhoDestino = txtCaminhoDestino.Text;
            _entidade.DataTesteGerado = DateTime.Now;
        }

        protected override void MostrarValores()
        {
            txtNome.Text = _entidade.Nome;
            cmbSerie.SelectedItem = _entidade.Serie;
            cmbDisciplina.SelectedItem = _entidade.Disciplina;
            cmbMateria.SelectedItem = _entidade.Materia;
            nupNumeroQuestoes.Value = _entidade.NumeroQuestoes;
            txtCaminhoDestino.Text = _entidade.CaminhoDestino;
        }

        protected override void LimparValores()
        {
            txtNome.Clear();
            cmbSerie.SelectedItem = null;
            cmbDisciplina.SelectedItem = null;
            cmbMateria.SelectedItem = null;
            nupNumeroQuestoes.Value = 0;
            txtCaminhoDestino.Clear();
        }

        private void cmbSerie_SelectedIndexChanged(object sender, EventArgs e)
        {
            _entidade.Serie = cmbSerie.SelectedItem as Serie;
            
            cmbDisciplina.Enabled = true;
        }

        private void cmbDisciplina_SelectedIndexChanged(object sender, EventArgs e)
        {
            _entidade.Disciplina = cmbDisciplina.SelectedItem as Disciplina;
            AtualizarMaterias();
            cmbMateria.Enabled = true;
        }
        private void AtualizarMaterias()
        {
            cmbMateria.Text = "";
            cmbMateria.Items.Clear();
            foreach (var item in _listaMaterias)
            {
                if (item.Disciplina.Id == _entidade.Disciplina.Id && item.Serie.Id == _entidade.Serie.Id)
                {
                    cmbMateria.Items.Add(item);
                }
            }

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

using Mariana.Aplicacao;
using Mariana.Dominio;
using Mariana.Dominio.Exceptions;
using Mariana.Dominio.Exceptions.Disciplina;
using Mariana.WinApp.Nucleo.CadastroDialog;
using Mariana.WinApp.Nucleo.ControleUsuario;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Mariana.WinApp.Features.QuestaoModule
{
    public partial class FormCadastroQuestao : CadastroBasicoDialog<Questao>
    {
        private QuestaoService _servico;
        private UserControlBasico<Resposta> _userControlRespostas;
        public IList<Resposta> _respostas { get; set; }
        public IList<Resposta> _respostasAdicionadas { get; set; }
        public IList<Resposta> _respostasExcluidas { get; set; }

        private IList<Materia> _listaMaterias;
        private IList<Disciplina> _listaDisciplinas;

        public FormCadastroQuestao(QuestaoService servico, DisciplinaService disciplinaService, MateriaService materiaService) : base()
        {
            InitializeComponent();
            if (_entidade == null)
            {
                _entidade = new Questao();
                _respostas = new List<Resposta>();
                _respostasAdicionadas = new List<Resposta>();
                _respostasExcluidas = new List<Resposta>();
            }
            if (_respostas != null)
            {
                _respostas = _entidade.Respostas;
                _respostasAdicionadas = new List<Resposta>();
                _respostasExcluidas = new List<Resposta>();
            }
            _servico = servico;

            _listaMaterias = materiaService.BuscarTodos();
            _listaDisciplinas = disciplinaService.BuscarTodos();

            _userControlRespostas = new UserControlBasico<Resposta>();
            _userControlRespostas.Dock = DockStyle.Fill;
            panelResposta.Controls.Add(_userControlRespostas);

            PopularComboBoxs(_listaDisciplinas, _listaMaterias);
        }

        private void PopularComboBoxs(IList<Disciplina> disciplinas, IList<Materia> materias)
        {
            cmbDisciplina.Items.Clear();
            cmbMateria.Items.Clear();
            foreach (var item in disciplinas)
            {
                cmbDisciplina.Items.Add(item);
            }
            foreach (var item in materias)
            {
                cmbMateria.Items.Add(item);
            }
            foreach (var item in Enum.GetValues(typeof(Bimestre)))
            {
                cmbBimestre.Items.Add(item);
            }
        }

        protected override void Salvar()
        {
            try
            {
                if (cmbBimestre.SelectedItem == null || !cmbDisciplina.Enabled || !cmbMateria.Enabled)
                {
                    throw new Exception("Não pode cadastrar uma questão sem selecionar todos os itens necessários");
                }
                AtribuirValores();
                _entidade.Validar();
                _entidade.ValidarListaRespostas(_respostas);
                _servico.ValidarExistenciaNome(_entidade.Enunciado, _entidade.Id);
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
                _entidade = new Questao();
            }

            _entidade.Bimestre = (Bimestre)cmbBimestre.SelectedItem;
            _entidade.Disciplina = cmbDisciplina.SelectedItem as Disciplina;
            _entidade.Enunciado = txtEnunciado.Text;
            _entidade.Materia = cmbMateria.SelectedItem as Materia;
            _entidade.Respostas = _respostas;
        }

        protected override void MostrarValores()
        {
            cmbBimestre.Enabled = true;
            cmbDisciplina.Enabled = true;
            cmbMateria.Enabled = true;
            txtEnunciado.Enabled = true;
            txtResposta.Enabled = true;
            btnAddResponse.Enabled = true;
            btnRemoveResponse.Enabled = true;
            ckbCorreta.Enabled = true;
            txtEnunciado.Text = _entidade.Enunciado;
            txtId.Text = _entidade.Id.ToString();
            cmbBimestre.SelectedItem = _entidade.Bimestre;
            cmbDisciplina.SelectedItem = _entidade.Disciplina;
            cmbMateria.SelectedItem = _entidade.Materia;
            _userControlRespostas.PopularListagem(_entidade.Respostas);

            foreach (var item in _entidade.Respostas)
            {
                _respostas.Add(item);
            }
        }

        protected override void LimparValores()
        {
            txtEnunciado.Clear();
            txtId.Clear();
            txtResposta.Clear();
            cmbBimestre.Items.Clear();
            cmbDisciplina.Items.Clear();
            cmbMateria.Items.Clear();
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
                if (item.Disciplina.Id == _entidade.Disciplina.Id)
                {
                    cmbMateria.Items.Add(item);
                }
            }
            cmbBimestre.Enabled = false;
        }

        private void cmbMateria_SelectedIndexChanged(object sender, EventArgs e)
        {
            _entidade.Materia = cmbMateria.SelectedItem as Materia;
            cmbBimestre.Enabled = true;
        }

        private void cmbBimestre_SelectedIndexChanged(object sender, EventArgs e)
        {
            _entidade.Bimestre = (Bimestre)cmbBimestre.SelectedItem;
            txtEnunciado.Enabled = true;
            btnAddResponse.Enabled = true;
            btnRemoveResponse.Enabled = true;
            txtResposta.Enabled = true;
            ckbCorreta.Enabled = true;
        }

        private void btnAddResponse_Click(object sender, EventArgs e)
        {
            try
            {
                
                foreach (var item in _respostas)
                {
                    if (item.CorpoResposta == txtResposta.Text)
                        throw new DuplicadaException(String.Format("Resposta duplicada"));
                }

                labelStatus.Text = "";
                Resposta res = new Resposta();
                res.CorpoResposta = txtResposta.Text;
                res.Correta = ckbCorreta.Checked;
                res.Validar();
                _respostasAdicionadas.Add(res);
                _respostas.Add(res);

                txtResposta.Text = "";
                ckbCorreta.Checked = false;
                _userControlRespostas.PopularListagem(_respostas);
            }
            catch (DuplicadaException ex)
            {
                labelStatus.Text = ex.Message;
            }
            catch (Exception ex)
            {
                labelStatus.Text = ex.Message;
            }
        }

        private void btnRemoveResponse_Click(object sender, EventArgs e)
        {
            labelStatus.Text = "";
     
            Resposta res = _userControlRespostas.ObterItemSelecionado();

            if (res == null)
                labelStatus.Text = "Selecione uma resposta para exclusão";

            _respostas.Remove(res);
            _respostasExcluidas.Add(res);

            txtResposta.Text = "";
            ckbCorreta.Checked = false;
            _userControlRespostas.PopularListagem(_respostas);
        }
    }
}

using Mariana.Aplicacao;
using Mariana.Dominio;
using Mariana.Dominio.Exceptions;
using Mariana.WinApp.Nucleo.CadastroDialog;
using System;
using System.Windows.Forms;

namespace Mariana.WinApp.Features.DisciplinaModule
{
    public partial class FormCadastroDisciplina : CadastroBasicoDialog<Disciplina>
    {
        private DisciplinaService _servico;

        public FormCadastroDisciplina(DisciplinaService servico) : base()
        {
            InitializeComponent();
            _servico = servico;
        }

        protected override void Salvar()
        {
            try
            {
                AtribuirValores();
                _entidade.Validar();
                ((DisciplinaService)_servico).ValidarExistenciaNome(_entidade.Nome, _entidade.Id);
            }
            catch (ValidacaoException ex)
            {
                DialogResult = DialogResult.None;

                //MessageBox.Show(ex.Message);
                labelStatus.Text = ex.Message;
            }
            catch (Exception exc)
            {
                DialogResult = DialogResult.None;

                labelStatus.Text = exc.Message;
                //MessageBox.Show(exc.Message);

            }
        }

        protected override void AtribuirValores()
        {
            if (_entidade == null)
            {
                _entidade = new Disciplina();
            }
            _entidade.Nome = txtDisciplina.Text;
            
        }

        protected override void MostrarValores()
        {
            txtId.Text = Convert.ToString(_entidade.Id);
            txtDisciplina.Text = _entidade.Nome;
        }

        protected override void LimparValores()
        {
            txtId.Clear();
            txtDisciplina.Clear();
        }
    }
}

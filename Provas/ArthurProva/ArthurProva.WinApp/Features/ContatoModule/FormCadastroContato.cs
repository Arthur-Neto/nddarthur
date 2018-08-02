using ArthurProva.Aplicacao;
using ArthurProva.Domain;
using ArthurProva.Domain.Exceptions;
using ArthurProva.WinApp.Base.CadastroDialog;
using System;
using System.Windows.Forms;

namespace ArthurProva.WinApp.Features.ContatoModule
{
    public partial class FormCadastroContato : CadastroBasicoDialog<Contato>
    {
        private ContatoService _service;

        public FormCadastroContato(ContatoService contatoService) : base()
        {
            InitializeComponent();
            _service = contatoService;
        }

        protected override void Salvar()
        {
            try
            {
                AtribuirValores();
                _entidade.Validar();
                ((ContatoService)_service).ValidarExistenciaNome(_entidade.Nome, _entidade.Id);
            }
            catch (ValidacaoException ex)
            {
                DialogResult = DialogResult.None;

                //MessageBox.Show(ex.Message);
                labelStatus.Text = ex.Message;
            }

            catch (FormatException)
            {
                DialogResult = DialogResult.None;

                labelStatus.Text = "Telefone informado não correponde com o padrão";
            }
            catch (Exception exc)
            {
                DialogResult = DialogResult.None;

                labelStatus.Text = exc.Message + exc.GetType();
                //MessageBox.Show(exc.Message);

            }
        }

        protected override void AtribuirValores()
        {
            if (_entidade == null)
            {
                _entidade = new Contato();
            }
            _entidade.Nome = textBoxNome.Text;
            _entidade.Departamento = textBoxDep.Text;
            _entidade.Email = textBoxEmail.Text;
            _entidade.Endereco = textBoxEndereco.Text;
            maskedTextBoxTelefone.TextMaskFormat = MaskFormat.ExcludePromptAndLiterals;
            _entidade.Telefone = Convert.ToInt32(maskedTextBoxTelefone.Text);

        }

        protected override void MostrarValores()
        {
            textBoxDep.Text = _entidade.Departamento;
            textBoxEmail.Text = _entidade.Email;
            textBoxEndereco.Text = _entidade.Endereco;
            textBoxNome.Text = _entidade.Nome;
            maskedTextBoxTelefone.Text = Convert.ToString(_entidade.Telefone);

        }

        protected override void LimparValores()
        {
            textBoxDep.Clear();
            textBoxEmail.Clear();
            textBoxEndereco.Clear();
            textBoxNome.Clear();
            maskedTextBoxTelefone.Clear();
        }
    }
}

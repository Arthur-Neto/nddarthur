using Pizzaria.Dominio.Base;
using System.Windows.Forms;

namespace Pizzaria.WinApp.Base
{
    public partial class FormCadastroBasico<T> : Form where T : Entidade
    {
        protected T _entidade;

        public FormCadastroBasico()
        {
            InitializeComponent();
        }

        public T Entidade
        {
            get
            {
                return _entidade;
            }
            set
            {
                _entidade = value;

                if (_entidade != null)
                    MostrarValores();
            }
        }

        protected virtual void Salvar() { }
        protected virtual void AtribuirValores() { }
        protected virtual void MostrarValores() { }
        protected virtual void LimparValores() { }
        protected virtual void ValidarValores() { }
        protected void DesabilitarBotoesBase()
        {
            buttonSalvar.Enabled = false;
            buttonCancelar.Enabled = false;
        }

        private void buttonSalvar_Click(object sender, System.EventArgs e)
        {
            Salvar();
        }

        protected void MostrarErro(string log)
        {
            labelError.Visible = true;
            labelError.Text = log;
        }
    }
}

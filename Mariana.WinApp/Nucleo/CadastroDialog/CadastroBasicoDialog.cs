using System;
using System.Windows.Forms;

namespace Mariana.WinApp.Nucleo.CadastroDialog
{
    public partial class CadastroBasicoDialog<E> : Form
    {
        protected E _entidade;

        public CadastroBasicoDialog()
        {
            InitializeComponent();
        }

        private void CadastroBasicoDialog_Load(object sender, EventArgs e)
        {
        }

        public E Entidade
        {
            get
            {
                return _entidade;
            }
            set
            {
                //LimparValores();
                _entidade = value;

                if (_entidade != null)
                    MostrarValores();
            }
        }

        private void buttonCadastrarAtualizar_Click(object sender, EventArgs e)
        {
            Salvar();
        }

        protected virtual void Salvar() { }

        protected virtual void AtribuirValores() { }

        protected virtual void MostrarValores() { }

        protected virtual void LimparValores() { }

        protected virtual void ValidarValores() { }
    }
}

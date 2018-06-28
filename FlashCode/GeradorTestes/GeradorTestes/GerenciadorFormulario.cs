using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GeradorTestes
{
     public abstract class GerenciadorFormulario
    {
        public abstract void Adicionar();

        public abstract void Editar();

        public abstract void Excluir();

        public abstract UserControl ObterTipoUserControl();

        public abstract string ObtemTipoCadastro();

        public virtual string btnCad { get => "Cadastrar"; }
        public virtual string btnEdit { get => "Editar"; }
        public virtual string btnDel { get => "Excluir"; }

    }
}

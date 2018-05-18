using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Mariana.WinApp
{
    public abstract class GerenciadorFormulario
    {
        public abstract void Adicionar();
        public abstract void Atualizar();
        public abstract void Excluir();
        public abstract UserControl CarregarListagem();
        public abstract string ObtemTipoCadastro();
        public abstract TituloBotoes ObtemTituloBotoes();
        public abstract EstadoBotoes ObtemEstadoBotoes();
    }
}

using BancoWindowsApp1.Features.Compartilhado;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BancoWindowsApp1
{
    public abstract class  GerenciadorFormulario
    {
        public abstract void Adicionar();

        public abstract void Excluir();

        public abstract UserControl CarregarListagem();

        public abstract string ObtemTipoCadastro();

        public abstract EstadoBotoes ObtemTipoBotoes();

    }
}

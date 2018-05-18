using Mariana.Dominio;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Mariana.WinApp.Nucleo.ControleUsuario
{
    public partial class UserControlBasico<E> : UserControl where E : Entidade
    {
        public UserControlBasico()
        {
            InitializeComponent();
        }

        public void PopularListagem(IList<E> entidades)
        {
            listBoxEntidades.Items.Clear();

            foreach (E c in entidades)
            {
                listBoxEntidades.Items.Add(c);
            }

        }

        public E ObterItemSelecionado()
        {
            return listBoxEntidades.SelectedItem as E;
        }
    }
}

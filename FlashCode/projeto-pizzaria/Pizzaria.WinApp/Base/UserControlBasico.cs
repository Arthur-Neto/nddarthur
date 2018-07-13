using Pizzaria.Dominio.Base;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Pizzaria.WinApp.Base
{
    public partial class UserControlBasico<T> : UserControl where T : Entidade
    {
        public UserControlBasico()
        {
            InitializeComponent();
        }
        public void PopularListagem(IEnumerable<T> entidades)
        {
            listEntidades.Items.Clear();
            foreach (var item in entidades)
            {
                listEntidades.Items.Add(item);
            }
        }

        public T ObterItemSelecionado()
        {
            return listEntidades.SelectedItem as T;
        }
    }
}

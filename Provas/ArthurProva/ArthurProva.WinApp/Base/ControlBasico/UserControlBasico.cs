using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ArthurProva.Domain;

namespace ArthurProva.WinApp.Base.ControlBasico
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

        public IList<E> RetornarTodosEmList()
        {
            IList<E> lista = new List<E>();
            foreach (E item in listBoxEntidades.Items)
            {
                lista.Add(item);
            }
            return lista;
        }

        public E ObterItemSelecionado()
        {
            return listBoxEntidades.SelectedItem as E;
        }
    }
}

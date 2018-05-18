using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BancoApp.dominio;

namespace BancoWindowsApp1.Features.ClienteModule
{
    public partial class ClienteControl : UserControl
    {
        public ClienteControl()
        {
            InitializeComponent();
        }
        public void popularListagemCliente(List<Cliente> clientes)
        {
            listClientes.Items.Clear();

            foreach (Cliente cliente in clientes)
            {
                listClientes.Items.Add(cliente);
            }
        }

        public Cliente ObtemClienteSelecionado()
        {
            return (Cliente)listClientes.SelectedItem;
        }
    }
}

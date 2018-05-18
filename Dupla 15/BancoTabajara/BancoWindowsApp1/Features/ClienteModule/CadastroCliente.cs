using BancoApp.dominio;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BancoWindowsApp1.Features
{
    public partial class CadastroCliente : Form
    {
        public CadastroCliente()
        {
            InitializeComponent();
        }

        public Cliente NovoCliente
        {
            get
            {
                Cliente cliente = new Cliente
                {
                    Nome = txtNomeCliente.Text,
                    Endereco = txtEnderecoCliente.Text,
                    Email = txtEmailCliente.Text
                };
                return cliente;
            }
        }
    }
}

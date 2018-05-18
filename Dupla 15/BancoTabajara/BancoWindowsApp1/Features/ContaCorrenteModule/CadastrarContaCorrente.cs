using BancoApp.dominio;
using BancoApp.Infra.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BancoWindowsApp1.Features.ContaCorrenteModule
{
    public partial class CadastrarContaCorrente : Form
    {
        List<Cliente> clientes;

        public CadastrarContaCorrente(ClienteMem repositorio)
        {
            InitializeComponent();
            clientes = repositorio.ListarCliente();

            foreach (var cliente in clientes)
            {
                cmbTitular.Items.Add(cliente); 
            }
        }

        public ContaCorrente NovaConta
        {
            get
            {
                var conta = new ContaCorrente
                {
                    Numero = int.Parse(txtNumeroConta.Text),
                    Saldo = double.Parse(txtSaldoConta.Text),
                    Limite = double.Parse(txtLimiteConta.Text),
                    StatusContaEspecial = chkContaEspecial.Checked,
                    Cliente = (Cliente)cmbTitular.SelectedItem
                };

                return conta;
            }
        }
    }
}

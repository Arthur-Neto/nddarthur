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

namespace BancoWindowsApp1.Features.ContaCorrenteModule
{
    public partial class DepositoSaqueContaCorrente : Form
    {
        public DepositoSaqueContaCorrente(ContaCorrente conta, String tipo)
        {
            InitializeComponent();
            labelNumero.Text = Convert.ToString(conta.Numero);
            labelSaldo.Text = Convert.ToString("R$" + conta.Saldo);
            btnDepositar.Text = tipo;
        }

        public double Depositar
        {
            get
            {
                double valor = double.Parse(txtValor.Text);

                return valor;
            }
        }
        public double Sacar
        {
            get
            {
                double valor = double.Parse(txtValor.Text);
                return valor;
            }
        }
    }
}

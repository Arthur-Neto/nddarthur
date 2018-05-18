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
    public partial class TransferirContaCorrente : Form
    {
        public TransferirContaCorrente(ContaCorrente contaSelecionada, List<ContaCorrente> contas)
        {
            if (contaSelecionada != null)
            {
                InitializeComponent();
                labelNumero.Text = Convert.ToString(contaSelecionada.Numero);
                labelSaldo.Text = Convert.ToString("R$" + contaSelecionada.Saldo);
                foreach (var item in contas)
                {
                    if (item.Numero != contaSelecionada.Numero)
                    {
                        cbContaDestino.Items.Add(item);
                    }
                }
            }
            else
            {
                MessageBox.Show("Selecione uma conta de Origem", "Atenção",
                   MessageBoxButtons.OK, MessageBoxIcon.Question);
            }
        }

        public ContaCorrente ContaDestino
        {
            get
            {
                return (ContaCorrente)cbContaDestino.SelectedItem;
            }
        }

        public double Valor
        {
            get
            {
                double valor = double.Parse(txtValorTransferencia.Text);

                return valor;
            }
        }
    }
}

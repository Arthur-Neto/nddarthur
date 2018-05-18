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

namespace BancoWindowsApp
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            
        }

        ContaMem _memory = new ContaMem();
        ContaCorrente contaSelecionada = new ContaCorrente();

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

        private void btnNovaConta_Click_1(object sender, EventArgs e)
        {
            ContaCorrente NovaConta = FormToObject();

            _memory.AdicionarConta(NovaConta);

            CleanFields();

            ListContas();
        }

        #region utils methods 
        private void CleanFields()
        {
            txtNumConta.Clear();
            txtLimite.Clear();
            txtSaldo.Clear();
            cbTipoConta.Checked = false;
        }

        private ContaCorrente FormToObject()
        {
            ContaCorrente NovaConta = new ContaCorrente();
            NovaConta.Numero = Convert.ToDouble(txtNumConta.Text);
            NovaConta.Saldo = Convert.ToDouble(txtSaldo.Text);
            NovaConta.Limite = Convert.ToDouble(txtLimite.Text);
            NovaConta.StatusContaEspecial = cbTipoConta.Checked ? true : false;
            return NovaConta;
        }

        private void ListContas()
        {
            listDeposito.Items.Clear();
            listSaque.Items.Clear();
            

            var list = _memory.ListarContas();

            foreach (var item in list)
            {
                listDeposito.Items.Add(item);
                listSaque.Items.Add(item);
                cmbContaOrigem.Items.Add(item);
            }
        }

        #endregion

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnDepositar_Click(object sender, EventArgs e)
        {
            double valorDeposito = Convert.ToDouble(txtValorDeposito.Text);
            contaSelecionada.Deposito(valorDeposito);
            ListContas();
        }

        private void listDeposito_SelectedIndexChanged(object sender, EventArgs e)
        {
            contaSelecionada = listDeposito.SelectedItem as ContaCorrente;

        }

        private void txtValorDeposito_TextChanged(object sender, EventArgs e)
        {

        }

        private void listSaque_SelectedIndexChanged(object sender, EventArgs e)
        {
            contaSelecionada = listSaque.SelectedItem as ContaCorrente;
        }

        private void txtValorSaque_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnRealizarSaque_Click(object sender, EventArgs e)
        {
            double valorSaque = Convert.ToDouble(txtValorSaque.Text);
            contaSelecionada.Saque(valorSaque);
            ListContas();
        }

        private void cmbContaOrigem_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}

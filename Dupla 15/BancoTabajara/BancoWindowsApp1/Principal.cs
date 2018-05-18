using BancoApp.Infra.Data;
using BancoWindowsApp1.Features.ClienteModule;
using BancoWindowsApp1.Features.Compartilhado;
using BancoWindowsApp1.Features.ContaCorrenteModule;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BancoWindowsApp1
{

    public partial class Principal : Form
    {
        private ContaMem _repositorioContaCorrente = new ContaMem();
        private ClienteMem _repositorioCliente = new ClienteMem();
        private GerenciadorFormulario _gerenciador;
        private ContaCorrenteGerenciadorForm _gerenciadorContaCorrente;
        private ClienteGerenciadorForm _gerenciadorCliente;

        public Principal()
        {
            InitializeComponent();

        }

        private void contaCorrenteMenuItem_Click(object sender, EventArgs e)
        {
            if (_gerenciadorContaCorrente == null)
                _gerenciadorContaCorrente = new ContaCorrenteGerenciadorForm(_repositorioContaCorrente, _repositorioCliente);

            CarregarCadastro(_gerenciadorContaCorrente);
        }

        private void cadastroClienteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (_gerenciadorCliente == null)
                _gerenciadorCliente = new ClienteGerenciadorForm(_repositorioCliente);

            CarregarCadastro(_gerenciadorCliente);
        }

        private void CarregarCadastro(GerenciadorFormulario gerenciador)
        {
            _gerenciador = gerenciador;
            EstadoBotoes _gerenciadorTipoBotao = gerenciador.ObtemTipoBotoes();

            tsLabel.Text = _gerenciador.ObtemTipoCadastro();

            btnCadastrar.Enabled = _gerenciadorTipoBotao.Cadastrar;
            btnDepositar.Enabled = _gerenciadorTipoBotao.Depositar;
            btnSaque.Enabled = _gerenciadorTipoBotao.Sacar;
            btnTransferir.Enabled = _gerenciadorTipoBotao.Transferir;
            btnExtrato.Enabled = _gerenciadorTipoBotao.Extrato;
            btnExcluir.Enabled = _gerenciadorTipoBotao.Excluir;

            UserControl listagem = _gerenciador.CarregarListagem();

            listagem.Dock = DockStyle.Fill;

            panelControl.Controls.Clear();

            panelControl.Controls.Add(listagem);
        }

        public void CarregarBotoes(GerenciadorFormulario gerenciador)
        {

        }

        private void btnCadastrar_Click(object sender, EventArgs e)
        {
            if (_gerenciador != null)
            {
                _gerenciador.Adicionar();
            }
            else
            {
                MessageBox.Show("Selecione o contexto", "Atenção",
                   MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnDepositar_Click(object sender, EventArgs e)
        {
            if (_gerenciadorContaCorrente != null)
            {
                _gerenciadorContaCorrente.Depositar();
            }
            else
            {
                MessageBox.Show("Selecione o contexto", "Atenção",
                   MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {  
            if (_gerenciador != null)
            {
                _gerenciador.Excluir();
            }
            else
            {
                MessageBox.Show("Selecione o contexto", "Atenção",
                   MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnSaque_Click(object sender, EventArgs e)
        {         
            if (_gerenciadorContaCorrente != null)
            {
                _gerenciadorContaCorrente.Sacar();
            }
            else
            {
                MessageBox.Show("Selecione o contexto", "Atenção",
                   MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnTransferir_Click(object sender, EventArgs e)
        {
            if (_gerenciadorContaCorrente != null)
            {
                _gerenciadorContaCorrente.Transferir();
            }
            else
            {
                MessageBox.Show("Selecione o contexto", "Atenção",
                   MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnExtrato_Click(object sender, EventArgs e)
        {
            if (_gerenciadorContaCorrente != null)
            {
                _gerenciadorContaCorrente.Extrato();
            }
            else
            {
                MessageBox.Show("Selecione o contexto", "Atenção",
                   MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }



        private void tsLabel_Click(object sender, EventArgs e)
        {

        }
    }
}

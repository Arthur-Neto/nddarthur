using Pizzaria.Aplicacao.Features.Clientes;
using Pizzaria.Dominio.Exceptions;
using Pizzaria.Dominio.Features.Clientes;
using Pizzaria.Dominio.Features.Enderecos;
using Pizzaria.Infra.Features.CEP;
using Pizzaria.WinApp.Base;
using System;
using System.Windows.Forms;

namespace Pizzaria.WinApp.Features.Clientes
{
    public partial class FormCadastrarCliente : FormCadastroBasico<Cliente>
    {
        UserControlBasico<Cliente> userControl;
        ClienteServico _servico;

        public FormCadastrarCliente(ClienteServico servico, bool ehSelecionar = true)
        {
            InitializeComponent();
            _servico = servico;
            InicializarListaDeClientes();
            if (ehSelecionar == false)
            {
                btnSelecionar.Enabled = false;
                btnNovo.Enabled = true;
                btnEditar.Enabled = true;
            }
            else
            {
                base.DesabilitarBotoesBase();
            }
        }

        private void InicializarListaDeClientes()
        {
            userControl = new UserControlBasico<Cliente>();
            userControl.Dock = DockStyle.Fill;
            panelClientes.Controls.Clear();
            panelClientes.Controls.Add(userControl);
            userControl.PopularListagem(_servico.ObterTodos());
        }

        private void btnSelecionar_Click(object sender, EventArgs e)
        {
            Entidade = userControl.ObterItemSelecionado();

            if (_entidade != null && _entidade.Id != 0)
                DialogResult = DialogResult.OK;

            else
                MessageBox.Show("Selecione um cliente na lista", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        private void PopularCliente(Cliente cliente)
        {
            txtNome.Text = cliente.Nome;
            mskTel.Text = cliente.Telefone;
            mskCpf.Text = cliente.CPF;
            mskCnpj.Text = cliente.CNPJ;
            dtpNasc.Value = cliente.DataDeNascimento;
            PopularEndereco(cliente.Endereco);
        }
        private void PopularEndereco(Endereco endereco)
        {
            txtUf.Text = endereco.Estado;
            txtCidade.Text = endereco.Cidade;
            txtBairro.Text = endereco.Bairro;
            txtComplemento.Text = endereco.Complemento;
            txtRua.Text = endereco.Rua;
            mskCep.Text = endereco.Cep;
        }

        private void btnLocalizar_Click(object sender, EventArgs e)
        {
            PostmonApi postmon = new PostmonApi();
            var endereco = postmon.LocalizarEndereco(mskCep.Text);
            PopularEndereco(endereco);
        }

        private void btnNovo_Click(object sender, EventArgs e)
        {
            pnlDadosCliente.Enabled = true;
            _entidade = null;
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            pnlDadosCliente.Enabled = true;
            _entidade = userControl.ObterItemSelecionado();
            PopularCliente(_entidade);
        }

        protected override void Salvar()
        {
            try
            {
                pnlDadosCliente.Enabled = false;
                AtribuirValores();
                _entidade.Validar();
            }
            catch (BusinessException log)
            {
                DialogResult = DialogResult.None;
                MostrarErro(log.Message);
            }
            catch (Exception log)
            {
                DialogResult = DialogResult.None;
                MostrarErro(log.Message);
            }
        }

        protected override void AtribuirValores()
        {
            if (_entidade == null)
            {
                _entidade = new Cliente();
                _entidade.Endereco = new Endereco();
            }
            _entidade.Nome = txtNome.Text;
            _entidade.CNPJ = mskCnpj.Text;
            _entidade.CPF = mskCpf.Text;
            _entidade.DataDeNascimento = dtpNasc.Value;
            _entidade.Telefone = mskTel.Text;

            _entidade.Endereco.Cep = mskCep.Text;
            _entidade.Endereco.Estado = txtUf.Text;
            _entidade.Endereco.Cidade = txtCidade.Text;
            _entidade.Endereco.Bairro = txtBairro.Text;
            _entidade.Endereco.Rua = txtRua.Text;
            _entidade.Endereco.Numero = Convert.ToInt32(nudCasa.Value);
            _entidade.Endereco.Complemento = txtComplemento.Text;
        }

        protected override void MostrarValores()
        {
            base.MostrarValores();
        }

        protected override void LimparValores()
        {
            base.LimparValores();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            userControl.PopularListagem(_servico.BuscarPorTelefone(mskTelBusca.Text));
        }

        private void button1_Click(object sender, EventArgs e)
        {
            mskTelBusca.Text = string.Empty;
            InicializarListaDeClientes();
        }

    }
}

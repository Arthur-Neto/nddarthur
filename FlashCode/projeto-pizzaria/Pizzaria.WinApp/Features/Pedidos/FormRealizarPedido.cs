using Pizzaria.Aplicacao.Features.Clientes;
using Pizzaria.Aplicacao.Features.Pedidos;
using Pizzaria.Aplicacao.Features.Produtos;
using Pizzaria.Dominio.Exceptions;
using Pizzaria.Dominio.Features.Clientes;
using Pizzaria.Dominio.Features.ItensPedidos;
using Pizzaria.Dominio.Features.Pedidos;
using Pizzaria.Dominio.Features.Produtos;
using Pizzaria.WinApp.Base;
using Pizzaria.WinApp.Features.Clientes;
using System;
using System.Windows.Forms;

namespace Pizzaria.WinApp.Features.Pedidos
{
    public partial class FormRealizarPedido : FormCadastroBasico<Pedido>
    {
        #region Objetos
        private PedidoServico _pedidoServico;
        private ProdutoServico _produtoServico;
        private ClienteServico _clienteServico;
        private Cliente _cliente;

        Produto _primeiroSabor;
        Produto _segundoSabor = null;
        Produto _adicional = null;

        #endregion
        public FormRealizarPedido(PedidoServico pedidoServico, ProdutoServico produtoServico, ClienteServico clienteServico)
        {
            InitializeComponent();

            _pedidoServico = pedidoServico;
            _produtoServico = produtoServico;
            _clienteServico = clienteServico;
            _entidade = new Pedido();

            PopularSaboresPizza();
            PopularSaboresCalzone();
            PopularSaboresBebida();
            PopularSaboresBorda();
        }

        public void DisplayComboBox()
        {
            comboBoxSaborBebida.DisplayMember = "Sabor";
            comboBoxSaborBebida.Name = "Sabor";

            cmbAdicional.DisplayMember = "Sabor";
            cmbAdicional.Name = "Sabor";

            comboBoxSaborCalzone.DisplayMember = "Sabor";
            comboBoxSaborCalzone.Name = "Sabor";

            comboBoxPrimeiroSabor.DisplayMember = "Sabor";
            comboBoxPrimeiroSabor.Name = "Sabor";

            comboBoxSegundoSabor.DisplayMember = "Sabor";
            comboBoxSegundoSabor.Name = "Sabor";
        }
        private void PopularSaboresBorda()
        {
            var lista = _produtoServico.ObterAdicionais(ConverterParaTamanho());
            if (lista == null)
                return;

            cmbAdicional.Items.Clear();
            DisplayComboBox();
            foreach (var item in lista)
            {
                cmbAdicional.Items.Add(item);
            }
        }

        private void PopularSaboresCalzone()
        {
            var lista = _produtoServico.ObterCalzones(TamanhoEnum.PADRAO);
            if (lista == null)
                return;

            comboBoxSaborCalzone.Items.Clear();
            DisplayComboBox();
            foreach (var item in lista)
            {
                comboBoxSaborCalzone.Items.Add(item);
            }
        }

        private void PopularSaboresBebida()
        {
            var lista = _produtoServico.ObterBebidas();
            if (lista == null)
                return;

            comboBoxSaborBebida.Items.Clear();
            DisplayComboBox();
            foreach (var item in lista)
            {
                comboBoxSaborBebida.Items.Add(item);
            }
        }

        private void PopularSaboresPizza()
        {
            comboBoxPrimeiroSabor.Items.Clear();
            comboBoxSegundoSabor.Items.Clear();
            DisplayComboBox();

            var list = _produtoServico.ObterPizzas(ConverterParaTamanho());

            if (list == null)
                return;

            foreach (var item in list)
            {
                comboBoxPrimeiroSabor.Items.Add(item);
                comboBoxSegundoSabor.Items.Add(item);
            }
        }
        protected override void AtribuirValores()
        {
            if (base._entidade == null)
            {
                base._entidade = new Pedido();
            }
            base._entidade.Cliente = _cliente;
            base._entidade.Data = DateTime.Now;
            base._entidade.NF = checkBoxEmitirNota.Checked;
            base._entidade.TipoPagamento = ConverterParaTipoPagamento();
            base._entidade.Status = StatusPedidoEnum.AGUARDANDO_MONTAGEM;
        }

        private TipoPagamentoEnum ConverterParaTipoPagamento()
        {
            if (radioButtonDinheiro.Checked)
                return TipoPagamentoEnum.Dinheiro;
            else
            {
                if (comboBoxTipoCartao.SelectedItem.Equals("Visa"))
                    return TipoPagamentoEnum.Visa;
                else
                    return TipoPagamentoEnum.MasterCard;
            }
        }

        protected override void LimparValores()
        {
            checkBoxDoisSabores.Checked = false;
            comboBoxPrimeiroSabor.Items.Clear();
            comboBoxSaborBebida.Items.Clear();
            comboBoxSaborCalzone.Items.Clear();
            comboBoxSegundoSabor.Items.Clear();

            PopularSaboresPizza();
            PopularSaboresCalzone();
            PopularSaboresBebida();
            PopularSaboresBorda();
        }

        protected override void MostrarValores()
        {
            base.MostrarValores();
        }

        protected override void Salvar()
        {
            try
            {
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

        public ItemPedido ObterPizza()
        {
            _primeiroSabor = comboBoxPrimeiroSabor.SelectedItem as Produto;

            if (checkBoxDoisSabores.Checked)
                _segundoSabor = comboBoxSegundoSabor.SelectedItem as Produto;

            if (checkBoxAdicional.Checked)
                _adicional = cmbAdicional.SelectedItem as Produto;

            var itemPedidoPizza = new ItemPedido();
            itemPedidoPizza.Adicionar(_primeiroSabor, _segundoSabor, _adicional);

            return itemPedidoPizza;
        }

        public ItemPedido ObterCalzone()
        {
            var calzone = comboBoxSaborCalzone.SelectedItem as Produto;
            var itemPedidoCalzone = new ItemPedido();
            itemPedidoCalzone.Adicionar(calzone);
            return itemPedidoCalzone;
        }
        public ItemPedido ObterBebida()
        {
            var bebida = comboBoxSaborBebida.SelectedItem as Produto;
            var itemPedidoBebida = new ItemPedido();
            itemPedidoBebida.Adicionar(bebida);
            return itemPedidoBebida;
        }
        private void buttonAdicionarItem_Click(object sender, EventArgs e)
        {
            if (_entidade == null)
                _entidade = new Pedido();

            if (ValidarCampos() == true)
            {

                if (tabControlProdutos.SelectedTab == tabPagePizza)
                    _entidade.AdicionarItems(ObterPizza());
                else if (tabControlProdutos.SelectedTab == tabPageCalzone)
                    _entidade.AdicionarItems(ObterCalzone());
                else
                    _entidade.AdicionarItems(ObterBebida());

                AtualizarCarrinho();
                LimparValores();
            }
        }

        private bool ValidarCampos()
        {
            bool retorno = true;
            var tabControl = tabControlProdutos.SelectedTab;
            var pizzaSelecionada = comboBoxPrimeiroSabor.SelectedItem;
            var calzoneSelecionado = comboBoxSaborCalzone.SelectedItem;
            var bebidaSelecionada = comboBoxSaborBebida.SelectedItem;

            if (tabControl == tabPagePizza)
                if (pizzaSelecionada == null)
                    retorno = false;

            if (tabControl == tabPageCalzone)
                if (calzoneSelecionado == null)
                    retorno = false;

            if (tabControl == tabPageBebida)
                if (bebidaSelecionada == null)
                    retorno = false;

            return retorno;
        }

        private void AtualizarCarrinho()
        {

            _primeiroSabor = null;
            _segundoSabor = null;
            _adicional = null;

            listCarrinhoItens.Items.Clear();

            foreach (var item in _entidade.Itens)
                listCarrinhoItens.Items.Add(item);

            labelValorPagar.Text = _entidade.ValorTotal.ToString();
        }

        private void buttonRemoverItem_Click(object sender, EventArgs e)
        {
            var selecionado = listCarrinhoItens.SelectedItem as ItemPedido;

            if (selecionado != null)
            {
                _entidade.RemoverItem(selecionado);
                AtualizarCarrinho();
            }
        }
        private TamanhoEnum ConverterParaTamanho()
        {
            if (radioButtonTamanhoPequena.Checked)
                return TamanhoEnum.PEQUENA;
            else if (radioButtonTamanhoMedia.Checked)
                return TamanhoEnum.MEDIA;
            else
                return TamanhoEnum.GRANDE;
        }


        private void checkBoxDoisSabores_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxDoisSabores.Checked == true)
                comboBoxSegundoSabor.Enabled = true;
            else
                comboBoxSegundoSabor.Enabled = false;

        }

        private void checkBoxEmitirNota_CheckedChanged(object sender, EventArgs e)
        {

            if (checkBoxEmitirNota.Checked == true)
                textBoxNotaFiscal.Enabled = true;
            else
                textBoxNotaFiscal.Enabled = false;
        }

        private void btnSelecionarCliente_Click(object sender, EventArgs e)
        {
            FormCadastrarCliente formCliente = new FormCadastrarCliente(_clienteServico);
            if (formCliente.ShowDialog() == DialogResult.OK)
            {
                _cliente = formCliente.Entidade;
                _entidade.Cliente = _cliente;
                txtCliente.Text = _cliente.Nome;

                if (!string.IsNullOrEmpty(_cliente.CNPJ))
                {
                    textBoxNotaFiscal.Text = _cliente.CNPJ;
                    textBoxNotaFiscal.Enabled = true;
                    textBoxDepartamento.Enabled = true;
                    textBoxResponsavel.Enabled = true;
                }
            }
        }

        private void radioButtonTamanhoGrande_CheckedChanged(object sender, EventArgs e)
        {
            PopularSaboresPizza();
            PopularSaboresBorda();
        }

        private void radioButtonTamanhoMedia_CheckedChanged(object sender, EventArgs e)
        {
            PopularSaboresPizza();
            PopularSaboresBorda();
        }

        private void radioButtonTamanhoPequena_CheckedChanged(object sender, EventArgs e)
        {
            PopularSaboresPizza();
            PopularSaboresBorda();
        }

        private void checkBoxAdicional_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxAdicional.Checked)
                cmbAdicional.Enabled = true;
            else
                cmbAdicional.Enabled = false;
        }

        private void radioButtonCartao_CheckedChanged(object sender, EventArgs e)
        {
            comboBoxTipoCartao.Enabled = true;
        }
    }
}

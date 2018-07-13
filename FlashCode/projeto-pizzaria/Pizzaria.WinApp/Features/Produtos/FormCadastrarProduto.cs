using Pizzaria.Aplicacao.Features.Produtos;
using Pizzaria.Dominio.Exceptions;
using Pizzaria.Dominio.Features.Produtos;
using Pizzaria.Dominio.Features.Produtos.Adicionais;
using Pizzaria.Dominio.Features.Produtos.Bebidas;
using Pizzaria.Dominio.Features.Produtos.Calzones;
using Pizzaria.Dominio.Features.Produtos.Pizzas;
using Pizzaria.WinApp.Base;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Pizzaria.WinApp.Features.Produtos
{
    public partial class FormCadastrarProduto : FormCadastroBasico<Produto>
    {
        Pizza pizzaPequena = new Pizza();
        Pizza pizzaMedia = new Pizza();
        Pizza pizzaGrande = new Pizza();
        Adicional adicionalPequeno = new Adicional();
        Adicional adicionalMedio = new Adicional();
        Adicional adicionalGrande = new Adicional();
        ProdutoServico _produtoServico;

        public List<Produto> ListaProdutos { get; set; }

        public FormCadastrarProduto(ProdutoServico produtoServico)
        {
            ListaProdutos = new List<Produto>();
            _produtoServico = produtoServico;
            InitializeComponent();
            comboBoxTipoProduto.SelectedItem = "Pizza";
        }

        protected override void AtribuirValores()
        {
            var produto = ObterSelecionado();

            if (base._entidade == null)
            {
                base._entidade = produto;
            }

            ConverterParaObjeto();
        }

        private Produto ObterSelecionado()
        {
            Produto produto = null;

            var selecionado = comboBoxTipoProduto.SelectedItem;

            if (selecionado.Equals("Pizza"))
            {
                produto = new Pizza();
            }
            else if (selecionado.Equals("Calzone"))
            {
                produto = new Calzone();
            }
            else if (selecionado.Equals("Bebida"))
            {
                produto = new Bebida();
            }
            else
            {
                produto = new Adicional();
            }

            return produto;
        }

        private void ConverterParaObjeto()
        {
            var produto = ObterSelecionado();
            produto.Sabor = txtSabor.Text;

            if (produto is Pizza)
            {
                if (checkBoxPequena.Checked)
                {
                    pizzaPequena.Tamanho = TamanhoEnum.PEQUENA;
                    pizzaPequena.Sabor = produto.Sabor;
                    pizzaPequena.Valor = Convert.ToDouble(numericUpDownPequena.Value);
                    ListaProdutos.Add(pizzaPequena);
                }

                if (checkBoxMedia.Checked)
                {
                    pizzaMedia.Tamanho = TamanhoEnum.MEDIA;
                    pizzaMedia.Valor = Convert.ToDouble(numericUpDownMedia.Value);
                    pizzaMedia.Sabor = produto.Sabor;
                    ListaProdutos.Add(pizzaMedia);
                }

                if (checkBoxGrande.Checked)
                {
                    pizzaGrande.Tamanho = TamanhoEnum.GRANDE;
                    pizzaGrande.Valor = Convert.ToDouble(numericUpDownGrande.Value);
                    pizzaGrande.Sabor = produto.Sabor;
                    ListaProdutos.Add(pizzaGrande);
                }
            }

            else if (produto is Adicional)
            {
                if (checkBoxPequena.Checked)
                {
                    adicionalPequeno.Tamanho = TamanhoEnum.PEQUENA;
                    adicionalPequeno.Valor = Convert.ToDouble(numericUpDownPequena.Value);
                    adicionalPequeno.Sabor = produto.Sabor;
                    ListaProdutos.Add(adicionalPequeno);
                }

                if (checkBoxMedia.Checked)
                {
                    adicionalGrande.Tamanho = TamanhoEnum.MEDIA;
                    adicionalGrande.Valor = Convert.ToDouble(numericUpDownMedia.Value);
                    adicionalGrande.Sabor = produto.Sabor;
                    ListaProdutos.Add(adicionalGrande);
                }
                if (checkBoxGrande.Checked)
                {
                    adicionalMedio.Tamanho = TamanhoEnum.GRANDE;
                    adicionalMedio.Valor = Convert.ToDouble(numericUpDownGrande.Value);
                    adicionalMedio.Sabor = produto.Sabor;
                    ListaProdutos.Add(adicionalMedio);
                }
            }

            else
            {
                produto.Tamanho = TamanhoEnum.PADRAO;
                produto.Valor = Convert.ToDouble(numericUpDownValorPadrao.Value);
                ListaProdutos.Add(produto);
            }
        }

        protected override void LimparValores()
        {
            base.LimparValores();
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

                foreach (var item in ListaProdutos)
                {
                    item.Validar();
                }
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

        private void comboBoxProdutos_SelectedIndexChanged(object sender, EventArgs e)
        {
            var produto = ObterSelecionado();

            if (produto is Pizza)
            {
                groupBoxPizza.Enabled = true;
                groupBoxTamanhoPadrao.Enabled = false;
            }
            else if (produto is Calzone)
            {
                checkBoxTamanhoPadrao.Enabled = false;
                groupBoxPizza.Enabled = false;
                groupBoxTamanhoPadrao.Enabled = true;
            }
            else if (produto is Bebida)
            {
                checkBoxTamanhoPadrao.Enabled = false;
                groupBoxPizza.Enabled = false;
                groupBoxTamanhoPadrao.Enabled = true;
            }
            else if (produto is Adicional)
            {
                checkBoxTamanhoPadrao.Enabled = false;
                groupBoxPizza.Enabled = true;
                groupBoxTamanhoPadrao.Enabled = false;

            }
        }
    }
}

using Pizzaria.Aplicacao.Base;
using Pizzaria.Aplicacao.Features.Produtos;
using Pizzaria.Dominio.Features.Produtos;
using Pizzaria.Infra.Base;
using Pizzaria.WinApp.Base;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Pizzaria.WinApp.Features.Produtos
{
    public class GerenciadorFormularioProduto    : GerenciadorFormulario<Produto>
    {
        private UserControlBasico<Produto> _controle;
        private ProdutoServico _produtoServico;

        public GerenciadorFormularioProduto(ProdutoServico produtoServico)
        {
            _produtoServico = produtoServico;
        }

        public override FormCadastroBasico<Produto> ObterDialogoCadastro()
        {
            return new FormCadastrarProduto(_produtoServico);
        }
        public override void Adicionar()
        {
            FormCadastrarProduto formCadastrar = new FormCadastrarProduto(_produtoServico);
            if(formCadastrar.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    _produtoServico.AdicionarItens(formCadastrar.ListaProdutos);
                    IEnumerable<Produto> entidades = ObterServico().ObterTodos();
                    ObterLista().PopularListagem(entidades);
                }
                catch(Exception ex)
                {
                    MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        public override EstadoBotao ObterEstadoBotao()
        {
            return new EstadoBotao()
            {
                Adicionar = true,
                Atualizar = true,
                Excluir = true,
                Pesquisar = false
            };
        }

        public override UserControlBasico<Produto> ObterLista()
        {
            if (_controle == null)
            {
                _controle = new UserControlBasico<Produto>();
                IEnumerable<Produto> produtos = ObterServico().ObterTodos();

                ObterLista().PopularListagem(produtos);
            }

            return _controle;
        }

        public override IServico<Produto> ObterServico()
        {
            if (_produtoServico == null)
                _produtoServico = new ProdutoServico(RepositorioIoC.RepositorioProduto);
            return _produtoServico;
        }

        public override string ObterTitulo()
        {
            return "Cadastro de produtos";
        }

        public override TituloBotao ObterTituloBotao()
        {
            return new TituloBotao()
            {
                Adicionar = "Adicionar produto",
                Atualizar = "Atualizar produto",
                Excluir = "Excluir produto",
                Pesquisar = "Pesquisar produto"
            };
        }

        public override VisibilidadeBotao ObterVisibilidadeBotao()
        {
            return new VisibilidadeBotao()
            {
                Adicionar = true,
                Atualizar = true,
                Excluir = true,
                Pesquisar = true
            };
        }
    }
}

using Projeto_NFe.Dominio.Excecoes;

namespace Projeto_NFe.Dominio.Features.ProdutosNFe.Excecoes
{
    public class ListaProdutosVazia : ExcecaoDeNegocio
    {
        public ListaProdutosVazia() : base("Lista de produtos está vazia!")
        {
        }
    }
}

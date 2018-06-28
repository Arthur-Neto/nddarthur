using Projeto_NFe.Dominio.Excecoes;

namespace Projeto_NFe.Dominio.Features.NotasFiscais.Excecoes
{
    public class ExcecaoProdutosVazio : ExcecaoDeNegocio
    {
        public ExcecaoProdutosVazio() : base("Você precisa adicionar pelo menos um produto!")
        {
        }
    }
}

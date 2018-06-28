using Projeto_NFe.Dominio.Excecoes;

namespace Projeto_NFe.Dominio.Features.Produtos.Excecoes
{
    public class ExcecaoValorTotalNegativo : ExcecaoDeNegocio
    {
        public ExcecaoValorTotalNegativo() : base("O valor total não pode ser negativo!")
        {
        }
    }
}

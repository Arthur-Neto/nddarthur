using Pizzaria.Dominio.Exceptions;

namespace Pizzaria.Dominio.Features.Produtos.Excecoes
{
    public class TamanhoInvalidoExcecao : BusinessException
    {
        public TamanhoInvalidoExcecao() : base("Tamanho não definido")
        {
        }

    }
}
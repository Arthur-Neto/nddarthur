using Pizzaria.Dominio.Exceptions;

namespace Pizzaria.Dominio.Features.Produtos.Excecoes
{
    public class SaborInvalidoExcecao : BusinessException
    {

        public SaborInvalidoExcecao() : base("Sabor não definido")
        {
        }

    }
}
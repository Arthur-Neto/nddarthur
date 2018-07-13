using Pizzaria.Dominio.Features.Produtos;
using Pizzaria.Dominio.Features.Produtos.Adicionais;
using Pizzaria.Dominio.Features.Produtos.Bebidas;
using Pizzaria.Dominio.Features.Produtos.Calzones;
using Pizzaria.Dominio.Features.Produtos.Pizzas;

namespace Pizzaria.Common.Testes.Features
{
    public static partial class ObjetoMae
    {
        public static Pizza ObterPizza(TamanhoEnum tamanho)
        {
            var pizza = new Pizza();

            pizza.Id = 0;
            pizza.Sabor = "Sabor";
            pizza.Tamanho = tamanho;
            pizza.Valor = 15;

            return pizza;
        }

        public static Adicional ObterAdicional(TamanhoEnum tamanho)
        {
            var adicional = new Adicional();

            adicional.Id = 0;
            adicional.Sabor = "Sabor";
            adicional.Tamanho = tamanho;
            adicional.Valor = 1.5;

            return adicional;
        }

        public static Bebida ObterBebida()
        {
            var bebida = new Bebida();

            bebida.Id = 0;
            bebida.Sabor = "Sabor";
            bebida.Tamanho = TamanhoEnum.PADRAO;
            bebida.Valor = 1.5;

            return bebida;
        }


        public static Calzone ObterCalzone(TamanhoEnum tamanho)
        {
            return new Calzone
            {
                Id = 0,
                Sabor = "Sabor",
                Tamanho = tamanho,
                Valor = 1.5,
            };
        }
    }
}

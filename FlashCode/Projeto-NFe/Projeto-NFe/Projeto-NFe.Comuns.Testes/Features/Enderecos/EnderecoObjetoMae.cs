using Projeto_NFe.Dominio.Features.Enderecos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto_NFe.Comuns.Testes.Features.Enderecos
{
    public static class EnderecoObjetoMae
    {
        public static Endereco ObterValido()
        {
            return new Endereco
            {
                ID = 1,
                Bairro = "Coral",
                Cep = "88523-060",
                Cidade = "Lages",
                Numero = 431,
                Pais = "Brasil",
                Rua = "Rua Dr. Walmor Ribeiro",
                UF = "SC",
            };
        }
    }
}

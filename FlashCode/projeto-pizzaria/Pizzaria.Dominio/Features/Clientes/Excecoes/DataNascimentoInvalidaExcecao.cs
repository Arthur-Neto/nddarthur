using System;
using System.Runtime.Serialization;

namespace Pizzaria.Dominio.Features.Clientes
{
    [Serializable]
    public class DataNascimentoInvalidaExcecao : Exception
    {
        public DataNascimentoInvalidaExcecao() : base("Data nascimento invalido")
        {
        }
    }
}
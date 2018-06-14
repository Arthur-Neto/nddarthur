using System;
using System.Diagnostics.CodeAnalysis;

namespace NFe.Dominio.Exceptions
{
    [ExcludeFromCodeCoverage]
    public class ParmsIsNullOrEmpty : Exception
    {
        public ParmsIsNullOrEmpty(string campo) : base("O " + campo + " não pode ser vazio ou nulo")
        {

        }
    }
}

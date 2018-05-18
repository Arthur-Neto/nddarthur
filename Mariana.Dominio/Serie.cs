using Mariana.Dominio.Exceptions;
using System;

namespace Mariana.Dominio
{
    public class Serie : Entidade
    {
        public int NumeroSerie { get; set; }

        public override string ToString()
        {
            return String.Format(NumeroSerie + "ª série");
        }

        public override void Validar()
        {
            if (NumeroSerie < 1 || NumeroSerie > 9)
                throw new ValidacaoException("O número da série não pode ser negativo e nem maior que 9.");
        }
    }
}

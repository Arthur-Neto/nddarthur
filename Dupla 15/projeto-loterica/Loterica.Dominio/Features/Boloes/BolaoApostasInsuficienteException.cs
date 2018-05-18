using Loterica.Dominio.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Loterica.Dominio.Features.Boloes
{
    public class BolaoApostasInsuficienteException : BusinessException
    {
        public BolaoApostasInsuficienteException() : base("O numero de apostas deve ser maior que 2")
        {
        }
    }
}

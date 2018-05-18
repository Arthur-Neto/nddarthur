using Loterica.Dominio.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Loterica.Dominio.Features.Concursos
{
    public class ConcursoNumeroInsuficienteException : BusinessException
    {
        public ConcursoNumeroInsuficienteException() : base("O Concurso deve conter pelo menos seis numeros")
        {
        }
    }
}

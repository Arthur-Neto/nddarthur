using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NFe.Infra.XML.Exceptions
{
    public class NotaFiscalXmlNulaException : Exception
    {
        public NotaFiscalXmlNulaException() : base("A nota fiscal não pode ser nula")
        {

        }
    }
}

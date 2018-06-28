using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto_NFe.Dominio.Features.NotasFiscais
{
    public interface INotaFiscalExportacao
    {
        bool Exportar(NotaFiscal notaFiscal);
    }
}

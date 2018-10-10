using Projeto_NFe.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto_NFe.Domain.Funcionalidades.Nota_Fiscal
{
    public interface INotaFiscalEmitidaRepositorio
    {
        long Adicionar(string xml,string chaveDeAcesso);

        long ConsultarExistenciaDeNotaEmitida(string chaveDeAcesso);

        NotaFiscal BuscarNotaFiscalEmitidaPorChave(string chaveDeAcesso);
    }
}

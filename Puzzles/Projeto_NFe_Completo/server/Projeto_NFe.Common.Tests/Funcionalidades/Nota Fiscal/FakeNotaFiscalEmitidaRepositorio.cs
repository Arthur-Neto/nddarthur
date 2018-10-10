using Projeto_NFe.Domain.Funcionalidades.Nota_Fiscal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto_NFe.Common.Tests.Funcionalidades.Nota_Fiscal
{
    public class FakeNotaFiscalEmitidaRepositorio : INotaFiscalEmitidaRepositorio
    {
        public static int _count = 0;

        public long Adicionar(string xml, string chaveDeAcesso)
        {
            long idRetornado = 1;
            return idRetornado;
        }

        public NotaFiscal Atualizar(NotaFiscal notaFiscal)
        {
            throw new NotImplementedException();
        }

        public NotaFiscal BuscarNotaFiscalEmitidaPorChave(string chaveDeAcesso)
        {
            throw new NotImplementedException();
        }

        public NotaFiscal BuscarPorId(long Id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<NotaFiscal> BuscarTodos()
        {
            throw new NotImplementedException();
        }

        public virtual long ConsultarExistenciaDeNotaEmitida(string chaveDeAcesso)
        {
            if (_count < 2)
            {
                _count++;
                return 1;
            }
            else
                return 0;
        }

        public void Excluir(NotaFiscal notaFiscal)
        {
            throw new NotImplementedException();
        }
    }
}

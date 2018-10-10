using Projeto_NFe.Domain.Funcionalidades.Nota_Fiscal;
using Projeto_NFe.Infrastructure.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto_NFe.Infrastructure.Data.Funcionalidades.Nota_Fiscal
{
    public class NotaFiscalEmitidaRepositorioSql : INotaFiscalEmitidaRepositorio
    {
        #region Scripts SQL

        public const string _sqlAdicionar = @"INSERT INTO TBNOTAFISCALEMITIDA 
                                            (CHAVEDEACESSO,XML) 
                                            VALUES 
                                            ({0}CHAVEDEACESSO,{0}XML);SELECT SCOPE_IDENTITY();";

        public const string _sqlBuscarPorId = @"SELECT * FROM TBNOTAFISCALEMITIDA 
                                              WHERE ID = {0}ID";

        public const string _sqlBuscarPorChaveDeAcesso = @"SELECT * FROM TBNOTAFISCALEMITIDA 
                                              WHERE CHAVEDEACESSO = {0}CHAVEDEACESSO";


        public const string _sqlExcluir = @"DELETE FROM TBNOTAFISCALEMITIDA
                                             WHERE ID = {0}ID";

        public const string _sqlBuscarTodos = @"SELECT * FROM TBNOTAFISCALEMITIDA";

        public const string _sqlConsultaExistenciaDeNotaChaveDeAcesso = @"SELECT * FROM TBNOTAFISCALEMITIDA";

        #endregion Scripts SQL

        public long Adicionar(string xmlNotaFiscal, string chaveDeAcesso)
        {
           return Db.Adicionar(_sqlAdicionar, new Dictionary<string, object> { { "CHAVEDEACESSO", chaveDeAcesso }, { "XML", xmlNotaFiscal } });
        }

        public NotaFiscal BuscarNotaFiscalEmitidaPorChave(string chaveDeAcesso)
        {
            throw new NotImplementedException();
        }

        public long ConsultarExistenciaDeNotaEmitida(string chaveDeAcesso)
        {
            return Db.Adicionar(_sqlConsultaExistenciaDeNotaChaveDeAcesso, new Dictionary<string, object> { { "CHAVEDEACESSO", chaveDeAcesso } });
        }
    }
}

using Projeto_NFe.Dominio.Excecoes;
using Projeto_NFe.Dominio.Features.Destinatarios;
using Projeto_NFe.Dominio.Features.Emitentes;
using Projeto_NFe.Dominio.Features.NotasFiscais;
using Projeto_NFe.Dominio.Features.Transportadores;
using Projeto_NFe.Infra.SQL;
using Projeto_NFe.Infra.Xml.Features.NotasFiscais;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto_NFe.Infra.Data.Features.NotasFiscais
{
    public class NotaFiscalRepositorioSql : INotaFiscalRepositorio
    {
        #region Script's SQL
        private string _sqlInserir = @"INSERT INTO [dbo].[NotaFiscal]
                                                       ([ValorFrete]
                                                       ,[ValorTotalNota]
                                                       ,[NaturezaOperacao]
                                                       ,[DataEmissao]
                                                       ,[DataEntrada]
                                                       ,[Chave]
                                                       ,[DestinatarioID]
                                                       ,[EmitenteID]
                                                       ,[TransportadorID])
                                                 VALUES
                                                       ({0}ValorFrete
                                                       ,{0}ValorTotalNota
                                                       ,{0}NaturezaOperacao
                                                       ,{0}DataEmissao
                                                       ,{0}DataEntrada
                                                       ,{0}Chave
                                                       ,{0}DestinatarioID
                                                       ,{0}EmitenteID
                                                       ,{0}TransportadorID)";

        private string _sqlDeletar = @"DELETE FROM [dbo].[NotaFiscal] WHERE Id = {0}ID";

        private string _sqlAtualizar = @"UPDATE [dbo].[NotaFiscal]
                                                   SET [ValorFrete] = {0}ValorFrete
                                                      ,[ValorTotalNota] = {0}ValorTotalNota
                                                      ,[NaturezaOperacao] = {0}NaturezaOperacao
                                                      ,[DataEmissao] = {0}DataEmissao
                                                      ,[DataEntrada] = {0}DataEntrada
                                                      ,[Chave] = {0}Chave
                                                      ,[DestinatarioID] = {0}DestinatarioID
                                                      ,[EmitenteID] = {0}EmitenteID
                                                      ,[TransportadorID] = {0}TransportadorID
                                                 WHERE Id = {0}Id";

        private string _sqlObterPorId = @"select * from NotaFiscal WHERE Id = {0}Id";

        private string _sqlObterPorDestinatarioId = @"select * from NotaFiscal WHERE DestinatarioID = {0}DestinatarioID";

        private string _sqlObterPorEmitenteId = @"select * from NotaFiscal WHERE EmitenteID = {0}EmitenteID";

        private string _sqlObterPorTransportadorId = @"select * from NotaFiscal WHERE TransportadorID = {0}TransportadorID";

        private string _sqlObterTodos = @"select * from NotaFiscal";

        private string _sqlObterPorChave = @"select NotaFiscalXML from NotaFiscalEmitida where Chave = {0}Chave";

        private string _sqlInserirNotaFiscalEmitida = @"insert into NotaFiscalEmitida (Chave, NotaFiscalXML) values ({0}Chave, {0}NotaFiscalXML)";
        #endregion
        NotaFiscalXmlRepository NotaFiscalXmlRepository = new NotaFiscalXmlRepository(Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "a.xml");

        public NotaFiscal Atualizar(NotaFiscal notaFiscal)
        {
            if (notaFiscal.ID < 1)
                throw new ExcecaoIdentificadorInvalido();

            notaFiscal.Validar();

            Db.Update(_sqlAtualizar, ObtemParametros(notaFiscal));

            return notaFiscal;
        }

        public bool Deletar(long id)
        {
            if (id < 1)
                throw new ExcecaoIdentificadorInvalido();

            var parms = new Dictionary<string, object> { { "ID", id } };

            int linhasAfetadas = Db.Delete(_sqlDeletar, parms);

            if (linhasAfetadas < 1) return false;

            return true;
        }

        public NotaFiscal Inserir(NotaFiscal notaFiscal)
        {
            notaFiscal.Validar();

            notaFiscal.ID = Db.Insert(_sqlInserir, ObtemParametros(notaFiscal));

            return notaFiscal;
        }

        public void InserirNotaFiscalEmitida(NotaFiscal notaFiscal)
        {
            Db.Insert(_sqlInserirNotaFiscalEmitida, ObtemParametrosNotaFiscalEmitida(notaFiscal));
        }

        public bool ValidarExistenciaPorChave(string chave)
        {
            var parms = new Dictionary<string, object> { { "Chave", chave } };

            var notaFiscalEmitida = Db.Get(_sqlObterPorChave, SetarParmetrosNotaFiscalEmitida, parms);

            if (notaFiscalEmitida == null)
                return false;

            return true;

        }

        public NotaFiscal ObterPorDestinatarioID(long destinatarioID)
        {
            var parms = new Dictionary<string, object> { { "DestinatarioID", destinatarioID } };

            var nfe = Db.Get<NotaFiscal>(_sqlObterPorDestinatarioId, SetarParmetros, parms);

            if (nfe == null) return null;

            return nfe;
        }

        public NotaFiscal ObterPorEmitenteID(long emitenteID)
        {
            var parms = new Dictionary<string, object> { { "EmitenteID", emitenteID } };

            var nfe = Db.Get<NotaFiscal>(_sqlObterPorEmitenteId, SetarParmetros, parms);

            if (nfe == null) return null;

            return nfe;
        }

        public NotaFiscal ObterPorId(long id)
        {
            if (id < 1)
                throw new ExcecaoIdentificadorInvalido();

            var parms = new Dictionary<string, object> { { "ID", id } };

            var nfe = Db.Get<NotaFiscal>(_sqlObterPorId, SetarParmetros, parms);

            if (nfe == null) return null;

            return nfe;
        }

        public NotaFiscal ObterPorTransportadorID(long trasportadorID)
        {
            var parms = new Dictionary<string, object> { { "TransportadorID", trasportadorID } };

            var nfe = Db.Get<NotaFiscal>(_sqlObterPorTransportadorId, SetarParmetros, parms);

            if (nfe == null) return null;

            return nfe;
        }

        public List<NotaFiscal> ObterTodos()
        {
            return Db.GetAll(_sqlObterTodos, SetarParmetros);
        }

        private Dictionary<string, object> ObtemParametrosNotaFiscalEmitida(NotaFiscal notaFiscal)
        {
            var parms = new Dictionary<string, object>();
            parms.Add("Id", notaFiscal.ID);
            parms.Add("Chave", notaFiscal.Chave);
            parms.Add("NotaFiscalXML", NotaFiscalXmlRepository.SerializarParaString(notaFiscal));

            return parms;
        }
        private Dictionary<string, object> ObtemParametros(NotaFiscal notaFiscal)
        {
            var parms = new Dictionary<string, object>();
            parms.Add("Id", notaFiscal.ID);
            parms.Add("NaturezaOperacao", notaFiscal.NaturezaOperacao);
            parms.Add("TransportadorID", notaFiscal.Transportador.ID);
            parms.Add("ValorFrete", notaFiscal.ValorFrete);
            parms.Add("ValorTotalNota", notaFiscal.ValorTotalNota);
            parms.Add("Chave", notaFiscal.Chave);
            parms.Add("DataEmissao", notaFiscal.DataEmissao);
            parms.Add("DataEntrada", notaFiscal.DataEntrada);
            parms.Add("DestinatarioID", notaFiscal.Destinatario.ID);
            parms.Add("EmitenteID", notaFiscal.Emitente.ID);

            return parms;
        }

        private NotaFiscal SetarParmetros(IDataReader reader)
        {
            var notaFiscal = new NotaFiscal();

            notaFiscal.ID = Convert.ToInt32(reader["Id"]);
            notaFiscal.NaturezaOperacao = Convert.ToString(reader["NaturezaOperacao"]);
            notaFiscal.Transportador = new Transportador();
            notaFiscal.Transportador.ID = Convert.ToInt32(reader["TransportadorID"]);
            notaFiscal.Emitente = new Emitente();
            notaFiscal.Emitente.ID = Convert.ToInt32(reader["EmitenteID"]);
            notaFiscal.Destinatario = new Destinatario();
            notaFiscal.Destinatario.ID = Convert.ToInt32(reader["DestinatarioID"]);
            notaFiscal.ValorFrete = Convert.ToDouble(reader["ValorFrete"]);
            notaFiscal.ValorTotalNota = Convert.ToDouble(reader["ValorTotalNota"]);
            notaFiscal.Chave = Convert.ToString(reader["Chave"]);
            notaFiscal.DataEmissao = Convert.ToDateTime(reader["DataEmissao"]);
            notaFiscal.DataEntrada = Convert.ToDateTime(reader["DataEntrada"]);

            return notaFiscal;
        }
        private NotaFiscal SetarParmetrosNotaFiscalEmitida(IDataReader reader)
        {
            var notaFiscal = new NotaFiscal();

            notaFiscal = NotaFiscalXmlRepository.Deserializar(Convert.ToString(reader["NotaFiscalXML"]));

            return notaFiscal;
        }


        public NotaFiscal ObterPorChave(string chave)
        {
            var parms = new Dictionary<string, object> { { "Chave", chave } };

            var nota = Db.Get(_sqlObterPorChave, SetarParmetrosNotaFiscalEmitida, parms);

            if (nota == null)
                return null;

            return nota;
        }
    }
}

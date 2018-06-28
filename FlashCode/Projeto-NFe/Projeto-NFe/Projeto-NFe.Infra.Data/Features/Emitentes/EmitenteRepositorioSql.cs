using Projeto_NFe.Dominio.Excecoes;
using Projeto_NFe.Dominio.Features.Emitentes;
using Projeto_NFe.Dominio.Features.Enderecos;
using Projeto_NFe.Infra.Documentos.Features.Cnpjs;
using Projeto_NFe.Infra.SQL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto_NFe.Infra.Data.Features.Emitentes
{
    public class EmitenteRepositorioSql : IEmitenteRepositorio
    {
        #region Script's SQL
        private string _sqlInserir = @"INSERT INTO [dbo].[Emitente]
                                               ([NomeFantasia]
                                               ,[RazaoSocial]
                                               ,[CNPJ]
                                               ,[InscricaoEstadual]
                                               ,[InscricaoMunicipal]
                                               ,[EnderecoID])
                                         VALUES
                                               ({0}NomeFantasia
                                               ,{0}RazaoSocial
                                               ,{0}CNPJ
                                               ,{0}InscricaoEstadual
                                               ,{0}InscricaoMunicipal
                                               ,{0}EnderecoID)";

        private string _sqlDeletar = @"DELETE FROM [dbo].[Emitente] WHERE Id = {0}Id";

        private string _sqlAtualizar = @"UPDATE [dbo].[Emitente]
                                           SET [NomeFantasia] = {0}NomeFantasia
                                              ,[RazaoSocial] = {0}RazaoSocial
                                              ,[CNPJ] = {0}CNPJ
                                              ,[InscricaoEstadual] = {0}InscricaoEstadual
                                              ,[InscricaoMunicipal] = {0}InscricaoMunicipal
                                              ,[EnderecoID] = {0}EnderecoID
                                         WHERE Id = {0}Id";

        private string _sqlObterPorId = @"SELECT * FROM [dbo].[Emitente] WHERE Id = {0}Id";

        private string _sqlObterPorEnderecoId = @"SELECT * FROM [dbo].[Emitente] WHERE EnderecoID = {0}EnderecoID";

        private string _sqlObterTodos = @"SELECT * FROM [dbo].[Emitente]";
        #endregion

        public Emitente Atualizar(Emitente emitente)
        {
            if (emitente.ID == 0) throw new ExcecaoIdentificadorInvalido();

            emitente.Validar();

            Db.Update(_sqlAtualizar, ObtemParametros(emitente));

            return emitente;
        }

        public bool Deletar(long id)
        {
            if (id == 0) throw new ExcecaoIdentificadorInvalido();

            var parms = new Dictionary<string, object> { { "Id", id } };

            int linhasAfetadas = Db.Delete(_sqlDeletar, parms);

            if (linhasAfetadas < 1)
                return false;

            return true;
        }

        public Emitente Inserir(Emitente emitente)
        {
            emitente.Validar();

            emitente.ID = Db.Insert(_sqlInserir, ObtemParametros(emitente));

            return emitente;
        }

        public Emitente ObterPorEnderecoID(long id)
        {
            var parms = new Dictionary<string, object> { { "EnderecoID", id } };

            var emitente = Db.Get<Emitente>(_sqlObterPorEnderecoId, SetarParmetros, parms);

            if (emitente == null)
                return null;

            return emitente;
        }

        public Emitente ObterPorId(long id)
        {
            if (id == 0) throw new ExcecaoIdentificadorInvalido();

            var parms = new Dictionary<string, object> { { "Id", id } };

            return Db.Get<Emitente>(_sqlObterPorId, SetarParmetros, parms);
        }

        public List<Emitente> ObterTodos()
        {
            return Db.GetAll(_sqlObterTodos, SetarParmetros);
        }

        private Dictionary<string, object> ObtemParametros(Emitente emitente)
        {
            var parms = new Dictionary<string, object>();
            parms.Add("Id", emitente.ID);
            parms.Add("NomeFantasia", emitente.NomeFantasia);
            parms.Add("RazaoSocial", emitente.RazaoSocial);
            parms.Add("CNPJ", emitente.CNPJ.ToString());
            parms.Add("InscricaoEstadual", emitente.InscricaoEstadual);
            parms.Add("InscricaoMunicipal", emitente.InscricaoMunicipal);
            parms.Add("EnderecoID", emitente.Endereco.ID);
            return parms;
        }
        private Emitente SetarParmetros(IDataReader reader)
        {
            Emitente emitente = new Emitente();

            emitente.ID = Convert.ToInt32(reader["Id"]);
            emitente.NomeFantasia = Convert.ToString(reader["NomeFantasia"]);
            emitente.RazaoSocial = Convert.ToString(reader["RazaoSocial"]);
            emitente.CNPJ = new Cnpj();
            emitente.CNPJ.SetarNumeros(Convert.ToString(reader["CNPJ"]));
            emitente.InscricaoEstadual = Convert.ToString(reader["InscricaoEstadual"]);
            emitente.InscricaoMunicipal = Convert.ToString(reader["InscricaoMunicipal"]);
            emitente.Endereco = new Endereco();
            emitente.Endereco.ID = Convert.ToInt32(reader["EnderecoID"]);

            return emitente;
        }
    }
}

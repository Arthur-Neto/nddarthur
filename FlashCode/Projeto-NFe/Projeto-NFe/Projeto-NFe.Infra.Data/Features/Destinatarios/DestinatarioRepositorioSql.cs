using Projeto_NFe.Dominio.Base;
using Projeto_NFe.Dominio.Excecoes;
using Projeto_NFe.Dominio.Features.Destinatarios;
using Projeto_NFe.Dominio.Features.Enderecos;
using Projeto_NFe.Infra.Documentos.Features.Cnpjs;
using Projeto_NFe.Infra.Documentos.Features.Cpfs;
using Projeto_NFe.Infra.SQL;
using System;
using System.Collections.Generic;
using System.Data;

namespace Projeto_NFe.Infra.Data.Features.Destinatarios
{
    public class DestinatarioRepositorioSql : IDestinatarioRepositorio
    {
        #region Script's SQL
        private string _sqlInserir = @"INSERT INTO [dbo].[Destinatario]
                                                       ([Nome]
                                                       ,[RazaoSocial]
                                                       ,[CPF]
                                                       ,[CNPJ]
                                                       ,[EnderecoID])
                                                 VALUES
                                                       ({0}Nome
                                                       ,{0}RazaoSocial
                                                       ,{0}CPF
                                                       ,{0}CNPJ
                                                       ,{0}EnderecoID)";

        private string _sqlAtualizar = @"UPDATE [dbo].[Destinatario]
                                                   SET [Nome] = {0}Nome
                                                      ,[RazaoSocial] = {0}RazaoSocial
                                                      ,[CPF] = {0}CPF
                                                      ,[CNPJ] = {0}CNPJ
                                                      ,[EnderecoID] = {0}EnderecoID
                                                 WHERE Id = {0}Id";

        private string _sqlDeletar = @"DELETE FROM Destinatario WHERE Id={0}Id";

        private string _sqlObterPorId = @"SELECT * FROM Destinatario WHERE Id={0}Id";

        private string _sqlObterPorEnderecoId = @"SELECT * FROM Destinatario WHERE EnderecoID={0}EnderecoID";

        private string _sqlObterTodos = @"SELECT * FROM Destinatario";

        #endregion

        public Destinatario Atualizar(Destinatario destinatario)
        {
            destinatario.Validar();

            if (destinatario.ID == 0)
                throw new ExcecaoIdentificadorInvalido();

            Db.Update(_sqlAtualizar, ObtemParametros(destinatario));

            return destinatario;
        }

        public bool Deletar(long id)
        {
            if (id == 0)
                throw new ExcecaoIdentificadorInvalido();

            var parms = new Dictionary<string, object> { { "Id", id } };

            int linhasAfetadas = Db.Delete(_sqlDeletar, parms);

            if (linhasAfetadas < 1)
                return false;

            return true;
        }

        public Destinatario Inserir(Destinatario destinatario)
        {
            destinatario.Validar();

            destinatario.ID = Db.Insert(_sqlInserir, ObtemParametros(destinatario));
            return destinatario;
        }

        public Destinatario ObterPorEnderecoID(long id)
        {
            var parms = new Dictionary<string, object> { { "EnderecoID", id } };

            var destinatario = Db.Get<Destinatario>(_sqlObterPorEnderecoId, SetarParmetros, parms);

            if (destinatario == null)
                return null;

            return destinatario;
        }

        public Destinatario ObterPorId(long id)
        {
            if (id == 0)
                throw new ExcecaoIdentificadorInvalido();
            var parms = new Dictionary<string, object> { { "Id", id } };

            return Db.Get<Destinatario>(_sqlObterPorId, SetarParmetros, parms);
        }

        public List<Destinatario> ObterTodos()
        {
            return Db.GetAll(_sqlObterTodos, SetarParmetros);
        }

        private Dictionary<string, object> ObtemParametros(Destinatario destinatario)
        {
            var parms = new Dictionary<string, object>();

            parms.Add("ID", destinatario.ID);

            if (destinatario.Nome != null)
                parms.Add("Nome", destinatario.Nome);
            else parms.Add("Nome", DBNull.Value);

            if (destinatario.RazaoSocial != null)
                parms.Add("RazaoSocial", destinatario.RazaoSocial);
            else parms.Add("RazaoSocial", DBNull.Value);

            if (destinatario.Tipo == EPessoa.Juridica)
            {
                parms.Add("Cnpj", destinatario.Cnpj.ToString());
                parms.Add("Cpf", DBNull.Value);
            }
            else
            {
                parms.Add("Cpf", destinatario.Cpf.ToString());
                parms.Add("Cnpj", DBNull.Value);
            }

            parms.Add("EnderecoID", destinatario.Endereco.ID);

            return parms;
        }

        private Destinatario SetarParmetros(IDataReader reader)
        {
            var destinatario = new Destinatario();
            destinatario.ID = Convert.ToInt32(reader["Id"]);

            var nome = reader["Nome"];
            if (!nome.Equals(DBNull.Value))
                destinatario.Nome = Convert.ToString(nome);

            var cpf = reader["Cpf"];
            if (!cpf.Equals(DBNull.Value))
            {
                destinatario.Cpf = new Cpf();
                destinatario.Cpf.SetarNumeros(Convert.ToString(cpf));
                destinatario.Tipo = EPessoa.Juridica;
            }

            var razaoSocial = reader["RazaoSocial"];
            if (!razaoSocial.Equals(DBNull.Value))
                destinatario.RazaoSocial = Convert.ToString(razaoSocial);

            var cnpj = reader["Cnpj"];
            if (!cnpj.Equals(DBNull.Value))
            {
                destinatario.Cnpj = new Cnpj();
                destinatario.Cnpj.SetarNumeros(Convert.ToString(cnpj));
                destinatario.Tipo = EPessoa.Juridica;
            }

            destinatario.Endereco = new Endereco();
            destinatario.Endereco.ID = Convert.ToInt32(reader["EnderecoID"]);

            return destinatario;
        }
    }
}

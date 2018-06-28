using Projeto_NFe.Dominio.Excecoes;
using Projeto_NFe.Dominio.Features.Enderecos;
using Projeto_NFe.Dominio.Features.Transportadores;
using Projeto_NFe.Infra.Documentos.Features.Cnpjs;
using Projeto_NFe.Infra.Documentos.Features.Cpfs;
using Projeto_NFe.Infra.SQL;
using System;
using System.Collections.Generic;
using System.Data;

namespace Projeto_NFe.Infra.Data.Features.Transportadores
{
    public class TransportadorRepositorioSql : ITransportadorRepositorio
    {
        #region Script's SQL
        private string _sqlInserir = @"INSERT INTO [dbo].[Transportador]
                                                       ([Nome]
                                                       ,[RazaoSocial]
                                                       ,[CPF]
                                                       ,[CNPJ]
                                                       ,[EnderecoID]
                                                       ,[Responsabilidade_Frete])
                                                 VALUES
                                                       ({0}Nome
                                                       ,{0}RazaoSocial
                                                       ,{0}CPF
                                                       ,{0}CNPJ
                                                       ,{0}EnderecoID
                                                       ,{0}Responsabilidade_Frete)";

        private string _sqlAtualizar = @"UPDATE [dbo].[Transportador]
                                                   SET [Nome] = {0}Nome
                                                      ,[RazaoSocial] = {0}RazaoSocial
                                                      ,[CPF] = {0}CPF
                                                      ,[CNPJ] = {0}CNPJ
                                                      ,[EnderecoID] = {0}EnderecoID
                                                      ,[Responsabilidade_Frete] = {0}Responsabilidade_Frete
                                                 WHERE Id = {0}Id";

        private string _sqlDeletar = @"DELETE FROM Transportador WHERE Id={0}Id";

        private string _sqlObterPorId = @"SELECT * FROM Transportador WHERE Id={0}Id";

        private string _sqlObterPorEnderecoId = @"SELECT * FROM Transportador WHERE EnderecoID={0}EnderecoID";

        private string _sqlObterTodos = @"SELECT * FROM Transportador";

        #endregion

        public Transportador Atualizar(Transportador transportador)
        {
            transportador.Validar();

            if (transportador.ID == 0)
                throw new ExcecaoIdentificadorInvalido();

            Db.Update(_sqlAtualizar, ObtemParametros(transportador));

            return transportador;
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

        public Transportador Inserir(Transportador transportador)
        {
            transportador.Validar();

            transportador.ID = Db.Insert(_sqlInserir, ObtemParametros(transportador));
            return transportador;
        }

        public Transportador ObterPorEnderecoID(long id)
        {
            var parms = new Dictionary<string, object> { { "EnderecoID", id } };

            var transportador = Db.Get<Transportador>(_sqlObterPorEnderecoId, SetarParmetros, parms);

            if (transportador == null)
                return null;

            return transportador;
        }

        public Transportador ObterPorId(long id)
        {
            if (id == 0)
                throw new ExcecaoIdentificadorInvalido();
            var parms = new Dictionary<string, object> { { "Id", id } };

            return Db.Get<Transportador>(_sqlObterPorId, SetarParmetros, parms);
        }

        public List<Transportador> ObterTodos()
        {
            return Db.GetAll(_sqlObterTodos, SetarParmetros);
        }

        private Dictionary<string, object> ObtemParametros(Transportador transportador)
        {
            var parms = new Dictionary<string, object>();

            parms.Add("ID", transportador.ID);

            if (transportador.Nome != "")
            {
                parms.Add("Nome", transportador.Nome);
                parms.Add("RazaoSocial", DBNull.Value);
            }
            else
            {
                parms.Add("Nome", DBNull.Value);
                parms.Add("RazaoSocial", transportador.RazaoSocial);
            }


            if (transportador.Cnpj != null)
            {
                parms.Add("Cnpj", transportador.Cnpj.ToString());
                parms.Add("Cpf", DBNull.Value);
            }
            else
            {
                parms.Add("Cpf", transportador.Cpf.ToString());
                parms.Add("Cnpj", DBNull.Value);
            }

            parms.Add("EnderecoID", transportador.Endereco.ID);
            parms.Add("Responsabilidade_Frete", transportador.Responsabilidade_Frete);

            return parms;
        }

        private Transportador SetarParmetros(IDataReader reader)
        {
            var transportador = new Transportador();
            transportador.ID = Convert.ToInt32(reader["Id"]);

            var nome = reader["Nome"];
            if (!nome.Equals(DBNull.Value))
                transportador.Nome = Convert.ToString(nome);

            var cpf = reader["Cpf"];
            if (!cpf.Equals(DBNull.Value))
            {
                transportador.Cpf = new Cpf();
                transportador.Cpf.SetarNumeros(Convert.ToString(cpf));
            }

            var razaoSocial = reader["RazaoSocial"];
            if (!razaoSocial.Equals(DBNull.Value))
                transportador.RazaoSocial = Convert.ToString(razaoSocial);

            var cnpj = reader["Cnpj"];
            if (!cnpj.Equals(DBNull.Value))
            {
                transportador.Cnpj = new Cnpj();
                transportador.Cnpj.SetarNumeros(Convert.ToString(cnpj));
            }

            transportador.Endereco = new Endereco();
            transportador.Endereco.ID = Convert.ToInt32(reader["EnderecoID"]);
            transportador.Responsabilidade_Frete = Convert.ToBoolean(reader["Responsabilidade_Frete"]);

            return transportador;
        }
    }
}

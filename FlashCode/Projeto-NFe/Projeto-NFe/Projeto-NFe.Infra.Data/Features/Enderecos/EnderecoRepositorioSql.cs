using Projeto_NFe.Dominio.Excecoes;
using Projeto_NFe.Dominio.Features.Enderecos;
using Projeto_NFe.Infra.SQL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto_NFe.Infra.Data.Features.Enderecos
{
    public class EnderecoRepositorioSql : IEnderecoRepositorio
    {
        #region Script's SQL
        private string _sqlInserir = @"INSERT INTO [dbo].[Endereco]
                                                       ([Cep]
                                                       ,[Rua]
                                                       ,[Bairro]
                                                       ,[Cidade]
                                                       ,[UF]
                                                       ,[Pais]
                                                       ,[Numero])
                                                 VALUES
                                                       ({0}Cep
                                                       ,{0}Rua
                                                       ,{0}Bairro
                                                       ,{0}Cidade
                                                       ,{0}UF
                                                       ,{0}Pais
                                                       ,{0}Numero)";

        private string _sqlDeletar = @"DELETE FROM [dbo].[Endereco] WHERE Id = {0}Id";

        private string _sqlAtualizar = @"UPDATE [dbo].[Endereco]
                                               SET [Cep] = {0}Cep
                                                  ,[Rua] = {0}Rua
                                                  ,[Bairro] = {0}Bairro
                                                  ,[Cidade] = {0}Cidade
                                                  ,[UF] = {0}UF
                                                  ,[Pais] = {0}Pais
                                                  ,[Numero] = {0}Numero
                                             WHERE Id = {0}Id";

        private string _sqlObterPorId = @"SELECT * FROM [dbo].[Endereco] WHERE Id = {0}Id";

        private string _sqlObterTodos = @"SELECT * FROM [dbo].[Endereco]";
        
        #endregion

        public bool Deletar(long id)
        {
            if (id == 0) throw new ExcecaoIdentificadorInvalido();

            var parms = new Dictionary<string, object> { { "Id", id } };

            int linhasAfetadas = Db.Delete(_sqlDeletar, parms);

            if (linhasAfetadas < 1)
                return false;

            return true;
        }

        public List<Endereco> ObterTodos()
        {
            return Db.GetAll(_sqlObterTodos, SetarParmetros);
        }

        public Endereco ObterPorId(long id)
        {
            if (id == 0) throw new ExcecaoIdentificadorInvalido();

            var parms = new Dictionary<string, object> { { "Id", id } };

            return Db.Get<Endereco>(_sqlObterPorId, SetarParmetros, parms);
        }

        public Endereco Inserir(Endereco endereco)
        {
            endereco.Validar();

            endereco.ID = Db.Insert(_sqlInserir, ObtemParametros(endereco));

            return endereco;
        }

        public Endereco Atualizar(Endereco endereco)
        {
            if (endereco.ID == 0) throw new ExcecaoIdentificadorInvalido();

            endereco.Validar();

            Db.Update(_sqlAtualizar, ObtemParametros(endereco));

            return endereco;
        }

        private Dictionary<string, object> ObtemParametros(Endereco endereco)
        {
            var parms = new Dictionary<string, object>();
            parms.Add("ID", endereco.ID);
            parms.Add("Cep", endereco.Cep);
            parms.Add("Cidade", endereco.Cidade);
            parms.Add("Bairro", endereco.Bairro);
            parms.Add("Rua", endereco.Rua);
            parms.Add("UF", endereco.UF);
            parms.Add("Numero", endereco.Numero);
            parms.Add("Pais", endereco.Pais);
            return parms;
        }

        private Endereco SetarParmetros(IDataReader reader)
        {
            var endereco = new Endereco();

            endereco.ID = Convert.ToInt32(reader["Id"]);
            endereco.Numero = Convert.ToInt32(reader["Numero"]);
            endereco.Pais = Convert.ToString(reader["Pais"]);
            endereco.Rua = Convert.ToString(reader["Rua"]);
            endereco.UF = Convert.ToString(reader["UF"]);
            endereco.Bairro = Convert.ToString(reader["Bairro"]);
            endereco.Cidade = Convert.ToString(reader["Cidade"]);
            endereco.Cep = Convert.ToString(reader["Cep"]);

            return endereco;
        }
    }
}

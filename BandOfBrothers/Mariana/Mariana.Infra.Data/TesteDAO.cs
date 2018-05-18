using Mariana.Dominio;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mariana.Infra.Data
{
    public class TesteDAO
    {
        #region queries 
        private const string sqlInsertTeste = @"INSERT INTO TBTeste (IdDisciplina, IdSerie, IdMateria, Nome, NumeroQuestoes, DataTesteGerado, CaminhoDestino) VALUES (@IdDisciplina, @IdSerie, @IdMateria, @Nome, @NumeroQuestoes, @DataTesteGerado, @CaminhoDestino);";

        private const string sqlInsertQuestoesTeste = @"INSERT INTO TBQuestaoTeste (IdTeste, IdQuestao) VALUES (@IdTeste, @IdQuestao);";

        private const string sqlGetAllTestes = @"SELECT t.Id,
                                                    t.IdDisciplina, 
                                                    t.IdSerie,
                                                    t.IdMateria,
                                                    t.DataTesteGerado,
                                                    t.NumeroQuestoes,
                                                    t.CaminhoDestino,
                                                    t.Nome,
                                                    m.Nome AS NomeMateria,
                                                    d.Nome AS NomeDisciplina,
                                                    s.Numero
                                                    FROM TBTeste AS t
                                                    INNER JOIN TBMateria as m
                                                    ON m.Id = t.IdMateria
                                                    INNER JOIN TBDisciplina AS d 
                                                    ON d.Id = m.IdDisciplina
                                                    INNER JOIN TBSerie AS s
                                                    ON s.Id = m.IdSerie";

        private const string sqlGetAllQuestoesPorTesteId = @"SELECT t.Id,
                                                            qt.IdQuestao,
                                                            q.Enunciado,
                                                            q.Bimestre
                                                            FROM TBTeste AS t
                                                            INNER JOIN TBQuestaoTeste AS qt 
                                                            ON qt.IdTeste = t.Id
                                                            INNER JOIN TBQuestao AS q 
                                                            ON q.Id = qt.IdQuestao
                                                            WHERE t.Id = @Id";

        private const string sqlGetTesteById = @"SELECT 
                                                    t.Id,
                                                    t.IdDisciplina, 
                                                    t.IdSerie,
                                                    t.IdMateria
                                                    t.DaTaTesteGerado,
                                                    t.Nome,
                                                    t.NumeroQuestoes,
                                                    t.CaminhoDestino,
                                                    m.Nome AS NomeMateria,
                                                    d.Nome AS NomeDisciplina,
                                                    s.Numero
                                                    FROM TBTeste AS t
                                                    INNER JOIN TBMateria as m
                                                    ON m.Id = t.IdMateria
                                                    INNER JOIN TBDisciplina AS d 
                                                    ON d.Id = m.IdDisciplina
                                                    INNER JOIN TBSerie AS s
                                                    ON s.Id = m.IdSerie
                                                    WHERE t.Id = @Id";

        private const string sqlGetTesteByName = @"SELECT Id, Nome FROM TBTeste WHERE Nome = @Nome AND Id <> @Id";

        private const string sqlGetLastOne = @"SELECT top(1) Id FROM TBTeste ORDER BY Id DESC";

        private const string sqlUpdateTeste = @"UPDATE TBTeste 
                                                SET Nome = @Nome, 
                                                IdDisciplina = @IdDisciplina, 
                                                IdSerie = @IdSerie, 
                                                IdMateria = @IdMateria, 
                                                NumeroQuestoes = @NumeroQuestoes, 
                                                CaminhoDestino = @CaminhoDestino 
                                                WHERE Id = @Id";

        private const string sqlDeleteTeste = @"DELETE FROM TBTeste WHERE Id = @Id";

        private const string sqlDeleteTesteQuestoes = @"DELETE FROM TBQuestaoTeste WHERE IdTeste = @Id";

        #endregion queries

        public TesteDAO()
        {
        }

        public Teste Adicionar(Teste Teste)
        {
            DB.Add(sqlInsertTeste, GetParam(Teste));

            int id = ObterUltimoId();

            Teste.Id = id;

            return Teste;
        }

        public int ObterUltimoId()
        {
            int id = 0;
            IList<Teste> testes = DB.GetAll(sqlGetLastOne, ConverterId);

            foreach (var item in testes)
            {
                id = item.Id;
            }

            return id;
        }

        private static Teste ConverterId(IDataReader _reader)
        {
            Teste teste = new Teste();

            teste.Id = Convert.ToInt32(_reader["Id"]);

            return teste;
        }

        public void AdicionarQuestoes(Questao questao, Teste teste)
        {
            DB.Add(sqlInsertQuestoesTeste, GetParamQuestaoTeste(questao, teste));
        }

        public Teste Atualizar(Teste Teste)
        {
            DB.Update(sqlUpdateTeste, GetParam(Teste));

            return Teste;
        }

        public int Excluir(int TesteId)
        {
            var dic = new Dictionary<string, object>();
            dic.Add("Id", TesteId);

            DB.Delete(sqlDeleteTeste, dic);

            return TesteId;
        }

        public int ExcluirQuestoes(int TesteId)
        {
            var dic = new Dictionary<string, object>();
            dic.Add("Id", TesteId);

            DB.Delete(sqlDeleteTesteQuestoes, dic);

            return TesteId;
        }

        public bool Existe(Teste Teste)
        {
            Teste TestePega = DB.GetByName(sqlGetTesteByName, ConverterGetByName, GetParam(Teste));
            if (TestePega == null)
                return false;
            else
                return true;
        }

        public IList<Teste> ObterTodosItens()
        {
            return DB.GetAll(sqlGetAllTestes, Converter);
        }
        public IList<Questao> ObterQuestoes(Teste Teste)
        {
            return DB.GetAll(sqlGetAllQuestoesPorTesteId, ConverteQuestao, GetParam(Teste));
        }

        private static Teste Converter(IDataReader _reader)
        {
            Teste teste = new Teste();

            teste.Id = Convert.ToInt32(_reader["Id"]);
            teste.Nome = Convert.ToString(_reader["Nome"]);
            teste.DataTesteGerado = Convert.ToDateTime(_reader["DataTesteGerado"]);
            teste.NumeroQuestoes = Convert.ToInt32(_reader["NumeroQuestoes"]);
            teste.CaminhoDestino = Convert.ToString(_reader["CaminhoDestino"]);

            teste.Disciplina.Id = Convert.ToInt32(_reader["IdDisciplina"]);
            teste.Disciplina.Nome = Convert.ToString(_reader["NomeDisciplina"]);

            teste.Serie.Id = Convert.ToInt32(_reader["IdSerie"]);
            teste.Serie.NumeroSerie = Convert.ToInt32(_reader["Numero"]);

            teste.Materia.Id = Convert.ToInt32(_reader["IdMateria"]);
            teste.Materia.Nome = Convert.ToString(_reader["NomeMateria"]);

            return teste;
        }

        private static Teste ConverteTeste(IDataReader _reader)
        {
            Teste teste = new Teste();

            teste.Id = Convert.ToInt32(_reader["Id"]);
            teste.Nome = Convert.ToString(_reader["Nome"]);
            teste.DataTesteGerado = Convert.ToDateTime(_reader["DataTesteGerado"]);
            teste.NumeroQuestoes = Convert.ToInt32(_reader["NumeroQuestoes"]);
            teste.CaminhoDestino = Convert.ToString(_reader["CaminhoDestino"]);

            teste.Disciplina.Id = Convert.ToInt32(_reader["IdDisciplina"]);
            teste.Disciplina.Nome = Convert.ToString(_reader["NomeDisciplina"]);

            teste.Serie.Id = Convert.ToInt32(_reader["IdSerie"]);
            teste.Serie.NumeroSerie = Convert.ToInt32(_reader["Numero"]);

            teste.Materia.Id = Convert.ToInt32(_reader["IdMateria"]);
            teste.Materia.Nome = Convert.ToString(_reader["NomeMateria"]);

            return teste;
        }

        private static Questao ConverteQuestao(IDataReader _reader)
        {
            Questao questao = new Questao();

            questao.Id = Convert.ToInt32(_reader["IdQuestao"]);
            questao.Enunciado = Convert.ToString(_reader["Enunciado"]);
            questao.Bimestre = (Bimestre)Enum.Parse(typeof(Bimestre), _reader["Bimestre"].ToString());

            return questao;
        }

        private static Teste ConverterGetByName(IDataReader _reader)
        {
            Teste Teste = new Teste();

            Teste.Id = Convert.ToInt32(_reader["Id"]);
            Teste.Nome = Convert.ToString(_reader["Nome"]);

            return Teste;
        }

        public Dictionary<string, object> GetParam(Teste Teste)
        {
            var dic = new Dictionary<string, object>();
            dic.Add("Id", Teste.Id);
            dic.Add("IdDisciplina", Teste.Disciplina.Id);
            dic.Add("IdSerie", Teste.Serie.Id);
            dic.Add("Nome", Teste.Nome);
            dic.Add("NumeroQuestoes", Teste.NumeroQuestoes);
            dic.Add("CaminhoDestino", Teste.CaminhoDestino);
            dic.Add("IdMateria", Teste.Materia.Id);
            dic.Add("DataTesteGerado", Teste.DataTesteGerado);

            return dic;
        }

        public Dictionary<string, object> GetParamQuestaoTeste(Questao questao, Teste Teste)
        {
            var dic = new Dictionary<string, object>();

            dic.Add("IdQuestao", questao.Id);
            dic.Add("IdTeste", Teste.Id);

            return dic;
        }
    }
}

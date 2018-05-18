using Mariana.Dominio;
using System;
using System.Collections.Generic;
using System.Data;

namespace Mariana.Infra.Data
{
    public class QuestaoDAO
    {
        #region queries 
        private const string sqlInsertQuestao = @"INSERT INTO TBQuestao (IdMateria, Enunciado, Bimestre, IdDisciplina) VALUES (@IdMateria, @Enunciado, @Bimestre, @IdDisciplina)";

        private const string sqlGetAllQuestaos = @"SELECT 
                                                    q.Id, 
                                                    q.IdMateria, 
                                                    q.IdDisciplina, 
                                                    q.Enunciado, 
                                                    q.Bimestre,
                                                    m.Nome AS NomeMateria,
                                                    m.IdSerie,
                                                    d.Nome AS NomeDisciplina,
                                                    s.Numero
                                                    FROM TBQuestao AS q
                                                    INNER JOIN TBDisciplina AS d
                                                    ON d.Id = q.IdDisciplina
                                                    INNER JOIN TBMateria AS m
                                                    ON m.Id = q.IdMateria
                                                    INNER JOIN TBSerie AS s
                                                    ON m.IdSerie = s.Id";

        private const string sqlGetQuestaoById = @"SELECT 
                                                    q.Id, 
                                                    q.IdMateria, 
                                                    q.IdDisciplina, 
                                                    q.Enunciado, 
                                                    q.Bimestre,
                                                    m.Nome AS NomeMateria,
                                                    m.IdSerie,
                                                    d.Nome AS NomeDisciplina,
                                                    s.Numero
                                                    FROM TBQuestao AS q
                                                    INNER JOIN TBDisciplina AS d
                                                    ON d.Id = q.IdDisciplina
                                                    INNER JOIN TBMateria AS m
                                                    ON m.Id = q.IdMateria
                                                    INNER JOIN TBSerie AS s
                                                    ON m.IdSerie = s.Id
                                                    WHERE Id = @Id";

        private const string sqlGetLastOne = @"SELECT top(1) Id FROM TBQuestao ORDER BY Id DESC";

        private const string sqlUpdateQuestao = @"UPDATE TBQuestao SET IdMateria = @IdMateria, Enunciado = @Enunciado, IdDisciplina = @IdDisciplina, Bimestre = @Bimestre WHERE Id = @Id";

        private const string sqlDeleteQuestao = @"DELETE FROM TBQuestao WHERE Id = @Id";

        private const string sqlInsertResposta = @"INSERT INTO TBResposta (IdQuestao, CorpoResposta, Correta) VALUES (@IdQuestao, @CorpoResposta, @Correta)";

        private const string sqlDeletarRespostasAssociadas = @"DELETE FROM TBResposta WHERE IdQuestao = @Id";

        private const string sqlGetQuestaoByName = @"SELECT * FROM TBQuestao WHERE Enunciado = @Enunciado AND Id <> @Id";

        #endregion queries

        public QuestaoDAO()
        {
        }

        public Questao Adicionar(Questao questao, IList<Resposta> respostas)
        {
            DB.Add(sqlInsertQuestao, GetParam(questao));
            int id = ObterUltimoId();


            foreach (var item in respostas)
            {
                DB.Add(sqlInsertResposta, GetParamResposta(item, id));
            }

            questao.Id = id;

            return questao;
        }

        public Questao Atualizar(Questao questao)
        {
            DB.Update(sqlUpdateQuestao, GetParam(questao));

            return questao;
        }

        public int Excluir(int questaoId)
        {
            var dic = new Dictionary<string, object>();
            dic.Add("Id", questaoId);

            DB.Delete(sqlDeletarRespostasAssociadas, dic);
            DB.Delete(sqlDeleteQuestao, dic);

            return questaoId;
        }

        public bool Existe(Questao questao)
        {
            Questao questaoPega = DB.GetByName(sqlGetQuestaoByName, ConverterGetByName, GetParam(questao));
            if (questaoPega == null)
                return false;
            else
                return true;
        }

        public IList<Questao> ObterTodosItens()
        {
            return DB.GetAll(sqlGetAllQuestaos, Converter);
        }

        public int ObterUltimoId()
        {
            int id = 0;
            IList<Questao> questoes = DB.GetAll(sqlGetLastOne, ConverterId);

            foreach (var item in questoes)
            {
                id = item.Id;
            }

            return id;
        }

        private static Questao Converter(IDataReader _reader)
        {
            Questao questao = new Questao();

            questao.Id = Convert.ToInt32(_reader["Id"]);
            questao.Enunciado = Convert.ToString(_reader["Enunciado"]);
            questao.Bimestre = (Bimestre)Enum.Parse(typeof(Bimestre), _reader["Bimestre"].ToString());

            questao.Disciplina.Id = Convert.ToInt32(_reader["IdDisciplina"]);
            questao.Disciplina.Nome = Convert.ToString(_reader["NomeDisciplina"]);

            questao.Materia.Id = Convert.ToInt32(_reader["IdMateria"]);
            questao.Materia.Nome = Convert.ToString(_reader["NomeMateria"]);

            questao.Materia.Serie.Id = Convert.ToInt32(_reader["IdSerie"]);
            questao.Materia.Serie.NumeroSerie = Convert.ToInt32(_reader["Numero"]);

            return questao;
        }

        private static Questao ConverterGetByName(IDataReader _reader)
        {
            Questao questao = new Questao();

            questao.Id = Convert.ToInt32(_reader["Id"]);
            questao.Enunciado = Convert.ToString(_reader["Enunciado"]);

            return questao;
        }

        private static Questao ConverterId(IDataReader _reader)
        {
            Questao questao = new Questao();

            questao.Id = Convert.ToInt32(_reader["Id"]);

            return questao;
        }

        public Dictionary<string, object> GetParam(Questao questao)
        {
            var dic = new Dictionary<string, object>();

            dic.Add("Id", questao.Id);
            dic.Add("Enunciado", questao.Enunciado);
            dic.Add("Bimestre", questao.Bimestre);

            dic.Add("IdDisciplina", questao.Disciplina.Id);
            dic.Add("NomeDisciplina", questao.Disciplina.Nome);

            dic.Add("IdMateria", questao.Materia.Id);
            dic.Add("NomeMateria", questao.Materia.Nome);

            dic.Add("IdSerie", questao.Materia.Serie.Id);
            dic.Add("Numero", questao.Materia.Serie.NumeroSerie);

            return dic;
        }

        public Dictionary<string, object> GetParamResposta(Resposta resposta, int idQuestao)
        {
            var dic = new Dictionary<string, object>();

            dic.Add("Id", resposta.Id);
            dic.Add("IdQuestao", idQuestao);
            dic.Add("CorpoResposta", resposta.CorpoResposta);
            dic.Add("Correta", resposta.Correta);

            return dic;
        }

        public int GetIdQuestao(Dictionary<string, object> parms)
        {
            int id = 0;
            foreach (var item in parms)
            {
                id = (int)item.Value;
            }
            return id;
        }
    }
}

using Mariana.Dominio;
using Mariana.Dominio.Interfaces;
using Mariana.Infra.Data.Nucleo;
using System;
using System.Collections.Generic;
using System.Data;

namespace Mariana.Infra.Data.SQL
{
    public class QuestaoSQLRepositorio : Db<Questao>, IQuestaoRepositorio
    {
        #region Querys 
        private const string _inserir = @"INSERT INTO TBQuestao (IdMateria, Enunciado, Bimestre, IdDisciplina) VALUES (@IdMateria, @Enunciado, @Bimestre, @IdDisciplina)";

        private const string _carregarTodos = @"SELECT questao.Id,
                                                        questao.Enunciado,
                                                        questao.Bimestre,
                                                        disciplina.Id AS IdDisciplina,
                                                        disciplina.Nome AS NomeDisciplina,
                                                        materia.Id AS IdMateria,
                                                        materia.Nome AS NomeMateria,
                                                        serie.Id AS IdSerie,
                                                        serie.Numero
                                                        FROM TBQuestao AS questao
                                                        INNER JOIN TBDisciplina AS disciplina
                                                        ON questao.IdDisciplina = disciplina.Id
                                                        INNER JOIN TBMateria AS materia
                                                        ON questao.IdMateria = materia.Id
                                                        INNER JOIN TBSerie AS serie
                                                        ON materia.IdSerie = serie.Id";

        private const string _pesquisar = @"SELECT questao.Id,
                                                        questao.Enunciado,
                                                        questao.Bimestre,
                                                        disciplina.Id AS IdDisciplina,
                                                        disciplina.Nome AS NomeDisciplina,
                                                        materia.Id AS IdMateria,
                                                        materia.Nome AS NomeMateria,
                                                        serie.Id AS IdSerie,
                                                        serie.Numero
                                                        FROM TBQuestao AS questao
                                                        INNER JOIN TBDisciplina AS disciplina
                                                        ON questao.IdDisciplina = disciplina.Id
                                                        INNER JOIN TBMateria AS materia
                                                        ON questao.IdMateria = materia.Id
                                                        INNER JOIN TBSerie AS serie
                                                        ON materia.IdSerie = serie.Id
                                                        WHERE questao.Enunciado like '%'+@Pesquisa+'%' OR 
                                                        disciplina.Nome like '%'+@Pesquisa+'%'";

        private const string _carregarPorId = @"SELECT 
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

        private const string _atualizar = @"UPDATE TBQuestao SET IdMateria = @IdMateria, Enunciado = @Enunciado, IdDisciplina = @IdDisciplina, Bimestre = @Bimestre WHERE Id = @Id";

        private const string _excluir = @"DELETE FROM TBQuestao WHERE Id = @Id";

        private const string sqlInsertResposta = @"INSERT INTO TBResposta (IdQuestao, CorpoResposta, Correta) VALUES (@IdQuestao, @CorpoResposta, @Correta)";

        private const string _deletarRespostasAssociadas = @"DELETE FROM TBResposta WHERE IdQuestao = @Id";

        private const string _carregarPorNome = @"SELECT * FROM TBQuestao WHERE Enunciado = @Enunciado AND Id <> @Id";

        private const string _carregarPorNomeEId = @"SELECT * FROM TBQuestao WHERE Enunciado = @Enunciado AND Id <> @Id";

        #endregion queries

        #region Queries Tabela Intermediaria

        private const string sqlGetAllQuestoesPorTesteId = @"SELECT t.Id As IdTeste,
                                                            q.Id AS Id,
                                                            q.Enunciado,
                                                            q.Bimestre,
                                                            q.IdDisciplina,
                                                            q.IdMateria,
                                                            s.Numero,
                                                            d.Nome AS NomeDisciplina,
                                                            m.Nome AS NomeMateria,
                                                            m.IdSerie
                                                            FROM TBTeste AS t
                                                            INNER JOIN TBQuestaoTeste AS qt 
                                                            ON qt.IdTeste = t.Id
															INNER JOIN TBQuestao AS q 
                                                            ON q.Id = qt.IdQuestao
                                                            INNER JOIN TBDisciplina AS d
                                                            ON d.Id = q.IdDisciplina
                                                            INNER JOIN TBMateria AS m
                                                            ON m.Id = q.IdMateria
                                                            INNER JOIN TBSerie AS s
                                                            ON m.IdSerie = s.Id
                                                            WHERE t.Id = @Id";
        #endregion

        public QuestaoSQLRepositorio(TipoRepositorio tipo) : base(tipo)
        {
        }

        public override Questao Adicionar(Questao entidade)
        {
            entidade.Id = base.ExecutarAtualizacao(_inserir, EntidadeParaTupla(entidade, false));
            return entidade;
        }

        public override Questao Atualizar(Questao entidade)
        {
            base.ExecutarAtualizacao(_atualizar, EntidadeParaTupla(entidade, true), false);
            return entidade;
        }

        public override IList<Questao> BuscarTodos()
        {
            return base.ConsultarLista(_carregarTodos, TuplaParaEntidade);
        }

        public IList<Questao> ObterQuestoesTeste(Teste teste)
        {
            return base.ConsultarLista(sqlGetAllQuestoesPorTesteId, TuplaParaEntidade, new Dictionary<String, Object>() { { "Id", teste.Id } });
        }

        public override Questao ConsultarPorId(int Id)
        {
            return base.ConsultarEntidade(_carregarPorId, TuplaParaEntidade, new Dictionary<String, Object>() { { "Id", Id } });
        }

        public override int Excluir(int Id)
        {
            base.Excluir(_deletarRespostasAssociadas, Id);
            return base.Excluir(_excluir, Id);
        }

        public IList<Questao> PesquisarQuestao(string NomePesquisa)
        {
            return base.ConsultarLista(_pesquisar, TuplaParaEntidade, new Dictionary<String, Object>() { { "Pesquisa", '%' + NomePesquisa + '%' } });
        }

        public IList<Questao> ConsultarPorNome(String Enunciado)
        {
            return base.ConsultarLista(_carregarPorNome, TuplaParaEntidade, new Dictionary<String, Object>() { { "Enunciado", Enunciado } });
        }

        public IList<Questao> ConsultarPorNomeEId(String Enunciado, int Id)
        {
            return base.ConsultarLista(_carregarPorNomeEId, TuplaParaEntidade_, new Dictionary<String, Object>() { { "Enunciado", Enunciado }, { "Id", Id } });

        }

        public Dictionary<String, Object> EntidadeParaTupla(Questao questao, bool temId)
        {
            Dictionary<String, Object> parametros = new Dictionary<string, object>();
            parametros.Add("Enunciado", questao.Enunciado);
            parametros.Add("IdMateria", questao.Materia.Id);
            parametros.Add("IdDisciplina", questao.Disciplina.Id);
            parametros.Add("Bimestre", questao.Bimestre);

            if (temId)
            {
                parametros.Add("Id", questao.Id);
            }

            return parametros;
        }

        public IList<Questao> Pesquisar(string pesquisar)
        {
            throw new NotImplementedException();
        }

        private static Func<IDataReader, Questao> TuplaParaEntidade = reader =>
          new Questao()
          {
              Id = Convert.ToInt32(reader["Id"]),
              Enunciado = Convert.ToString(reader["Enunciado"]),
              Bimestre = (Bimestre)(reader["Bimestre"]),
              Disciplina = new Disciplina()
              {
                  Id = Convert.ToInt32(reader["IdDisciplina"]),
                  Nome = Convert.ToString(reader["NomeDisciplina"])
              },
              Materia = new Materia()
              {
                  Id = Convert.ToInt32(reader["IdMateria"]),
                  Nome = Convert.ToString(reader["NomeMateria"]),
                  Serie = new Serie()
                  {
                      Id = Convert.ToInt32(reader["IdSerie"]),
                      NumeroSerie = Convert.ToInt32(reader["Numero"]),
                  }

              }
          };

        private static Func<IDataReader, Questao> TuplaParaEntidade_ = reader =>
         new Questao()
         {
             Id = Convert.ToInt32(reader["Id"]),
             Enunciado = Convert.ToString(reader["Enunciado"]),
             Bimestre = (Bimestre)(reader["Bimestre"]),
             Disciplina = new Disciplina()
             {
                 Id = Convert.ToInt32(reader["IdDisciplina"])
                
             },
             Materia = new Materia()
             {
                 Id = Convert.ToInt32(reader["IdMateria"]),

             }
         };

    }
}

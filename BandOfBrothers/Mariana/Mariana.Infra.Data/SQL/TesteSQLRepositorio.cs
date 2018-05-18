using Mariana.Dominio;
using Mariana.Dominio.Interfaces;
using System;
using System.Collections.Generic;
using System.Data;

namespace Mariana.Infra.Data.SQL
{
    public class TesteSQLRepositorio : Db<Teste>, ITesteRepositorio
    {
        #region Queries 
        private const string _inserir = @"INSERT INTO TBTeste (IdDisciplina, IdSerie, IdMateria, Nome, NumeroQuestoes, DataTesteGerado, CaminhoDestino) VALUES (@IdDisciplina, @IdSerie, @IdMateria, @Nome, @NumeroQuestoes, @DataTesteGerado, @CaminhoDestino);";

        private const string sqlInsertQuestoesTeste = @"INSERT INTO TBQuestaoTeste (IdTeste, IdQuestao) VALUES (@IdTeste, @IdQuestao);";

        private const string _carregarTodos = @"SELECT t.Id,
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

        private const string _pesquisar = @"SELECT t.Id,
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
                                                    ON s.Id = m.IdSerie
                                                    WHERE t.Nome like '%'+@Nome+'%' OR 
                                                    m.Nome like '%'+@Nome+'%'        OR 
                                                    d.nome like '%'+@Nome+'%'";


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

        private const string _carregarPorId = @"SELECT 
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

        private const string _carregarPorNome = @"SELECT Id, Nome FROM TBTeste WHERE Nome = @Nome AND Id <> @Id";

        private const string _carregarPorNomeEId = @"SELECT Id, Nome FROM TBTeste WHERE Nome = @Nome AND Id = @Id";

        private const string sqlGetLastOne = @"SELECT top(1) Id FROM TBTeste ORDER BY Id DESC";

        private const string _atualizar = @"UPDATE TBTeste 
                                                SET Nome = @Nome, 
                                                IdDisciplina = @IdDisciplina, 
                                                IdSerie = @IdSerie, 
                                                IdMateria = @IdMateria, 
                                                NumeroQuestoes = @NumeroQuestoes, 
                                                CaminhoDestino = @CaminhoDestino 
                                                WHERE Id = @Id";

        private const string _excluir = @"DELETE FROM TBTeste WHERE Id = @Id";

        private const string _sqlDeleteTesteQuestoes = @"DELETE FROM TBQuestaoTeste WHERE IdTeste = @Id";

        #endregion queries

        public TesteSQLRepositorio(TipoRepositorio tipo) : base(tipo)
        {
        }

        public override Teste Adicionar(Teste entidade)
        {
            entidade.Id = base.ExecutarAtualizacao(_inserir, EntidadeParaTupla(entidade, false));
            return entidade;
        }

        public override Teste Atualizar(Teste entidade)
        {
            base.ExecutarAtualizacao(_atualizar, EntidadeParaTupla(entidade, true), false);
            return entidade;
        }

        public override IList<Teste> BuscarTodos()
        {
            return base.ConsultarLista(_carregarTodos, TuplaParaEntidade);
        }

        public override Teste ConsultarPorId(int Id)
        {
            return base.ConsultarEntidade(_carregarPorId, TuplaParaEntidade, new Dictionary<String, Object>() { { "Id", Id } });
        }

        public override int Excluir(int Id)
        {
            return base.Excluir(_excluir, Id);
        }

        public IList<Teste> ConsultarPorNome(String Nome)
        {
            return base.ConsultarLista(_carregarPorNome, TuplaParaEntidade, new Dictionary<String, Object>() { { "Nome", Nome } });
        }

        public IList<Teste> ConsultarPorNomeEId(String Nome, int Id)
        {
            return base.ConsultarLista(_carregarPorNomeEId, TuplaParaEntidade, new Dictionary<String, Object>() { { "Nome", Nome }, { "Id", Id } });

        }

        public void AdicionarQuestoes(Questao questao, Teste teste)
        {
            base.ExecutarAtualizacao(sqlInsertQuestoesTeste, GetParamQuestaoTeste(questao, teste));
        }

        public int ExcluirQuestoes(int TesteId)
        {
           base.Excluir(_sqlDeleteTesteQuestoes, TesteId);

            return TesteId;
        }

        public IList<Teste> PesquisarTeste(string NomePesquisa)
        {
            return base.ConsultarLista(_pesquisar, TuplaParaEntidade , new Dictionary<String, Object>() { { "Nome", '%' + NomePesquisa + '%'} });
        }

        public Dictionary<String, Object> EntidadeParaTupla(Teste teste, bool temId)
        {
            Dictionary<String, Object> parametros = new Dictionary<string, object>();
            parametros.Add("DataTesteGerado", teste.DataTesteGerado);
            parametros.Add("Nome", teste.Nome);
            parametros.Add("IdDisciplina", teste.Disciplina.Id);
            parametros.Add("IdSerie", teste.Serie.Id);
            parametros.Add("IdMateria", teste.Materia.Id);
            parametros.Add("NumeroQuestoes", teste.NumeroQuestoes);
            parametros.Add("CaminhoDestino", teste.CaminhoDestino);

            if (temId)
            {
                parametros.Add("Id", teste.Id);
            }

            return parametros;
        }

        public Dictionary<string, object> GetParamQuestaoTeste(Questao questao, Teste Teste)
        {
            var dic = new Dictionary<string, object>();

            dic.Add("IdQuestao", questao.Id);
            dic.Add("IdTeste", Teste.Id);

            return dic;
        }

        public IList<Teste> Pesquisar(string pesquisar)
        {
            throw new NotImplementedException();
        }

        private static Func<IDataReader, Teste> TuplaParaEntidade = reader =>
          new Teste()
          {
              Id = Convert.ToInt32(reader["Id"]),
              DataTesteGerado = Convert.ToDateTime(reader["DataTesteGerado"]),
              Nome = Convert.ToString(reader["Nome"]),
              Disciplina = new Disciplina()
              {
                  Id = Convert.ToInt32(reader["IdDisciplina"]),
                  Nome = Convert.ToString(reader["NomeDisciplina"])
              },
              Serie = new Serie()
              {
                  Id = Convert.ToInt32(reader["IdSerie"]),
                  NumeroSerie = Convert.ToInt32(reader["Numero"])
              },
              Materia = new Materia()
              {
                  Id = Convert.ToInt32(reader["IdMateria"]),
                  Nome = Convert.ToString(reader["NomeMateria"])
              },
              NumeroQuestoes = Convert.ToInt32(reader["NumeroQuestoes"]),
              CaminhoDestino = Convert.ToString(reader["CaminhoDestino"])

          };
    }
}

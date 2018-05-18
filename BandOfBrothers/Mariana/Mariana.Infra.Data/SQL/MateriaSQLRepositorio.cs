using Mariana.Dominio;
using Mariana.Dominio.Interfaces;
using System;
using System.Collections.Generic;
using System.Data;

namespace Mariana.Infra.Data.SQL
{
    public class MateriaSQLRepositorio : Db<Materia>, IMateriaRepositorio
    {
        #region Querys 
        private const string _inserir = @"INSERT INTO TBMateria (IdDisciplina, IdSerie, Nome) VALUES (@IdDisciplina, @IdSerie, @Nome);";

        private const string _carregarTodos = @"SELECT m.Id,
                                                    m.IdDisciplina, 
                                                    m.IdSerie,
                                                    m.Nome,
                                                    d.Nome AS NomeDisciplina,
                                                    s.Numero
                                                    FROM TBMateria AS m 
                                                    INNER JOIN TBDisciplina AS d 
                                                    ON d.Id = m.IdDisciplina
                                                    INNER JOIN TBSerie AS s
                                                    ON s.Id = m.IdSerie";

        private const string _carregarPorId = @"SELECT 
                                                    m.Id,
                                                    m.IdDisciplina, 
                                                    m.IdSerie,
                                                    m.Nome,
                                                    d.Nome AS NomeDisciplina,
                                                    s.Numero
                                                    FROM TBMateria AS m 
                                                    INNER JOIN TBDisciplina AS d 
                                                    ON d.Id = m.IdDisciplina
                                                    INNER JOIN TBSerie AS s
                                                    ON s.Id = m.IdSerie
                                                    WHERE m.Id = @Id";
        
        private const string _pesquisar = @"SELECT m.Id,
                                                    m.IdDisciplina, 
                                                    m.IdSerie,
                                                    m.Nome,
                                                    d.Nome AS NomeDisciplina,
                                                    s.Numero
                                                    FROM TBMateria AS m 
                                                    INNER JOIN TBDisciplina AS d 
                                                    ON d.Id = m.IdDisciplina
                                                    INNER JOIN TBSerie AS s
                                                    ON s.Id = m.IdSerie
                                                    WHERE m.Nome like '%'+@Pesquisa+'%' OR
                                                    d.Nome like '%'+@Pesquisa+'%'";

        private const string _carregarPorNome = @"SELECT Id, IdDisciplina, IdSerie, Nome FROM TBMateria WHERE Nome = @Nome AND IdSerie = @IdSerie";

        private const string _carregarPorNomeEId = @"SELECT Id, IdDisciplina, IdSerie, Nome FROM TBMateria WHERE Nome = @Nome AND IdSerie = @Id";

        private const string _atualizar = @"UPDATE TBMateria SET Nome = @Nome, IdDisciplina = @IdDisciplina, IdSerie = @IdSerie WHERE Id = @Id";

        private const string _excluir = @"DELETE FROM TBMateria WHERE Id = @Id";

        private const string sqlGetDisciplinas = @"SELECT TBMateria.Id, TBMateria.Nome, TBMateria.IdSerie FROM TBMateria INNER JOIN TBDisciplina ON TBDisciplina.Id = TBMateria.IdDisciplina WHERE TBDisciplina.Id = @IdDisciplina";

        private const string sqlGetMateriaFromQuestaoById = @"SELECT Id FROM TBQuestao WHERE IdMateria = @Id";
        #endregion queries

        public MateriaSQLRepositorio(TipoRepositorio tipo) : base(tipo)
        {
        }

        public override Materia Adicionar(Materia entidade)
        {
            entidade.Id = base.ExecutarAtualizacao(_inserir, EntidadeParaTupla(entidade, false));
            return entidade;
        }

        public override Materia Atualizar(Materia entidade)
        {
            base.ExecutarAtualizacao(_atualizar, EntidadeParaTupla(entidade, true), false);
            return entidade;
        }

        public override IList<Materia> BuscarTodos()
        {
            return base.ConsultarLista(_carregarTodos, TuplaParaEntidade);
        }

        public override Materia ConsultarPorId(int id)
        {
            return base.ConsultarEntidade(_carregarPorId, TuplaParaEntidade, new Dictionary<String, Object>() { { "Id", id } });
        }

        public override int Excluir(int id)
        {
            return base.Excluir(_excluir, id);
        }

        public IList<Materia> ConsultarPorNome(String nome)
        {
            return base.ConsultarLista(_carregarPorNome, TuplaParaEntidade, new Dictionary<String, Object>() { { "Nome", nome } });
        }

        public IList<Materia> ConsultarPorNomeEId(String nome, int id)
        {
            return base.ConsultarLista(_carregarPorNomeEId, TuplaParaEntidade, new Dictionary<String, Object>() { { "Nome", nome }, { "Id", id } });

        }
        public IList<Materia> PesquisarMateria(string NomePesquisa)
        {
            return base.ConsultarLista(_pesquisar, TuplaParaEntidade, new Dictionary<String, Object>() { { "Pesquisa", '%' + NomePesquisa + '%' } });
        }

        public Dictionary<String, Object> EntidadeParaTupla(Materia materia, bool temId)
        {
            Dictionary<String, Object> parametros = new Dictionary<string, object>();
            parametros.Add("Nome", materia.Nome);
            parametros.Add("IdDisciplina", materia.Disciplina.Id);
            parametros.Add("IdSerie", materia.Serie.Id);

            if (temId)
            {
                parametros.Add("Id", materia.Id);
            }

            return parametros;
        }

        public IList<Materia> Pesquisar(string pesquisar)
        {
            throw new NotImplementedException();
        }

        private static Func<IDataReader, Materia> TuplaParaEntidade = reader =>
          new Materia()
          {
              Id = Convert.ToInt32(reader["Id"]),
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
              }
          };
    }
}

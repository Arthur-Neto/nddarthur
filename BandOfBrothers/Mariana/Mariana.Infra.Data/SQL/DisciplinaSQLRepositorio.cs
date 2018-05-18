using Mariana.Dominio;
using Mariana.Dominio.Interfaces;
using System;
using System.Collections.Generic;
using System.Data;

namespace Mariana.Infra.Data.SQL
{
    public class DisciplinaSQLRepositorio : Db<Disciplina>, IDisciplinaRepositorio
    {
        #region Querys 
        private const string _inserir = @"INSERT INTO TBDisciplina (Nome) VALUES (@Nome);";

        private const string _carregarTodos = @"SELECT Id, Nome FROM TBDisciplina";

        private const string _pesquisar = @"SELECT Id, Nome FROM TBDisciplina WHERE Nome like '%'+@Pesquisa+'%'";

        private const string _carregarPorId = @"SELECT Id, Nome FROM TBDisciplina WHERE Id = @Id";

        private const string _carregarPorNomeEId = @"SELECT Id, Nome FROM TBDisciplina WHERE Nome = @Nome AND Id <> @Id";

        private const string sqlGetDisciplinaFromMateriaById = @"SELECT Id FROM TBMateria WHERE IdDisciplina = @Id";

        private const string _atualizar = @"UPDATE TBDisciplina SET Nome = @Nome WHERE Id = @Id";

        private readonly string _carregarPorNome = @"SELECT * FROM TBDisciplina WHERE Nome = {0}Nome";

        private const string _excluir = @"DELETE FROM TBDisciplina WHERE Id = @Id";
        #endregion queries

        public DisciplinaSQLRepositorio(TipoRepositorio tipo) : base(tipo)
        {
        }

        public override Disciplina Adicionar(Disciplina entidade)
        {
            entidade.Id = base.ExecutarAtualizacao(_inserir, EntidadeParaTupla(entidade, false));
            return entidade;
        }

        public override Disciplina Atualizar(Disciplina entidade)
        {
            base.ExecutarAtualizacao(_atualizar, EntidadeParaTupla(entidade, true), false);
            return entidade;
        }

        public override IList<Disciplina> BuscarTodos()
        {
            return base.ConsultarLista(_carregarTodos, TuplaParaEntidade);
        }

        public override Disciplina ConsultarPorId(int id)
        {
            return base.ConsultarEntidade(_carregarPorId, TuplaParaEntidade, new Dictionary<String, Object>() { { "Id", id } });
        }
        public IList<Disciplina> PesquisarDisciplina(string NomePesquisa)
        {
            return base.ConsultarLista(_pesquisar, TuplaParaEntidade, new Dictionary<String, Object>() { { "Pesquisa", '%' + NomePesquisa + '%' } });
        }
        public override int Excluir(int id)
        {
            return base.Excluir(_excluir, id);
        }

        public IList<Disciplina> ConsultarPorNome(String nome)
        {
            return base.ConsultarLista(_carregarPorNome, TuplaParaEntidade, new Dictionary<String, Object>() { { "Nome", nome } });
        }

        public IList<Disciplina> ConsultarPorNomeEId(String nome, int id)
        {
            return base.ConsultarLista(_carregarPorNomeEId, TuplaParaEntidade, new Dictionary<String, Object>() { { "Nome", nome }, { "Id", id } });

        }

        public Dictionary<String, Object> EntidadeParaTupla(Disciplina disciplina, bool temId)
        {
            Dictionary<String, Object> parametros = new Dictionary<string, object>();
            parametros.Add("Nome", disciplina.Nome);

            if (temId)
            {
                parametros.Add("Id", disciplina.Id);
            }

            return parametros;
        }

        public IList<Disciplina> Pesquisar(string pesquisar)
        {
            throw new NotImplementedException();
        }

        private static Func<IDataReader, Disciplina> TuplaParaEntidade = reader =>
          new Disciplina()
          {
              Id = Convert.ToInt32(reader["Id"]),
              Nome = Convert.ToString(reader["Nome"])
          };
    }
}

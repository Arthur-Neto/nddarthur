using Mariana.Dominio;
using Mariana.Dominio.Interfaces;
using System;
using System.Collections.Generic;
using System.Data;

namespace Mariana.Infra.Data.SQL
{
    public class SerieSQLRepositorio : Db<Serie>, ISerieRepositorio
    {
        #region Querys 
        private const string _inserir = @"INSERT INTO TBSerie (Numero) VALUES (@Numero);";

        private const string _carregarTodos = @"SELECT Id, Numero FROM TBSerie";

        private const string _carregarPorId = @"SELECT Id, Numero FROM TBSerie WHERE Id = @Id";

        private const string _carregarPorNumero = @"SELECT Id, Numero FROM TBSerie WHERE Numero = @Numero";

        private const string _atualizar = @"UPDATE TBSerie SET Numero = @Numero WHERE Id = @Id";

        private const string _excluir = @"DELETE FROM TBSerie WHERE Id = @Id";

        private readonly string _carregarPorNumeroEId = @"SELECT * FROM TBSerie WHERE numero = {0}numero AND id != {0}id";

        private const string sqlGetSerieFromMateriaById = @"SELECT Id FROM TBMateria WHERE IdSerie = @Id";

        #endregion queries

        public SerieSQLRepositorio(TipoRepositorio tipo) : base(tipo)
        {
        }

        public override Serie Adicionar(Serie entidade)
        {
            entidade.Id = base.ExecutarAtualizacao(_inserir, EntidadeParaTupla(entidade, false));
            return entidade;
        }

        public override Serie Atualizar(Serie entidade)
        {
            base.ExecutarAtualizacao(_atualizar, EntidadeParaTupla(entidade, true), false);
            return entidade;
        }

        public override IList<Serie> BuscarTodos()
        {
            return base.ConsultarLista(_carregarTodos, TuplaParaEntidade);
        }

        public override Serie ConsultarPorId(int id)
        {
            return base.ConsultarEntidade(_carregarPorId, TuplaParaEntidade, new Dictionary<String, Object>() { { "Id", id } });
        }

        public override int Excluir(int id)
        {
            return base.Excluir(_excluir, id);
        }

        public IList<Serie> ConsultarPorNumeroEId(int numero, int id)
        {
            return base.ConsultarLista(_carregarPorNumeroEId, TuplaParaEntidade, new Dictionary<String, Object>() { { "Numero", numero }, { "Id", id } });
        }

        public IList<Serie> ConsultarPorNumero(int numero)
        {
            return base.ConsultarLista(_carregarPorNumero, TuplaParaEntidade, new Dictionary<String, Object>() { { "Numero", numero } });
        }

        public Dictionary<String, Object> EntidadeParaTupla(Serie serie, bool temId)
        {
            Dictionary<String, Object> parametros = new Dictionary<string, object>();
            parametros.Add("Numero", serie.NumeroSerie);

            if (temId)
            {
                parametros.Add("Id", serie.Id);
            }

            return parametros;
        }

        public IList<Serie> Pesquisar(string pesquisar)
        {
            throw new NotImplementedException();
        }

        private static Func<IDataReader, Serie> TuplaParaEntidade = reader =>
          new Serie()
          {
              Id = Convert.ToInt32(reader["Id"]),
              NumeroSerie = Convert.ToInt32(reader["Numero"])
          };
    }
}

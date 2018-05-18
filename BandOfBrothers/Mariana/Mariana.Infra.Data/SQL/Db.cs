using Mariana.Dominio;
using Mariana.Dominio.Interfaces;
using Mariana.Infra.Data.Nucleo;
using System;
using System.Collections.Generic;
using System.Data;

namespace Mariana.Infra.Data.SQL
{
    public abstract class Db<T> where T : Entidade
    {
        protected IDbConnection Conexao { get; set; }
        protected IDbCommand Comando { get; set; }
        protected IDataReader Leitor { get; set; }
        protected TipoRepositorio Tipo { get; set; }

        public Db(TipoRepositorio tipo)
        {
            this.Tipo = tipo;
            Conexao = ConexaoDBFactory.CriarConexao(tipo);
            Comando = Conexao.CreateCommand();
        }

        protected int ExecutarAtualizacao(string sql, Dictionary<string, object> parametros = null, bool carregarId = true)
        {
            int id = 0;
            using (Conexao)
            {
                using (Comando)
                {
                    Conexao.ConnectionString = ConexaoDBFactory.ObterStringDeConexao(Tipo).ConnectionString;

                    Comando.Parameters.Clear();
                    Comando.Connection = Conexao;
                    Comando.CommandText = sql.FormatarSQL(Tipo, carregarId);

                    Conexao.Open();

                    Comando.AdicionarParametros(parametros);

                    if (carregarId)
                    {
                        id = Convert.ToInt32(Comando.ExecuteScalar());
                    }
                    else
                    {
                        Comando.ExecuteNonQuery();
                    }
                }
            }

            return id;
        }

        public IList<T> ConsultarLista(string sql, Func<IDataReader, T> TuplaParaEntidade, Dictionary<string, object> parametros = null)
        {
            var list = new List<T>();

            using (Conexao)
            {
                using (Comando)
                {
                    Conexao.ConnectionString = ConexaoDBFactory.ObterStringDeConexao(Tipo).ConnectionString;

                    Comando.Parameters.Clear();
                    Comando.Connection = Conexao;
                    Comando.CommandText = sql.FormatarSQL(Tipo);

                    Conexao.Open();

                    Comando.AdicionarParametros(parametros);

                    Leitor = Comando.ExecuteReader();

                    while (Leitor.Read())
                    {
                        list.Add(TuplaParaEntidade(Leitor));
                    }
                }
            }

            return list;
        }
        public T ConsultarEntidade(string sql, Func<IDataReader, T> TuplaParaEntidade, Dictionary<string, object> parametros = null)
        {
            using (Conexao)
            {
                using (Comando)
                {
                    Conexao.ConnectionString = ConexaoDBFactory.ObterStringDeConexao(Tipo).ConnectionString;

                    Comando.Parameters.Clear();
                    Comando.Connection = Conexao;
                    Comando.CommandText = sql.FormatarSQL(Tipo);

                    Conexao.Open();

                    Comando.AdicionarParametros(parametros);

                    Leitor = Comando.ExecuteReader();

                    if (Leitor.Read())
                    {
                        return TuplaParaEntidade(Leitor);
                    }
                }
            }

            return null;
        }

        public int Excluir(string sql, int id)
        {
            var items = 0;

            using (Conexao)
            {
                Conexao.ConnectionString = ConexaoDBFactory.ObterStringDeConexao(Tipo).ConnectionString;

                Comando.Parameters.Clear();
                Comando.Connection = Conexao;
                Comando.CommandText = sql.FormatarSQL(Tipo);

                Conexao.Open();

                var parametro = Comando.CreateParameter();
                parametro.Value = id;
                parametro.ParameterName = "Id";
                Comando.Parameters.Add(parametro);

                items = Comando.ExecuteNonQuery();
            }


            return items;
        }

        public abstract T Adicionar(T entidade);

        public abstract T Atualizar(T entidade);

        public abstract IList<T> BuscarTodos();

        public abstract T ConsultarPorId(int id);

        public abstract int Excluir(int id);
    }
}

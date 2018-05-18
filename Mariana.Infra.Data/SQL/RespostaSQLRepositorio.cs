using Mariana.Dominio;
using Mariana.Dominio.Interfaces;
using System;
using System.Collections.Generic;
using System.Data;

namespace Mariana.Infra.Data.SQL
{
    public class RespostaSQLRepositorio : Db<Resposta>, IRespostaRepositorio
    {
        private const string _inserir = @"INSERT INTO TBResposta (IdQuestao, CorpoResposta, Correta) VALUES (@IdQuestao, @CorpoResposta, @Correta)";
        private const string _carregarPorId = @"SELECT * FROM TBResposta WHERE IdQuestao = @Id";
        private const string _excluir = @"DELETE FROM TBResposta WHERE Id = @Id";

        public RespostaSQLRepositorio(TipoRepositorio tipo) : base(tipo)
        {
        }

        public override Resposta Adicionar(Resposta entidade)
        {
            entidade.Id = base.ExecutarAtualizacao(_inserir, EntidadeParaTupla(entidade, false));
            return entidade;
        }

        public Resposta AdicionarComQuestaoId(Resposta entidade, int idQuestao)
        {
            entidade.Id = base.ExecutarAtualizacao(_inserir, EntidadeParaTupla(entidade, false, idQuestao));
            return entidade;
        }

        public override Resposta ConsultarPorId(int Id)
        {
            return base.ConsultarEntidade(_carregarPorId, TuplaParaEntidade, new Dictionary<String, Object>() { { "Id", Id } });
        }

        public override int Excluir(int Id)
        {
            return base.Excluir(_excluir, Id);
        }

        public Dictionary<String, Object> EntidadeParaTupla(Resposta resposta, bool temId, int idQuestao = 1)
        {
            Dictionary<String, Object> parametros = new Dictionary<string, object>();
            parametros.Add("CorpoResposta", resposta.CorpoResposta);
            parametros.Add("Correta", resposta.Correta);
            parametros.Add("IdQuestao", idQuestao);

            if (temId)
            {
                parametros.Add("Id", resposta.Id);
            }

            return parametros;
        }

        public override Resposta Atualizar(Resposta entidade)
        {
            throw new NotImplementedException();
        }

        public override IList<Resposta> BuscarTodos()
        {
            throw new NotImplementedException();
        }

        public IList<Resposta> ObterRespostas(int id)
        {
            return base.ConsultarLista(_carregarPorId, TuplaParaEntidade, new Dictionary<String, Object>() { { "Id", id } });
        }

        public IList<Resposta> BuscarRepostaPorQuestaoId(int id)
        {
            return base.ConsultarLista(_carregarPorId, TuplaParaEntidade, new Dictionary<String, Object>() { { "Id", id } });
        }

        public IList<Resposta> Pesquisar(string pesquisar)
        {
            throw new NotImplementedException();
        }

        private static Func<IDataReader, Resposta> TuplaParaEntidade = reader =>
          new Resposta()
          {
              Id = Convert.ToInt32(reader["Id"]),
              CorpoResposta = Convert.ToString(reader["CorpoResposta"]),
              Correta = Convert.ToBoolean(reader["Correta"])
          };
    }
}

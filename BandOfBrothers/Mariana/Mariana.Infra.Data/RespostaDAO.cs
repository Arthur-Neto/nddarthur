using Mariana.Dominio;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mariana.Infra.Data
{
    public class RespostaDAO
    {
        private const string sqlInsertResposta = @"INSERT INTO TBResposta (IdQuestao, CorpoResposta, Correta) VALUES (@IdQuestao, @CorpoResposta, @Correta)";
        private const string sqlGetRespostas = @"SELECT * FROM TBResposta WHERE IdQuestao = @Id";
        private const string sqlDeleteResposta = @"DELETE FROM TBResposta WHERE Id = @Id";

        public RespostaDAO()
        {

        }

        public void Atualizar(IList<Resposta> respostasAdicionadas, IList<Resposta> respostasDeletadas, Questao questao)
        {

            foreach (var item in respostasAdicionadas)
                DB.Add(sqlInsertResposta, GetParam(item, questao.Id));
            foreach (var item in respostasDeletadas)
            {
                var dic = new Dictionary<string, object>();
                dic.Add("Id", item.Id);
                DB.Delete(sqlDeleteResposta, dic);
            }
        }

        public IList<Resposta> ObterRespostas(int id)
        {
            var dic = new Dictionary<string, object>();
            dic.Add("Id", id);

            return DB.GetAllById(sqlGetRespostas, Converter, dic);
        }

        private static Resposta Converter(IDataReader _reader)
        {
            Resposta resposta = new Resposta();

            resposta.Id = Convert.ToInt32(_reader["Id"]);
            resposta.CorpoResposta = Convert.ToString(_reader["CorpoResposta"]);
            resposta.Correta = Convert.ToBoolean(_reader["Correta"]);


            return resposta;
        }

        public Dictionary<string, object> GetParam(Resposta resposta, int idQuestao)
        {
            var dic = new Dictionary<string, object>();
            dic.Add("IdQuestao", idQuestao);
            dic.Add("CorpoResposta", resposta.CorpoResposta);
            dic.Add("Correta", resposta.Correta);
            return dic;
        }
    }
}

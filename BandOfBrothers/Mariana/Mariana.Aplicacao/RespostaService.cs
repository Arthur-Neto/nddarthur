using Mariana.Dominio;
using Mariana.Dominio.Exceptions;
using Mariana.Dominio.Interfaces;
using Mariana.Infra.Data.Nucleo;
using System;
using System.Collections.Generic;

namespace Mariana.Aplicacao
{
    public class RespostaService : Servico<Resposta>
    {
        public RespostaService() : base(RepositorioIoC.Resposta)
        {

        }

        public Resposta Adicionar(Resposta entidade, int idQuestao)
        {
            IRespostaRepositorio resposta = base.Repositorio as IRespostaRepositorio;
            return resposta.AdicionarComQuestaoId(entidade, idQuestao);
        }

        public IList<Resposta> BuscarRespostasPorQuestaoId(int id)
        {
            IRespostaRepositorio respostaRepositorio = base.Repositorio as IRespostaRepositorio;
            return respostaRepositorio.BuscarRepostaPorQuestaoId(id);
        }

        public override int Excluir(Resposta entidade)
        {
            try
            {
                return base.Excluir(entidade);
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}

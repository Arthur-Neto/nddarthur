using Mariana.Dominio;
using Mariana.Dominio.Exceptions;
using Mariana.Dominio.Interfaces;
using Mariana.Infra.Data.Nucleo;
using System;
using System.Collections.Generic;

namespace Mariana.Aplicacao
{
    public class QuestaoService : Servico<Questao>
    {
        private RespostaService _respostaService;

        public QuestaoService(RespostaService respostaService) : base(RepositorioIoC.Questao)
        {
            _respostaService = respostaService;
        }

        public override Questao Adicionar(Questao entidade)
        {
            try
            {
                entidade.Validar();

                entidade = Repositorio.Adicionar(entidade);

                foreach (var item in entidade.Respostas)
                {
                    _respostaService.Adicionar(item, entidade.Id);
                }
            }
            catch (Exception e)
            {
                throw e;
            }

            return entidade;
        }

        public IList<Resposta> BuscarTodasRespostas(int id)
        {
            try
            {
                RespostaService resposta = new RespostaService();
                return resposta.BuscarRespostasPorQuestaoId(id);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public IList<Questao> CarregarPorNome(string nome)
        {
            try
            {
                IQuestaoRepositorio questaoRepositorio = base.Repositorio as IQuestaoRepositorio;
                return questaoRepositorio.ConsultarPorNome(nome);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public void ValidarExistenciaNome(string nome, int id)
        {
            try
            {
                IQuestaoRepositorio questaoRepositorio = base.Repositorio as IQuestaoRepositorio;
                IList<Questao> questoes = questaoRepositorio.ConsultarPorNomeEId(nome, id);

                foreach (var item in questoes)
                {
                    if (id != item.Id)
                        throw new ValidacaoException("Esta matéria já foi cadastrada.");

                }

            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public override int Excluir(Questao entidade)
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

        public override IList<Questao> Pesquisar(string pesquisa)
        {
            IQuestaoRepositorio testeRepositorio = base.Repositorio as IQuestaoRepositorio;

            try
            {
                return testeRepositorio.PesquisarQuestao(pesquisa);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        internal IList<Questao> CarregarPorMateria(int id, MateriaService servico)
        {
            List<Questao> resultado = new List<Questao>();
            foreach (var item in this.BuscarTodos())
            {
                if (item.Materia.Id == id)
                    resultado.Add(item);
            }
            return resultado;
        }
    }
}

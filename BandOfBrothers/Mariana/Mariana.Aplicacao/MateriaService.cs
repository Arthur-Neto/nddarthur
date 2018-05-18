using Mariana.Dominio;
using Mariana.Dominio.Exceptions;
using Mariana.Dominio.Interfaces;
using Mariana.Infra.Data.Nucleo;
using System;
using System.Collections.Generic;

namespace Mariana.Aplicacao
{
    public class MateriaService : Servico<Materia>
    {
        private QuestaoService _questaoService;

        public MateriaService(QuestaoService questaoService) : base(RepositorioIoC.Materia)
        {
            this._questaoService = questaoService;
        }

        public IList<Materia> CarregarPorNumero(string nome)
        {
            try
            {
                IMateriaRepositorio materiaRepositorio = base.Repositorio as IMateriaRepositorio;
                return materiaRepositorio.ConsultarPorNome(nome);
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
                IMateriaRepositorio materiaRepositorio = base.Repositorio as IMateriaRepositorio;
                IList<Materia> materias = materiaRepositorio.ConsultarPorNomeEId(nome, id);
                if (materias.Count > 0)
                {
                    throw new ValidacaoException("Esta matéria já foi cadastrada.");
                }
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public override int Excluir(Materia entidade)
        {
            if (_questaoService.CarregarPorMateria(entidade.Id, this).Count > 0)
            {
                throw new ValidacaoException("Esta matéria não pode ser excluída pois está vínculada a uma questão.");
            }

            return base.Excluir(entidade);
        }

        public IList<Disciplina> CarregarTodasDisciplinas(DisciplinaService servico)
        {
            return servico.BuscarTodos();
        }
        public override IList<Materia> Pesquisar(string pesquisa)
        {
            IMateriaRepositorio materiaRepositorio = base.Repositorio as IMateriaRepositorio;

            try
            {
                return materiaRepositorio.PesquisarMateria(pesquisa);
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        public IList<Serie> CarregarTodasSeries(SerieService servico)
        {
            return servico.BuscarTodos();
        }

        public IList<Disciplina> CarregarPorDisciplina(int id, DisciplinaService servico)
        {
            List<Disciplina> resultado = new List<Disciplina>();
            foreach (var item in this.BuscarTodos())
            {
                if (item.Disciplina.Id == id)
                    resultado.Add(item.Disciplina);
            }
            return resultado;
        }

        public IList<Serie> CarregarPorSerie(int id, SerieService servico)
        {
            List<Serie> resultado = new List<Serie>();
            foreach (var item in this.BuscarTodos())
            {
                if (item.Serie.Id == id)
                    resultado.Add(item.Serie);
            }
            return resultado;
        }
    }
}

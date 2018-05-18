using Mariana.Dominio;
using Mariana.Dominio.Exceptions;
using Mariana.Dominio.Interfaces;
using Mariana.Infra.Data.Nucleo;
using System;
using System.Collections.Generic;

namespace Mariana.Aplicacao
{
    public class DisciplinaService : Servico<Disciplina>
    {
        private MateriaService _materiaService;

        public DisciplinaService(MateriaService materiaService) : base(RepositorioIoC.Disciplina)
        {
            this._materiaService = materiaService;
        }

        public IList<Disciplina> CarregarPorNome(String nome)
        {
            try
            {
                IDisciplinaRepositorio disciplinaRepositorio = base.Repositorio as IDisciplinaRepositorio;
                return disciplinaRepositorio.ConsultarPorNome(nome);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public void ValidarExistenciaNome(String nome, int id)
        {
            try
            {
                IDisciplinaRepositorio disciplinaRepositorio = base.Repositorio as IDisciplinaRepositorio;
                IList<Disciplina> disciplinas = disciplinaRepositorio.ConsultarPorNomeEId(nome, id);
                if (disciplinas.Count > 0)
                {
                    throw new ValidacaoException("Este nome já foi informado");
                }
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        public override IList<Disciplina> Pesquisar(string pesquisa)
        {
            IDisciplinaRepositorio questaoRepositorio = base.Repositorio as IDisciplinaRepositorio;

            try
            {
                return questaoRepositorio.PesquisarDisciplina(pesquisa);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public override int Excluir(Disciplina entidade)
        {
            if (_materiaService.CarregarPorDisciplina(entidade.Id, this).Count > 0)
            {
                throw new ValidacaoException("Esta disciplina não pode ser excluída pois está vínculada a uma matéria.");
            }

            return base.Excluir(entidade);
        }
    }
}

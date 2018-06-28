using System.Collections.Generic;
using TutorialORM.Dominio.Base;
using TutorialORM.Dominio.Exceptions;
using TutorialORM.Dominio.Features.Alunos;

namespace TutorialORM.Aplicacao.Features.Alunos
{
    public class AlunoServico
    {
        public AlunoServico(IAlunoRepositorio repositorio)
        {
            Repositorio = repositorio;
        }

        public IRepositorio<Aluno> Repositorio { get; private set; }

        public Aluno Atualizar(Aluno aluno)
        {
            if (aluno.Id < 1)
                throw new IdentificadorInvalidoException();

            aluno.Validar();

            return Repositorio.Atualizar(aluno);
        }

        public void Deletar(Aluno aluno)
        {
            if (aluno.Id < 1)
                throw new IdentificadorInvalidoException();

            Repositorio.Deletar(aluno);
        }

        public Aluno PegarPorId(long id)
        {
            if (id < 1)
                throw new IdentificadorInvalidoException();

            return Repositorio.PegarPorId(id);
        }

        public IEnumerable<Aluno> PegarTodos()
        {
            return Repositorio.PegarTodos();
        }

        public Aluno Salvar(Aluno aluno)
        {
            aluno.Validar();

            return Repositorio.Salvar(aluno);
        }
    }
}

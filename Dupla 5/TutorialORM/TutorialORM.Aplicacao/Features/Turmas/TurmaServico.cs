using System.Collections.Generic;
using TutorialORM.Aplicacao.Base;
using TutorialORM.Dominio.Base;
using TutorialORM.Dominio.Exceptions;
using TutorialORM.Dominio.Features.Turmas;

namespace TutorialORM.Aplicacao.Features.Turmas
{
    public class TurmaServico : IServico<Turma>
    {
        public TurmaServico(ITurmaRepositorio repositorio)
        {
            Repositorio = repositorio;
        }

        public IRepositorio<Turma> Repositorio { get; set; }

        public Turma Atualizar(Turma turma)
        {
            if (turma.Id < 1)
                throw new IdentificadorInvalidoException();

            turma.Validar();

            return Repositorio.Atualizar(turma);
        }

        public void Deletar(Turma turma)
        {
            if (turma.Id < 1)
                throw new IdentificadorInvalidoException();

            Repositorio.Deletar(turma);
        }

        public Turma PegarPorId(long id)
        {
            if (id < 1)
                throw new IdentificadorInvalidoException();

            return Repositorio.PegarPorId(id);
        }

        public IEnumerable<Turma> PegarTodos()
        {
            return Repositorio.PegarTodos();
        }

        public Turma Salvar(Turma turma)
        {
            turma.Validar();

            return Repositorio.Salvar(turma);
        }
    }
}

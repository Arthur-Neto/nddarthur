using System.Collections.Generic;
using TutorialORM.Aplicacao.Base;
using TutorialORM.Dominio.Base;
using TutorialORM.Dominio.Exceptions;
using TutorialORM.Dominio.Features.Turmas;

namespace TutorialORM.Aplicacao.Features.Turmas
{
    public class TurmaServico : IServico<Turma>
    {
        public ITurmaRepositorio _repositorio;

        public TurmaServico(ITurmaRepositorio repositorio)
        {
            _repositorio = repositorio;
        }

        public Turma Atualizar(Turma turma)
        {
            if (turma.Id < 1)
                throw new IdentificadorInvalidoException();

            turma.Validar();

            return _repositorio.Atualizar(turma);
        }

        public void Deletar(Turma turma)
        {
            if (turma.Id < 1)
                throw new IdentificadorInvalidoException();

            _repositorio.VerificaDependencia(turma);
            _repositorio.Deletar(turma);
        }

        public Turma PegarPorId(long id)
        {
            if (id < 1)
                throw new IdentificadorInvalidoException();

            return _repositorio.PegarPorId(id);
        }

        public IEnumerable<Turma> PegarTodos()
        {
            return _repositorio.PegarTodos();
        }

        public Turma Salvar(Turma turma)
        {
            turma.Validar();

            return _repositorio.Salvar(turma);
        }
    }
}

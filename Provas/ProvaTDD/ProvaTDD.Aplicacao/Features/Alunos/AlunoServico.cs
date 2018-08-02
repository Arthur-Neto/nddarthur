using ProvaTDD.Aplicacao.Base;
using ProvaTDD.Dominio.Exceptions;
using ProvaTDD.Dominio.Features.Alunos;
using System.Collections.Generic;

namespace ProvaTDD.Aplicacao.Features.Alunos
{
    public class AlunoServico : Servico<Aluno>
    {
        public AlunoServico(IAlunoRepositorio repositorioAluno) : base(repositorioAluno) { }

        public override Aluno Atualizar(Aluno entidade)
        {
            if (entidade.Id == 0)
                throw new IdentifierUndefinedException();

            entidade.Validar();
            Repositorio.Atualizar(entidade);

            return PegarPorId(entidade.Id);
        }

        public override void Deletar(Aluno entidade)
        {
            if (entidade.Id == 0)
                throw new IdentifierUndefinedException();

            Repositorio.Deletar(entidade);
        }

        public override Aluno PegarPorId(long id)
        {
            if (id == 0)
                throw new IdentifierUndefinedException();

            return Repositorio.PegarPorId(id);
        }

        public override IList<Aluno> PegarTodos()
        {
            return Repositorio.PegarTodos();
        }

        public override Aluno Salvar(Aluno entidade)
        {
            entidade.Validar();
            return Repositorio.Salvar(entidade);
        }
    }
}

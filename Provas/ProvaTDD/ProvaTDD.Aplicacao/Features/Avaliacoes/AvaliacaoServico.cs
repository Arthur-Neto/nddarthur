using ProvaTDD.Aplicacao.Base;
using ProvaTDD.Dominio.Exceptions;
using ProvaTDD.Dominio.Features.Avaliacoes;
using System.Collections.Generic;

namespace ProvaTDD.Aplicacao.Features.Avaliacoes
{
    public class AvaliacaoServico : Servico<Avaliacao>
    {
        public AvaliacaoServico(IAvaliacaoRepositorio repositorioAluno) : base(repositorioAluno) { }

        public override Avaliacao Atualizar(Avaliacao entidade)
        {
            if (entidade.Id == 0)
                throw new IdentifierUndefinedException();

            entidade.Validar();
            Repositorio.Atualizar(entidade);

            return PegarPorId(entidade.Id);
        }

        public override void Deletar(Avaliacao entidade)
        {
            if (entidade.Id == 0)
                throw new IdentifierUndefinedException();

            Repositorio.Deletar(entidade);
        }

        public override Avaliacao PegarPorId(long id)
        {
            if (id == 0)
                throw new IdentifierUndefinedException();

            return Repositorio.PegarPorId(id);
        }

        public override IList<Avaliacao> PegarTodos()
        {
            return Repositorio.PegarTodos();
        }

        public override Avaliacao Salvar(Avaliacao entidade)
        {
            entidade.Validar();
            return Repositorio.Salvar(entidade);
        }
    }
}

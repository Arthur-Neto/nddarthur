using ProvaTDD.Aplicacao.Base;
using ProvaTDD.Dominio.Exceptions;
using ProvaTDD.Dominio.Features.Resultados;
using System.Collections.Generic;

namespace ProvaTDD.Aplicacao.Features.Resultados
{
    public class ResultadoServico : Servico<Resultado>
    {
        public ResultadoServico(IResultadoRepositorio repositorioAluno) : base(repositorioAluno) { }

        public override Resultado Atualizar(Resultado entidade)
        {
            if (entidade.Id == 0)
                throw new IdentifierUndefinedException();

            entidade.Validar();
            Repositorio.Atualizar(entidade);

            return PegarPorId(entidade.Id);
        }

        public override void Deletar(Resultado entidade)
        {
            if (entidade.Id == 0)
                throw new IdentifierUndefinedException();

            Repositorio.Deletar(entidade);
        }

        public override Resultado PegarPorId(long id)
        {
            if (id == 0)
                throw new IdentifierUndefinedException();

            return Repositorio.PegarPorId(id);
        }

        public override IList<Resultado> PegarTodos()
        {
            return Repositorio.PegarTodos();
        }

        public override Resultado Salvar(Resultado entidade)
        {
            entidade.Validar();
            return Repositorio.Salvar(entidade);
        }
    }
}

using NFe.Dominio.Base;
using NFe.Dominio.Exceptions;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

namespace NFe.Aplicacao.Base
{
    [ExcludeFromCodeCoverage]
    public abstract class Servico<T> : IServico<T> where T : Entidade
    {
        public IRepositorio<T> Repositorio { get; set; }

        public Servico(IRepositorio<T> repositorio)
        {
            this.Repositorio = repositorio;
        }

        public virtual T Salvar(T entidade)
        {
            entidade = Repositorio.Salvar(entidade);

            return entidade;
        }

        public virtual T Atualizar(T entidade)
        {
            entidade = Repositorio.Atualizar(entidade);

            return entidade;
        }

        public virtual T PegarPorId(long id)
        {
            if (id == 0)
                throw new IdentifierUndefinedException();

            return Repositorio.PegarPorId(id);
        }

        public virtual IEnumerable<T> PegarTodos()
        {
            return Repositorio.PegarTodos();
        }

        public virtual void Deletar(T entidade)
        {
            Repositorio.Deletar(entidade);
        }
    }
}

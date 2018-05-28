using Loterica.Dominio.Base;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

namespace Loterica.Aplicacao.Base
{
    [ExcludeFromCodeCoverage]
    public abstract class Servico<T> where T : Entidade
    {
        protected IRepository<T> Repositorio { get; set; }

        public Servico(IRepository<T> repositorio)
        {
            this.Repositorio = repositorio;
        }

        public virtual T Adicionar(T entidade)
        {
            entidade = Repositorio.Adicionar(entidade);

            return entidade;
        }

        public virtual T Atualizar(T entidade)
        {
            entidade = Repositorio.Atualizar(entidade);

            return entidade;
        }

        public virtual T ConsultarPorId(long id)
        {
            return Repositorio.ObterPorId(id);
        }

        public virtual IEnumerable<T> BuscarTodos()
        {
            return Repositorio.PegarTodos();
        }

        public virtual void Excluir(T entidade)
        {
            Repositorio.Deletar(entidade);
        }
    }
}

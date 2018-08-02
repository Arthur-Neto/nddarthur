using ProvaTDD.Dominio.Base;
using System.Collections.Generic;

namespace ProvaTDD.Aplicacao.Base
{
    public abstract class Servico<T> where T : Entidade
    {
        public IRepositorio<T> Repositorio { get; set; }

        public Servico(IRepositorio<T> repositorio)
        {
            this.Repositorio = repositorio;
        }

        public abstract T Salvar(T entidade);
        public abstract T Atualizar(T entidade);
        public abstract void Deletar(T entidade);
        public abstract IList<T> PegarTodos();
        public abstract T PegarPorId(long id);
    }
}

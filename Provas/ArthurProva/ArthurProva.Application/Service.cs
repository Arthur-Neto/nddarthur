using ArthurProva.Domain;
using ArthurProva.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArthurProva.Aplicacao
{
    public abstract class Service<T> where T : Entidade
    {
        protected IRepositorio<T> Repositorio { get; set; }

        public Service(IRepositorio<T> repositorio)
        {
            this.Repositorio = repositorio;
        }

        public virtual T Adicionar(T entidade)
        {
            try
            {
                entidade.Validar();

                entidade = Repositorio.Adicionar(entidade);
            }
            catch (Exception e)
            {
                throw e;
            }

            return entidade;
        }

        public virtual T Atualizar(T entidade)
        {
            try
            {
                entidade.Validar();

                entidade = Repositorio.Atualizar(entidade);
            }
            catch (Exception e)
            {
                throw e;
            }

            return entidade;
        }

        public virtual T ConsultarPorId(int id)
        {
            try
            {
                return Repositorio.ConsultarPorId(id);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public virtual IList<T> BuscarTodos()
        {
            try
            {
                return Repositorio.BuscarTodos();
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public virtual int Excluir(T entidade)
        {
            try
            {
                return Repositorio.Excluir(entidade.Id);
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}

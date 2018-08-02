using ArthurProva.Domain;
using ArthurProva.Domain.Exceptions;
using ArthurProva.Domain.Interfaces;
using ArthurProva.Infra.Data;
using System;
using System.Collections.Generic;

namespace ArthurProva.Aplicacao
{
    public class ContatoService : Service<Contato>
    {
        private CompromissoService _compromissoService;

        public ContatoService(CompromissoService compromissoService) : base(RepositorioIoC.Contato)
        {
            _compromissoService = compromissoService;
        }

        public IList<Contato> BuscarContadoLinkado(int id)
        {
            try
            {
                IContatoRepositorio contatoRepositorio = base.Repositorio as IContatoRepositorio;
                return contatoRepositorio.BuscarContatosLinkados(id);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public IList<Contato> BuscarTodosContatos(int id)
        {
            try
            {
                IContatoRepositorio contatoRepositorio = base.Repositorio as IContatoRepositorio;
                return contatoRepositorio.BuscarContatosPorIdCompromisso(id);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public override int Excluir(Contato entidade)
        {
            if (_compromissoService.BuscarContatosLinkados(entidade.Id).Count > 0)
            {
                throw new ValidacaoException("Este contato não pode ser excluido pois esta vinculado a um compromisso");
            }

            return base.Excluir(entidade);
        }

        public void ValidarExistenciaNome(string nome, int id)
        {
            try
            {
                IContatoRepositorio contatoRepositorio = base.Repositorio as IContatoRepositorio;
                IList<Contato> contato = contatoRepositorio.ConsultarPorNomeEId(nome, id);
                if (contato.Count > 0)
                {
                    throw new ValidacaoException("Este contato já foi informado");
                }
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}

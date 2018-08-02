using ArthurProva.Domain;
using ArthurProva.Domain.Interfaces;
using ArthurProva.Infra.Data;
using System;
using System.Collections.Generic;

namespace ArthurProva.Aplicacao
{
    public class CompromissoService : Service<Compromisso>
    {
        private ContatoService _contatoService;

        public CompromissoService(ContatoService contatoService) : base(RepositorioIoC.Compromisso)
        {
            _contatoService = contatoService;
        }

        public IList<Contato> CarregarPorContato(int id)
        {
            List<Contato> resultado = new List<Contato>();
            foreach (var item in _contatoService.BuscarTodosContatos(id))
            {
                resultado.Add(item);
            }
            return resultado;
        }

        public IList<Contato> BuscarContatosLinkados(int id)
        {
            List<Contato> resultado = new List<Contato>();
            foreach (var item in _contatoService.BuscarContadoLinkado(id))
            {
                if (item.Id == id)
                    resultado.Add(item);
            }
            return resultado;
        }
    }
}

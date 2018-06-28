using System.Collections.Generic;
using Projeto_NFe.Dominio.Excecoes;
using Projeto_NFe.Dominio.Features.Transportadores;
using Projeto_NFe.Dominio.Features.NotasFiscais;
using Projeto_NFe.Dominio.Features.Enderecos;

namespace Projeto_NFe.Aplicacao.Features.Transportadores
{
    public class TransportadorServico : ITransportadorServico
    {
        private ITransportadorRepositorio _transportadorRepositorio;
        private INotaFiscalRepositorio _notaFiscalRepositorio;
        private IEnderecoRepositorio _enderecoRepositorio;

        public TransportadorServico(ITransportadorRepositorio transportadorRepositorio, INotaFiscalRepositorio notaFiscalRepositorio, IEnderecoRepositorio enderecoRepositorio)
        {
            _transportadorRepositorio = transportadorRepositorio;
            _notaFiscalRepositorio = notaFiscalRepositorio;
            _enderecoRepositorio = enderecoRepositorio;
        }

        public Transportador Atualizar(Transportador transportador)
        {
            if (transportador.ID <= 0)
                throw new ExcecaoIdentificadorInvalido();

            transportador.Validar();
            return _transportadorRepositorio.Atualizar(transportador);
        }

        public bool Deletar(long id)
        {
            if (id <= 0)
                throw new ExcecaoIdentificadorInvalido();

            var notaFiscal = _notaFiscalRepositorio.ObterPorTransportadorID(id);

            if (notaFiscal != null)
                throw new ExcecaoChaveEstrangeira();

            return _transportadorRepositorio.Deletar(id);
        }

        public Transportador Inserir(Transportador transportador)
        {
            transportador.Validar();

            return _transportadorRepositorio.Inserir(transportador);
        }

        public Transportador ObterPorId(long id)
        {
            if (id <= 0)
                throw new ExcecaoIdentificadorInvalido();

            var transportador = _transportadorRepositorio.ObterPorId(id);

            if (transportador == null) return null;

            transportador.Endereco = _enderecoRepositorio.ObterPorId(transportador.Endereco.ID);

            return transportador;
        }

        public List<Transportador> ObterTodos()
        {
            var transportadores = _transportadorRepositorio.ObterTodos();

            if (transportadores == null)
                return null;

            foreach (var transportador in transportadores)
            {
                transportador.Endereco = _enderecoRepositorio.ObterPorId(transportador.Endereco.ID);
            }

            return transportadores;
        }
    }
}

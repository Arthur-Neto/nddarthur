using AutoMapper;
using Projeto_NFe.Application.Funcionalidades.Transportadoras;
using Projeto_NFe.Application.Funcionalidades.Transportadoras.Comandos;
using Projeto_NFe.Domain.Excecoes;
using Projeto_NFe.Domain.Funcionalidades.Enderecos;
using Projeto_NFe.Domain.Funcionalidades.Transportadoras;
using System.Linq;

namespace Projeto_NFe.Application.Funcionalidades.Transportadoras
{
    public class TransportadorServico : ITransportadorServico
    {
        ITransportadorRepositorio _repositorioTransportador;
        IEnderecoRepositorio _repositorioEndereco;

        public TransportadorServico(ITransportadorRepositorio repositorio, IEnderecoRepositorio repositorioEndereco)
        {
            _repositorioTransportador = repositorio;
            _repositorioEndereco = repositorioEndereco;
        }

        public long Adicionar(TransportadorAdicionarComando comando)
        {
            Transportador transportador = Mapper.Map<TransportadorAdicionarComando, Transportador>(comando);

            return _repositorioTransportador.Adicionar(transportador);
        }

        public bool Atualizar(TransportadorEditarComando comando)
        {
            Transportador transportadorDb = _repositorioTransportador.BuscarPorId(comando.Id) ?? throw new ExcecaoNaoEncontrado();
            Endereco enderecoDb = _repositorioEndereco.BuscarPorId(comando.Endereco.Id);

            Mapper.Map<TransportadorEditarComando, Transportador>(comando, transportadorDb);
            Mapper.Map(comando.Endereco, enderecoDb);

            transportadorDb.Endereco = enderecoDb;

            return _repositorioTransportador.Atualizar(transportadorDb);
        }

        public Transportador BuscarPorId(long id)
        {
            return _repositorioTransportador.BuscarPorId(id) ?? throw new ExcecaoNaoEncontrado();
        }

        public IQueryable<Transportador> BuscarTodos()
        {
            return _repositorioTransportador.BuscarTodos();
        }

        public bool Excluir(TransportadorRemoverComando comando)
        {
            Transportador transportador = _repositorioTransportador.BuscarPorId(comando.Id) ?? throw new ExcecaoNaoEncontrado();

            _repositorioTransportador.Excluir(transportador);

            return _repositorioTransportador.BuscarPorId(transportador.Id) == null ? true : false;
        }
    }
}

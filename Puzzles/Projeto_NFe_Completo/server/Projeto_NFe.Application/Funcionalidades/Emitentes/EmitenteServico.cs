using AutoMapper;
using Projeto_NFe.Application.Funcionalidades.Emitentes.Comandos;
using Projeto_NFe.Domain.Excecoes;
using Projeto_NFe.Domain.Funcionalidades.Emitentes;
using Projeto_NFe.Domain.Funcionalidades.Enderecos;
using System.Linq;

namespace Projeto_NFe.Application.Funcionalidades.Emitentes
{
    public class EmitenteServico : IEmitenteServico
    {
        IEmitenteRepositorio _repositorioEmitente;
        IEnderecoRepositorio _repositorioEndereco;

        public EmitenteServico(IEmitenteRepositorio repositorio, IEnderecoRepositorio repositorioEndereco)
        {
            _repositorioEmitente = repositorio;
            _repositorioEndereco = repositorioEndereco;
        }

        public long Adicionar(EmitenteAdicionarComando comando)
        {
            Emitente emitente = Mapper.Map<EmitenteAdicionarComando, Emitente>(comando);

            return _repositorioEmitente.Adicionar(emitente);
        }

        public bool Atualizar(EmitenteEditarComando comando)
        {
            Emitente emitenteDb = _repositorioEmitente.BuscarPorId(comando.Id) ?? throw new ExcecaoNaoEncontrado();
            Endereco enderecoDb = _repositorioEndereco.BuscarPorId(comando.Endereco.Id);

            Mapper.Map<EmitenteEditarComando, Emitente>(comando, emitenteDb);
            Mapper.Map(comando.Endereco, enderecoDb);

            emitenteDb.Endereco = enderecoDb;

            return _repositorioEmitente.Atualizar(emitenteDb);
        }

        public Emitente BuscarPorId(long id)
        {
            return _repositorioEmitente.BuscarPorId(id) ?? throw new ExcecaoNaoEncontrado();
        }

        public IQueryable<Emitente> BuscarTodos()
        {
            return _repositorioEmitente.BuscarTodos();
        }

        public bool Excluir(EmitenteRemoverComando comando)
        {
            Emitente emitente = _repositorioEmitente.BuscarPorId(comando.Id) ?? throw new ExcecaoNaoEncontrado();

            _repositorioEmitente.Excluir(emitente);

            return _repositorioEmitente.BuscarPorId(emitente.Id) == null ? true : false;
        }
    }
}

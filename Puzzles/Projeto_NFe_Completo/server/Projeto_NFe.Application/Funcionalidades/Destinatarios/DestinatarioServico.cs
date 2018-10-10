using AutoMapper;
using Projeto_NFe.Application.Funcionalidades.Destinatarios.Comandos;
using Projeto_NFe.Domain.Excecoes;
using Projeto_NFe.Domain.Funcionalidades.Destinatarios;
using Projeto_NFe.Domain.Funcionalidades.Enderecos;
using System.Linq;

namespace Projeto_NFe.Application.Funcionalidades.Destinatarios
{
    public class DestinatarioServico : IDestinatarioServico
    {
        IDestinatarioRepositorio _repositorioDestinatario;
        IEnderecoRepositorio _repositorioEndereco;

        public DestinatarioServico(IDestinatarioRepositorio repositorio, IEnderecoRepositorio repositorioEndereco)
        {
            _repositorioDestinatario = repositorio;
            _repositorioEndereco = repositorioEndereco;
        }

        public long Adicionar(DestinatarioAdicionarComando comando)
        {
            Destinatario destinatario = Mapper.Map<DestinatarioAdicionarComando, Destinatario>(comando);

            return _repositorioDestinatario.Adicionar(destinatario);
        }

        public bool Atualizar(DestinatarioEditarComando comando)
        {
            Destinatario destinatarioDb = _repositorioDestinatario.BuscarPorId(comando.Id) ?? throw new ExcecaoNaoEncontrado();
            Endereco enderecoDb = _repositorioEndereco.BuscarPorId(comando.Endereco.Id);

            Mapper.Map<DestinatarioEditarComando, Destinatario>(comando, destinatarioDb);
            Mapper.Map(comando.Endereco, enderecoDb);

            destinatarioDb.Endereco = enderecoDb;

            return _repositorioDestinatario.Atualizar(destinatarioDb);
        }

        public Destinatario BuscarPorId(long id)
        {
            return _repositorioDestinatario.BuscarPorId(id) ?? throw new ExcecaoNaoEncontrado();
        }

        public IQueryable<Destinatario> BuscarTodos()
        {
            return _repositorioDestinatario.BuscarTodos();
        }

        public bool Excluir(DestinatarioRemoverComando comando)
        {
            Destinatario destinatario = _repositorioDestinatario.BuscarPorId(comando.Id) ?? throw new ExcecaoNaoEncontrado();

            _repositorioDestinatario.Excluir(destinatario);

            return _repositorioDestinatario.BuscarPorId(destinatario.Id) == null ? true : false;
        }
    }
}

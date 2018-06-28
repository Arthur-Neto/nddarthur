using System.Collections.Generic;
using TutorialORM.Aplicacao.Base;
using TutorialORM.Dominio.Base;
using TutorialORM.Dominio.Exceptions;
using TutorialORM.Dominio.Features.Enderecos;

namespace TutorialORM.Aplicacao.Features.Enderecos
{
    public class EnderecoServico : IServico<Endereco>
    {
        public IEnderecoRepositorio _repositorio;

        public EnderecoServico(IEnderecoRepositorio repositorio)
        {
            _repositorio = repositorio;
        }

        public Endereco Atualizar(Endereco endereco)
        {
            if (endereco.Id < 1)
                throw new IdentificadorInvalidoException();

            endereco.Validar();

            return _repositorio.Atualizar(endereco);
        }

        public void Deletar(Endereco endereco)
        {
            if (endereco.Id < 1)
                throw new IdentificadorInvalidoException();
            
            _repositorio.VerificaDependencia(endereco);
            _repositorio.Deletar(endereco);
        }

        public Endereco PegarPorId(long id)
        {
            if (id < 1)
                throw new IdentificadorInvalidoException();

            return _repositorio.PegarPorId(id);
        }

        public IEnumerable<Endereco> PegarTodos()
        {
            return _repositorio.PegarTodos();
        }

        public Endereco Salvar(Endereco endereco)
        {
            endereco.Validar();

            return _repositorio.Salvar(endereco);
        }
    }
}

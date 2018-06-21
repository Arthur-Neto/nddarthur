using System.Collections.Generic;
using TutorialORM.Aplicacao.Base;
using TutorialORM.Dominio.Base;
using TutorialORM.Dominio.Exceptions;
using TutorialORM.Dominio.Features.Enderecos;

namespace TutorialORM.Aplicacao.Features.Enderecos
{
    public class EnderecoServico : IServico<Endereco>
    {
        public IRepositorio<Endereco> Repositorio { get; set; }

        public EnderecoServico(IEnderecoRepositorio repositorio)
        {
            Repositorio = repositorio;
        }

        public Endereco Atualizar(Endereco endereco)
        {
            if (endereco.Id < 1)
                throw new IdentificadorInvalidoException();

            endereco.Validar();

            return Repositorio.Atualizar(endereco);
        }

        public void Deletar(Endereco endereco)
        {
            if (endereco.Id < 1)
                throw new IdentificadorInvalidoException();

            Repositorio.Deletar(endereco);
        }

        public Endereco PegarPorId(long id)
        {
            if (id < 1)
                throw new IdentificadorInvalidoException();

            return Repositorio.PegarPorId(id);
        }

        public IEnumerable<Endereco> PegarTodos()
        {
            return Repositorio.PegarTodos();
        }

        public Endereco Salvar(Endereco endereco)
        {
            endereco.Validar();

            return Repositorio.Salvar(endereco);
        }
    }
}

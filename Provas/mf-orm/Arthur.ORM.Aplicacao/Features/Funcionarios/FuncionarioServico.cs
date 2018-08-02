using Arthur.ORM.Dominio.Features.Funcionarios;
using System.Collections.Generic;

namespace Arthur.ORM.Aplicacao.Features.Funcionarios
{
    public class FuncionarioServico : IFuncionarioServico
    {
        private IFuncionarioRepositorio _funcionarioRepositorio;

        public FuncionarioServico(IFuncionarioRepositorio funcionarioRepositorio)
        {
            _funcionarioRepositorio = funcionarioRepositorio;
        }

        public Funcionario Adicionar(Funcionario entidade)
        {
            return _funcionarioRepositorio.Salvar(entidade);
        }

        public Funcionario Atualizar(Funcionario entidade)
        {
            return _funcionarioRepositorio.Atualizar(entidade);
        }

        public Funcionario BuscarPorNome(string nome)
        {
            return _funcionarioRepositorio.BuscarPorNome(nome);
        }

        public void Excluir(Funcionario entidade)
        {
            _funcionarioRepositorio.Deletar(entidade);
        }

        public Funcionario ObterPorId(long id)
        {
            return _funcionarioRepositorio.ObterPorId(id);
        }

        public IEnumerable<Funcionario> ObterTodos()
        {
            return _funcionarioRepositorio.ObterTodos();
        }
    }
}

using Arthur.ORM.Aplicacao.Base;
using Arthur.ORM.Dominio.Features.Funcionarios;

namespace Arthur.ORM.Aplicacao.Features.Funcionarios
{
    public interface IFuncionarioServico : IServico<Funcionario>
    {
        Funcionario BuscarPorNome(string nome);
    }
}

using Arthur.ORM.Dominio.Base;

namespace Arthur.ORM.Dominio.Features.Funcionarios
{
    public interface IFuncionarioRepositorio : IRepositorio<Funcionario>
    {
        Funcionario BuscarPorNome(string nome);
    }
}

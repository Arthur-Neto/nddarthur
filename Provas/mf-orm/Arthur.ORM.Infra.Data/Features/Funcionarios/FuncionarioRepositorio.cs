using Arthur.ORM.Dominio.Features.Funcionarios;
using Arthur.ORM.Infra.Data.Base;
using System.Linq;

namespace Arthur.ORM.Infra.Data.Features.Funcionarios
{
    public class FuncionarioRepositorio : RepositorioGenerico<Funcionario>, IFuncionarioRepositorio
    {
        public FuncionarioRepositorio(EmpresaContexto context) : base(context)
        {
        }

        public Funcionario BuscarPorNome(string nome)
        {
            return _contexto.Funcionarios.Where(f => f.Nome == nome).FirstOrDefault();
        }
    }
}

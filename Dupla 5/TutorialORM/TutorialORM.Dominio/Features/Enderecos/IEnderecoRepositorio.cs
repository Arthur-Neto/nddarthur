using TutorialORM.Dominio.Base;

namespace TutorialORM.Dominio.Features.Enderecos
{
    public interface IEnderecoRepositorio : IRepositorio<Endereco>
    {
        void VerificaDependencia(Endereco endereco);
    }
}

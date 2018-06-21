using TutorialORM.Dominio.Exceptions;

namespace TutorialORM.Dominio.Features.Enderecos
{
    public class EnderecoNumeroInvalidoException : BusinessException
    {
        public EnderecoNumeroInvalidoException() : base("Endereço deve ter um número válido")
        {
        }
    }
}
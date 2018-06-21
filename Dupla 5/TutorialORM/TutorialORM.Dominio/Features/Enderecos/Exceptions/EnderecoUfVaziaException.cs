using TutorialORM.Dominio.Exceptions;

namespace TutorialORM.Dominio.Features.Enderecos
{
    public class EnderecoUfVaziaException : BusinessException
    {
        public EnderecoUfVaziaException() : base("Endereço deve ter um estado")
        {
        }
    }
}
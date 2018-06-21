using TutorialORM.Dominio.Exceptions;

namespace TutorialORM.Dominio.Features.Enderecos
{
    public class EnderecoCidadeVaziaException : BusinessException
    {
        public EnderecoCidadeVaziaException() : base("Endereço deve ter uma cidade")
        {
        }
    }
}
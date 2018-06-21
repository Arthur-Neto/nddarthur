using TutorialORM.Dominio.Exceptions;

namespace TutorialORM.Dominio.Features.Enderecos
{
    public class EnderecoBairroVazioException : BusinessException
    {
        public EnderecoBairroVazioException() : base("Endereço não pode ter um bairro vazio")
        {
        }
    }
}
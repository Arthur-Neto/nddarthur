using TutorialORM.Dominio.Exceptions;

namespace TutorialORM.Infra.Data.Features.Enderecos
{
    public class EnderecoReferenciadoException : BusinessException
    {
        public EnderecoReferenciadoException() : base("Endereço está sendo referenciado por um aluno")
        {
        }
    }
}
using TutorialORM.Dominio.Exceptions;

namespace TutorialORM.Dominio.Features.Enderecos
{
    public class EnderecoLogradouroVazioException : BusinessException
    {
        public EnderecoLogradouroVazioException() : base("Endereçco não pode conter um logradouro vazio")
        {
        }
    }
}
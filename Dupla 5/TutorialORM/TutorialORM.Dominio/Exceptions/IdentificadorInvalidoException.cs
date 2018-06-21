namespace TutorialORM.Dominio.Exceptions
{
    public class IdentificadorInvalidoException : BusinessException
    {
        public IdentificadorInvalidoException() : base("Identificador inválido!")
        {
        }
    }
}

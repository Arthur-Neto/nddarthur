namespace Prova1.Domain.Exceptions
{
    /// <summary>
    /// Representa uma exceção de negócio: durante uma operação, 
    /// aos dados informados são inválidos
    /// </summary>
    public class InvalidObjectException : BusinessException
    {
        public InvalidObjectException() : base(ErrorCodes.InvalidObject, "This object is invalid") { }
    }
}

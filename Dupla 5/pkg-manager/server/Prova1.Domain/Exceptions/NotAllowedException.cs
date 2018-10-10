namespace Prova1.Domain.Exceptions
{
    /// <summary>
    /// Representa uma exceção de negócio: durante uma operação, 
    /// o usuário não tinha permissão para realizá-la.
    /// </summary>
    public class NotAllowedException : BusinessException
    {
        public NotAllowedException() : base(ErrorCodes.NotAllowed, "Operation not allowed") { }
    }
}

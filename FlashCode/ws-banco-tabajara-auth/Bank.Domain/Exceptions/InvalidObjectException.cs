namespace Bank.Domain.Exceptions
{
    public class InvalidObjectException : BusinessException
    {
        public InvalidObjectException() : base(ErrorCodes.InvalidObject, "This object is invalid") { }
    }
}

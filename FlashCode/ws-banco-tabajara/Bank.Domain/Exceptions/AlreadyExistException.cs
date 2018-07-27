namespace Bank.Domain.Exceptions
{
    public class AlreadyExistsException : BusinessException
    {
        public AlreadyExistsException() : base(ErrorCodes.AlreadyExists, "This registry already exists") { }
    }
}

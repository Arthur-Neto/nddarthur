using Bank.Domain.Exceptions;

namespace Bank.Domain.Features.Accounts.Exceptions
{
    public class AccountInactiveException : BusinessException
    {
        public AccountInactiveException() : base(ErrorCodes.NotAllowed, "Conta inativa")
        {
        }
    }
}

using Bank.Domain.Exceptions;

namespace Bank.Domain.Features.Accounts.Exceptions
{
    public class ShortBalanceException : BusinessException
    {
        public ShortBalanceException() : base(ErrorCodes.NotAllowed, "Saldo Insuficiente")
        {
        }
    }
}

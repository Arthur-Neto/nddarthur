namespace Bank.Application.Features.Accounts
{
    public class AccountTransactionModel
    {
        public long AccountOriginId { get; set; }
        public long AccountDestinationId { get; set; }
        public decimal Value { get; set; }
    }
}

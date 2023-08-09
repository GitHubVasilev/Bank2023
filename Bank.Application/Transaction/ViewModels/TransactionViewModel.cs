namespace Bank.Application.Transaction.ViewModels
{
    public record TransactionViewModel
    {
        public Guid AccountFrom { get; init; }
        public Guid AccountTo { get; init; }
        public decimal Sum { get; init; } 
    }
}

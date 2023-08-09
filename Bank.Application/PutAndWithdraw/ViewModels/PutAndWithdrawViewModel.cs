namespace Bank.Application.PutAndWithdraw.ViewModels
{
    public record class PutAndWithdrawViewModel
    {
        public Guid AccountId { get; init; }
        public decimal Sum { get; init; }
    }
}

namespace Bank.Application.Accounts.Services.ServiceModels
{
    public class PutAndWithdrawServiceModel
    {
        public string? TypeAccount { get; set; }
        public decimal StartSum { get; set; }
        public decimal SumPutOrWithdraw { get; set; }
        public int Procent { get; set; }
    }
}

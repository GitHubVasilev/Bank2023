namespace Bank.Application.Accounts.Services.ServiceModels
{
    public class PutAndWithdrawServiceModel
    {
        public string? TypeAccount { get; set; }
        public decimal StartSum { get; set; }
        public int Procent { get; set; }

        public static PutAndWithdrawServiceModel Build(string typeAccount, decimal startSum, int percent) 
        {
            return new PutAndWithdrawServiceModel { TypeAccount = typeAccount, StartSum = startSum, Procent = percent };
        }
    }
}

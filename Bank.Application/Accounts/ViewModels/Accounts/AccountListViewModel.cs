namespace Bank.Application.Accounts.ViewModels.Accounts
{
    public class AccountListViewModel
    {
        public IList<AccountLookupDTO> Accounts { get; set; } = new List<AccountLookupDTO>();
    }
}

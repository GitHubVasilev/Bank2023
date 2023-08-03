using MediatR;

namespace Bank.Application.Accounts.Queries.GetAccountDetales
{
    public class GetAccountDetailsQuery : IRequest<AccountDetailsViewModel>
    {
        public Guid UID { get; set; }
    }
}

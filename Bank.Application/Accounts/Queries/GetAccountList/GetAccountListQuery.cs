using MediatR;

namespace Bank.Application.Accounts.Queries.GetAccountList
{
    public class GetAccountListQuery : IRequest<AccountListViewModel>
    {
        public Guid ClientId { get; set; }
    }
}

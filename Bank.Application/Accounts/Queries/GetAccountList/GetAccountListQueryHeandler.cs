using AutoMapper;
using AutoMapper.QueryableExtensions;
using Bank.Application.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Bank.Application.Accounts.Queries.GetAccountList
{
    public class GetAccountListQueryHeandler
        : IRequestHandler<GetAccountListQuery, AccountListViewModel>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;

        public GetAccountListQueryHeandler(IApplicationDbContext dbContext,
            IMapper mapper)
        {
            _context = dbContext;
            _mapper = mapper;
        }

        public async Task<AccountListViewModel> Handle(GetAccountListQuery request, CancellationToken cancellationToken)
        {
            List<AccountLookupDTO>  list = await _context.Accounts
                .Where(m => m.ClientId == request.ClientId)
                .ProjectTo<AccountLookupDTO>(_mapper.ConfigurationProvider)
                .ToListAsync(cancellationToken);
            return new AccountListViewModel() { DepositeAccounts = list };
        }
    }
}

using AutoMapper;
using AutoMapper.QueryableExtensions;
using Bank.Application.Accounts.ViewModels.NoDepositeAccounts;
using Bank.Application.Common;
using Bank.Application.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Bank.Application.Accounts.Queries.GetAccountList
{
    public record GetNoDepositeAccountListQuery(Guid ClientId) : IRequest<WrapperResult<IEnumerable<NoDepositeAccountViewModel>>>;

    public class GetNoDepositeAccountListQueryHeandler
        : IRequestHandler<GetNoDepositeAccountListQuery, WrapperResult<IEnumerable<NoDepositeAccountViewModel>>>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;

        public GetNoDepositeAccountListQueryHeandler(IApplicationDbContext dbContext,
            IMapper mapper)
        {
            _context = dbContext;
            _mapper = mapper;
        }

        public async Task<WrapperResult<IEnumerable<NoDepositeAccountViewModel>>> Handle(GetNoDepositeAccountListQuery request, CancellationToken cancellationToken)
        {
            WrapperResult<IEnumerable<NoDepositeAccountViewModel>> wrapperResult = WrapperResult.Build<IEnumerable<NoDepositeAccountViewModel>>();
            List<NoDepositeAccountViewModel> list = await _context.Accounts
                .Where(m => m.ClientId == request.ClientId)
                .ProjectTo<NoDepositeAccountViewModel>(_mapper.ConfigurationProvider)
                .ToListAsync(cancellationToken);
            wrapperResult.Result = list;
            return wrapperResult;
        }
    }
}

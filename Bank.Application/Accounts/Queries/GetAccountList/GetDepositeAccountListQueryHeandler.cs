using AutoMapper;
using AutoMapper.QueryableExtensions;
using Bank.Application.Accounts.ViewModels.DepositeAccounts;
using Bank.Application.Common;
using Bank.Application.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Bank.Application.Accounts.Queries.GetAccountList
{
    public record GetDepositeAccountListQuery(Guid ClientId) : IRequest<WrapperResult<IEnumerable<DepositeAccountViewModel>>>;

    public class GetDepositeAccountListQueryHeandler
        : IRequestHandler<GetDepositeAccountListQuery, WrapperResult<IEnumerable<DepositeAccountViewModel>>>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;

        public GetDepositeAccountListQueryHeandler(IApplicationDbContext dbContext,
            IMapper mapper)
        {
            _context = dbContext;
            _mapper = mapper;
        }

        public async Task<WrapperResult<IEnumerable<DepositeAccountViewModel>>> Handle(GetDepositeAccountListQuery request, CancellationToken cancellationToken)
        {
            WrapperResult<IEnumerable<DepositeAccountViewModel>> wrapperResult = WrapperResult.Build<IEnumerable<DepositeAccountViewModel>>();
            List<DepositeAccountViewModel> list = await _context.Accounts
                .Where(m => m.ClientId == request.ClientId)
                .ProjectTo<DepositeAccountViewModel>(_mapper.ConfigurationProvider)
                .ToListAsync(cancellationToken);
            wrapperResult.Result = list;
            return wrapperResult;
        }
    }
}

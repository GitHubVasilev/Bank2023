using AutoMapper;
using AutoMapper.QueryableExtensions;
using Bank.Application.Accounts.ViewModels.Accounts;
using Bank.Application.Common;
using Bank.Application.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Bank.Application.Accounts.Queries.GetAccountList
{
    public record GetAccountListQuery(Guid ClientId) : IRequest<WrapperResult<IEnumerable<AccountDetailsViewModel>>>;

    public class GetAccountListQueryHeandler
        : IRequestHandler<GetAccountListQuery, WrapperResult<IEnumerable<AccountDetailsViewModel>>>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;

        public GetAccountListQueryHeandler(IApplicationDbContext dbContext,
            IMapper mapper)
        {
            _context = dbContext;
            _mapper = mapper;
        }

        public async Task<WrapperResult<IEnumerable<AccountDetailsViewModel>>> Handle(GetAccountListQuery request, CancellationToken cancellationToken)
        {
            WrapperResult<IEnumerable<AccountDetailsViewModel>> wrapperResult = WrapperResult.Build<IEnumerable<AccountDetailsViewModel>>();
            List<AccountDetailsViewModel> list = await _context.Accounts
                .Where(m => m.ClientId == request.ClientId)
                .ProjectTo<AccountDetailsViewModel>(_mapper.ConfigurationProvider)
                .ToListAsync(cancellationToken);
            wrapperResult.Result = list;
            return wrapperResult;
        }
    }
}

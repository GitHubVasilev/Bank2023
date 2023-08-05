using AutoMapper;
using AutoMapper.QueryableExtensions;
using Bank.Application.Common;
using Bank.Application.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Bank.Application.Accounts.Queries.GetAccountList
{
    public record GetAccountListQuery<T>(Guid ClientId) : IRequest<WrapperResult<IEnumerable<T>>>;

    public class GetAccountListQueryHeandler<T>
        : IRequestHandler<GetAccountListQuery<T>, WrapperResult<IEnumerable<T>>>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;

        public GetAccountListQueryHeandler(IApplicationDbContext dbContext,
            IMapper mapper)
        {
            _context = dbContext;
            _mapper = mapper;
        }

        public async Task<WrapperResult<IEnumerable<T>>> Handle(GetAccountListQuery<T> request, CancellationToken cancellationToken)
        {
            WrapperResult<IEnumerable<T>> wrapperResult = WrapperResult.Build<IEnumerable<T>>();
            List<T> list = await _context.Accounts
                .Where(m => m.ClientId == request.ClientId)
                .ProjectTo<T>(_mapper.ConfigurationProvider)
                .ToListAsync(cancellationToken);
            wrapperResult.Result = list;
            return wrapperResult;
        }
    }
}

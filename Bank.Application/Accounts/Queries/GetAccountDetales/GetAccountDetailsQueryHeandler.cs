using AutoMapper;
using Bank.Application.Common.Exceptions;
using Bank.Application.Interfaces;
using Bank.Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Bank.Application.Accounts.Queries.GetAccountDetales
{
    public class GetAccountDetailsQueryHeandler : IRequestHandler<GetAccountDetailsQuery, AccountDetailsViewModel>
    {
        private readonly IMapper _mapper;
        private readonly IApplicationDbContext _context;

        public GetAccountDetailsQueryHeandler(IApplicationDbContext dbContext,
            IMapper mapper)
        {
            _context = dbContext;
            _mapper = mapper;
        }

        public async Task<AccountDetailsViewModel> Handle(GetAccountDetailsQuery request, CancellationToken cancellationToken)
        {
            Account? model = await _context.Accounts.FirstOrDefaultAsync(m => m.UID == request.UID, cancellationToken);

            if (model == null)
            {
                throw new NotFoundException(nameof(Account), request.UID);
            }

            return _mapper.Map<AccountDetailsViewModel>(model);
        }
    }
}

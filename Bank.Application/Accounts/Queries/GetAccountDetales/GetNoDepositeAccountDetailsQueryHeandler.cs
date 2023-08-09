using AutoMapper;
using Bank.Application.Common.Exceptions;
using Bank.Application.Common;
using Bank.Application.Interfaces;
using Bank.Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Bank.Application.Accounts.ViewModels.NoDepositeAccounts;

namespace Bank.Application.Accounts.Queries.GetAccountDetales
{
    public record GetNoDepositeAccountDetailsQuery(Guid UID) : IRequest<WrapperResult<NoDepositeAccountViewModel>>;

    public class GetNoDepositeAccountDetailsQueryHeandler : IRequestHandler<GetNoDepositeAccountDetailsQuery, WrapperResult<NoDepositeAccountViewModel>>
    {
        private readonly IMapper _mapper;
        private readonly IApplicationDbContext _context;

        public GetNoDepositeAccountDetailsQueryHeandler(IApplicationDbContext dbContext,
            IMapper mapper)
        {
            _context = dbContext;
            _mapper = mapper;
        }

        public async Task<WrapperResult<NoDepositeAccountViewModel>> Handle(GetNoDepositeAccountDetailsQuery request, CancellationToken cancellationToken)
        {
            WrapperResult<NoDepositeAccountViewModel> wrapperResult = WrapperResult.Build<NoDepositeAccountViewModel>();
            Account? model = await _context.Accounts.FirstOrDefaultAsync(m => m.UID == request.UID, cancellationToken);

            if (model == null)
            {
                wrapperResult.ExceptionObject = new NotFoundException(nameof(Account), request.UID);
                wrapperResult.Message = ReferencesTextResponse.AccountNotFound;
                return wrapperResult;
            }

            wrapperResult.Result = _mapper.Map<NoDepositeAccountViewModel>(model);
            return wrapperResult;
        }
    }
}

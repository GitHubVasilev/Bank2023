using AutoMapper;
using Bank.Application.Accounts.ViewModels.Accounts;
using Bank.Application.Common.Exceptions;
using Bank.Application.Common;
using Bank.Application.Interfaces;
using Bank.Domain;
using MediatR;
using Bank.Application.Accounts.ViewModels.DepositeAccounts;
using Microsoft.EntityFrameworkCore;

namespace Bank.Application.Accounts.Queries.GetAccountDetales
{
    public record GetDepositeAccountDetailsQuery(Guid UID) : IRequest<WrapperResult<DepositeAccountViewModel>>;

    public class GetDepositeAccountDetailsQueryHeandler : IRequestHandler<GetDepositeAccountDetailsQuery, WrapperResult<DepositeAccountViewModel>>
    {
        private readonly IMapper _mapper;
        private readonly IApplicationDbContext _context;

        public GetDepositeAccountDetailsQueryHeandler(IApplicationDbContext dbContext,
            IMapper mapper)
        {
            _context = dbContext;
            _mapper = mapper;
        }

        public async Task<WrapperResult<DepositeAccountViewModel>> Handle(GetDepositeAccountDetailsQuery request, CancellationToken cancellationToken)
        {
            WrapperResult<DepositeAccountViewModel> wrapperResult = WrapperResult.Build<DepositeAccountViewModel>();
            Account? model = await _context.Accounts.FirstOrDefaultAsync(m => m.UID == request.UID, cancellationToken);

            if (model == null)
            {
                wrapperResult.ExceptionObject = new NotFoundException(nameof(Account), request.UID);
                wrapperResult.Message = ReferencesTextResponse.AccountNotFound;
                return wrapperResult;
            }

            wrapperResult.Result = _mapper.Map<DepositeAccountViewModel>(model);
            return wrapperResult;
        }
    }
}

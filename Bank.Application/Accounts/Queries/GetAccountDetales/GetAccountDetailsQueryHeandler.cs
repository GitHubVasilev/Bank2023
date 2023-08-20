using AutoMapper;
using Bank.Application.Accounts.ViewModels.Accounts;
using Bank.Application.Common;
using Bank.Application.Common.AppConfig;
using Bank.Application.Common.Exceptions;
using Bank.Application.Interfaces;
using Bank.Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Bank.Application.Accounts.Queries.GetAccountDetales
{
    public record GetAccountDetailsQuery(Guid UID) : IRequest<WrapperResult<AccountDetailsViewModel>>;

    public class GetAccountDetailsQueryHeandler : IRequestHandler<GetAccountDetailsQuery, WrapperResult<AccountDetailsViewModel>>
    {
        private readonly IMapper _mapper;
        private readonly IApplicationDbContext _context;

        public GetAccountDetailsQueryHeandler(IApplicationDbContext dbContext,
            IMapper mapper)
        {
            _context = dbContext;
            _mapper = mapper;
        }

        public async Task<WrapperResult<AccountDetailsViewModel>> Handle(GetAccountDetailsQuery request, CancellationToken cancellationToken)
        {
            WrapperResult<AccountDetailsViewModel> wrapperResult = WrapperResult.Build<AccountDetailsViewModel>();
            Account? model = await _context.Accounts.FirstOrDefaultAsync(m => m.UID == request.UID, cancellationToken);

            if (model == null)
            {
                wrapperResult.ExceptionObjects.Add( new NotFoundException(nameof(Account), request.UID));
                wrapperResult.Message = ReferencesTextResponse.AccountNotFound;
                return wrapperResult;
            }

            wrapperResult.Result = _mapper.Map<AccountDetailsViewModel>(model);
            return wrapperResult;
        }
    }
}

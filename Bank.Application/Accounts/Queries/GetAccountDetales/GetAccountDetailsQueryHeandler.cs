using AutoMapper;
using Bank.Application.Accounts.ViewModels.Accounts;
using Bank.Application.Common;
using Bank.Application.Common.Exceptions;
using Bank.Application.Interfaces;
using Bank.Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Bank.Application.Accounts.Queries.GetAccountDetales
{
    public record GetAccountDetailsQuery<T>(Guid UID) : IRequest<WrapperResult<T>>;

    public class GetAccountDetailsQueryHeandler<T> : IRequestHandler<GetAccountDetailsQuery<T>, WrapperResult<T>>
    {
        private readonly IMapper _mapper;
        private readonly IApplicationDbContext _context;

        public GetAccountDetailsQueryHeandler(IApplicationDbContext dbContext,
            IMapper mapper)
        {
            _context = dbContext;
            _mapper = mapper;
        }

        public async Task<WrapperResult<T>> Handle(GetAccountDetailsQuery<T> request, CancellationToken cancellationToken)
        {
            WrapperResult<T> wrapperResult = WrapperResult.Build<T>();
            Account? model = await _context.Accounts.FirstOrDefaultAsync(m => m.UID == request.UID, cancellationToken);

            if (model == null)
            {
                wrapperResult.ExceptionObject = new NotFoundException(nameof(Account), request.UID);
                wrapperResult.Message = ReferencesTextResponse.AccountNotFound;
                return wrapperResult;
            }

            wrapperResult.Result = _mapper.Map<T>(model);
            return wrapperResult;
        }
    }
}

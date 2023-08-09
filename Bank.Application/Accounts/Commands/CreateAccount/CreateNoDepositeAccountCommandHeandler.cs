using AutoMapper;
using Bank.Application.Accounts.ViewModels.NoDepositeAccounts;
using Bank.Application.Common;
using Bank.Application.Interfaces;
using Bank.Domain;
using MediatR;

namespace Bank.Application.Accounts.Commands.CreateAccount
{
    public record CreateNoDepositeAccountCommand(NoDepositeAccountPostViewModel viewModel) : IRequest<WrapperResult>;

    public class CreateNoDepositeAccountCommandHeandler : IRequestHandler<CreateNoDepositeAccountCommand, WrapperResult>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;

        public CreateNoDepositeAccountCommandHeandler(IApplicationDbContext dbContext, IMapper mapper)
        {
            _context = dbContext;
            _mapper = mapper;
        }

        public async Task<WrapperResult> Handle(CreateNoDepositeAccountCommand request, CancellationToken cancellationToken)
        {
            Account model = _mapper.Map<NoDepositeAccountPostViewModel, Account>(request.viewModel);
            await _context.Accounts.AddAsync(model, cancellationToken);
            await _context.SaveChangesAsync(cancellationToken);
            return WrapperResult.Build(0);
        }
    }
}

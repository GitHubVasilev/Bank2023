using AutoMapper;
using Bank.Application.Accounts.ViewModels.DepositeAccounts;
using Bank.Application.Common;
using Bank.Application.Interfaces;
using Bank.Domain;
using MediatR;

namespace Bank.Application.Accounts.Commands.CreateAccount
{
    public record CreateDepositeAccountCommand(DepositeAccountPostViewModel ViewModel) : IRequest<WrapperResult>;

    public class CreateDepositeAccountCommandHeandler : IRequestHandler<CreateDepositeAccountCommand, WrapperResult>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;

        public CreateDepositeAccountCommandHeandler(IApplicationDbContext dbContext, IMapper mapper)
        {
            _context = dbContext;
            _mapper = mapper;
        }

        public async Task<WrapperResult> Handle(CreateDepositeAccountCommand request, CancellationToken cancellationToken)
        {
            Account model = _mapper.Map<DepositeAccountPostViewModel, Account>(request.ViewModel);
            await _context.Accounts.AddAsync(model, cancellationToken);
            await _context.SaveChangesAsync(cancellationToken);
            return WrapperResult.Build(0);
        }
    }
}

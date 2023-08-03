using AutoMapper;
using Bank.Application.Interfaces;
using Bank.Application.TypesAccount.ViewModels;
using MediatR;

namespace Bank.Application.TypesAccount.Queries.TypeAccountList
{
    public record TypeAccountListQuery() : IRequest<IEnumerable<TypeAccountGetViewModel>>;

    public class TypeAccountListHeandler : IRequestHandler<TypeAccountListQuery, IEnumerable<TypeAccountGetViewModel>>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;

        public TypeAccountListHeandler(IApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<IEnumerable<TypeAccountGetViewModel>> Handle(TypeAccountListQuery request, CancellationToken cancellationToken)
        {
            await Task.Delay(0, cancellationToken);
            return _mapper.Map<IEnumerable<TypeAccountGetViewModel>>(_context.TypesAccount);
        }
    }
}

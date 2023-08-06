using AutoMapper;
using Bank.Application.Common;
using Bank.Application.Interfaces;
using Bank.Application.TypesAccount.ViewModels;
using MediatR;
using System.Collections.Generic;

namespace Bank.Application.TypesAccount.Queries.TypeAccountList
{
    public record TypeAccountListQuery() : IRequest<WrapperResult<IEnumerable<TypeAccountGetViewModel>>>;

    public class TypeAccountListHeandler : IRequestHandler<TypeAccountListQuery, WrapperResult<IEnumerable<TypeAccountGetViewModel>>>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;

        public TypeAccountListHeandler(IApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<WrapperResult<IEnumerable<TypeAccountGetViewModel>>> Handle(TypeAccountListQuery request, CancellationToken cancellationToken)
        {
            WrapperResult<IEnumerable<TypeAccountGetViewModel>> wrapperResult = WrapperResult.Build<IEnumerable<TypeAccountGetViewModel>>();
            await Task.Delay(0, cancellationToken);
            wrapperResult.Result = _mapper.Map<IEnumerable<TypeAccountGetViewModel>>(_context.TypesAccount);
            return wrapperResult;
        }
    }
}

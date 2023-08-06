using AutoMapper;
using Bank.Application.Common;
using Bank.Application.Common.Exceptions;
using Bank.Application.Interfaces;
using Bank.Application.TypesAccount.ViewModels;
using Bank.Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Bank.Application.TypesAccount.Queries.TypeAccountDetail
{
    public record TypeAccontDetailQuery(Guid Id) : IRequest<WrapperResult<TypeAccountGetViewModel>>;

    public class TypeAccountDetailHeandler : IRequestHandler<TypeAccontDetailQuery, WrapperResult<TypeAccountGetViewModel>>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;

        public TypeAccountDetailHeandler(IApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<WrapperResult<TypeAccountGetViewModel>> Handle(TypeAccontDetailQuery request, CancellationToken cancellationToken)
        {
            WrapperResult<TypeAccountGetViewModel> wrapperResult = WrapperResult.Build<TypeAccountGetViewModel>();
            TypeAccount? model = await _context.TypesAccount.FirstOrDefaultAsync(m => m.UID == request.Id, cancellationToken);
            if (model == null) 
            {
                wrapperResult.ExceptionObject = new NotFoundException(nameof(TypeAccount), request.Id);
                wrapperResult.Message = ReferencesTextResponse.TypeAccountNotFound;
            }
            wrapperResult.Result = _mapper.Map<TypeAccountGetViewModel>(model);
            return wrapperResult;
        }
    }
}

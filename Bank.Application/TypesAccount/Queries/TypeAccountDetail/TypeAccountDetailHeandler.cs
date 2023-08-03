using AutoMapper;
using Bank.Application.Common.Exceptions;
using Bank.Application.Interfaces;
using Bank.Application.TypesAccount.ViewModels;
using Bank.Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Bank.Application.TypesAccount.Queries.TypeAccountDetail
{
    public record TypeAccontDetailQuery(Guid Id) : IRequest<TypeAccountGetViewModel>;

    public class TypeAccountDetailHeandler : IRequestHandler<TypeAccontDetailQuery, TypeAccountGetViewModel>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;

        public TypeAccountDetailHeandler(IApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<TypeAccountGetViewModel> Handle(TypeAccontDetailQuery request, CancellationToken cancellationToken)
        {
            return _mapper.Map<TypeAccountGetViewModel>(
                await _context.TypesAccount.FirstOrDefaultAsync(m => m.UID == request.Id)
                    ?? throw new NotFoundException(nameof(TypeAccount), request.Id));
        }
    }
}

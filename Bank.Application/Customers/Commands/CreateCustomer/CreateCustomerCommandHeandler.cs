using AutoMapper;
using Bank.Application.Common;
using Bank.Application.Common.Exceptions;
using Bank.Application.Customers.ViewModels;
using Bank.Application.Interfaces;
using Bank.Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace Bank.Application.Customers.Commands.CreateCustomer
{
    public record CreateCustomerCommand(CustomerPostCreateViewModel ViewModel, ClaimsPrincipal User) : IRequest<WrapperResult<int>>;

    public class CreateCustomerCommandHeandler : IRequestHandler<CreateCustomerCommand, WrapperResult<int>>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;

        public CreateCustomerCommandHeandler(IApplicationDbContext dbContext, IMapper mapper)
        {
            _context = dbContext;
            _mapper = mapper;
        }

        public async Task<WrapperResult<int>> Handle(CreateCustomerCommand request, CancellationToken cancellationToken)
        {
            if (await _context.Customers.AnyAsync(m => m.UID == request.ViewModel.Id, cancellationToken)) 
            {
                return WrapperResult.Build(1, ReferencesTextResponse.CustomerExists, new List<Exception>() { new ExistingEntityException(nameof(Customer), request.ViewModel.Id) });
            }
            Customer customer = _mapper
                .Map<Customer>(request.ViewModel, opt => opt.Items[nameof(ApplicationUser)] = request.User?.Identity?.Name);
            await _context.Customers.AddAsync(customer);
            await _context.SaveChangesAsync(cancellationToken);
            return WrapperResult.Build<int>();
        }
    }
}

using AutoMapper;
using Bank.Application.Common;
using Bank.Application.Common.Exceptions;
using Bank.Application.Customers.ViewModels;
using Bank.Application.Interfaces;
using Bank.Application.Interfaces.Customers;
using Bank.Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace Bank.Application.Customers.Queries.GetCustomerDetails
{
    public record GetCustomerDelailsQuery(Guid UID, ClaimsPrincipal User): IRequest<WrapperResult<CustomerGetViewModel>>;

    public class GetCustomerDelailsQueryHeandler : IRequestHandler<GetCustomerDelailsQuery, WrapperResult<CustomerGetViewModel>>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;
        private readonly ICustomerFactory<Customer, CustomerGetViewModel> _factory;

        public GetCustomerDelailsQueryHeandler(IApplicationDbContext dbContext,
            IMapper mapper,
            ICustomerFactory<Customer, CustomerGetViewModel> factory)
        {
            _context = dbContext;
            _mapper = mapper;
            _factory = factory;
        }

        public async Task<WrapperResult<CustomerGetViewModel>> Handle(GetCustomerDelailsQuery request, CancellationToken cancellationToken)
        {
            WrapperResult<CustomerGetViewModel> wrapperResult = WrapperResult.Build<CustomerGetViewModel>();
            Customer? model = await _context.Customers.FirstOrDefaultAsync(m => m.UID == request.UID);

            if (model is null) 
            {
                wrapperResult.ExceptionObjects.Add(new NotFoundException(nameof(Customer), request.UID));
                wrapperResult.Message = ReferencesTextResponse.CustometNotFound;
                return wrapperResult;
            }

            wrapperResult.Result = _factory.GetCustomerFromUser(model, request.User?.Identity?.Name ?? string.Empty);
            return  wrapperResult;
        }
    }
}

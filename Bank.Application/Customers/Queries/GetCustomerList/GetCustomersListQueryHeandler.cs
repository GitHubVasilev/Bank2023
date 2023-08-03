using AutoMapper;
using Bank.Application.Customers.ViewModels;
using Bank.Application.Interfaces;
using Bank.Application.Interfaces.Customers;
using Bank.Domain;
using MediatR;
using System.Security.Claims;

namespace Bank.Application.Customers.Queries.GetCustomerList
{
    public record GetCustomersQuery(ClaimsPrincipal User) : IRequest<IEnumerable<CustomerGetViewModel>>;

    public class GetCustomersListQueryHeandler : IRequestHandler<GetCustomersQuery, IEnumerable<CustomerGetViewModel>>
    {
        private readonly IMapper _mapper;
        private readonly IApplicationDbContext _context;
        private readonly ICustomerFactory<Customer, CustomerGetViewModel> _factory;

        public GetCustomersListQueryHeandler(IApplicationDbContext dbContext,
            IMapper mapper,
            ICustomerFactory<Customer, CustomerGetViewModel> factory)
        {
            _context = dbContext;
            _mapper = mapper;
            _factory = factory;
        }

        public async Task<IEnumerable<CustomerGetViewModel>> Handle(GetCustomersQuery request, CancellationToken cancellationToken)
        {
            await Task.Delay(0, cancellationToken);

            List<CustomerGetViewModel> result = new List<CustomerGetViewModel>();

            foreach (Customer customer in _context.Customers) 
            {
                result.Add(_factory.GetCustomerFromUser(customer, request.User.Identity!.Name));
            }

            return result;
        }
    }
}

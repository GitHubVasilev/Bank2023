using Bank.Application.Common.Exceptions;
using Bank.Application.Interfaces;
using Bank.Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Bank.Application.Customers.Commands.DeleteCustomer
{
    public record DeleteCustomerCommand(Guid Id) : IRequest;
    public class DeleteCustomerCommandHeandler : IRequestHandler<DeleteCustomerCommand>
    {
        private readonly IApplicationDbContext _context;

        public DeleteCustomerCommandHeandler(IApplicationDbContext dbContext)
        {
            _context = dbContext;
        }

        public async Task Handle(DeleteCustomerCommand request, CancellationToken cancellationToken)
        {
            Customer model = await _context.Customers.FirstOrDefaultAsync(m => m.UID == request.Id) 
                ?? throw new NotFoundException(nameof(Customer), request.Id);

            _context.Customers.Remove(model);
        }
    }
}

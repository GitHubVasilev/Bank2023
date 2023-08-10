using Bank.Application.Common;
using Bank.Application.Common.Exceptions;
using Bank.Application.Interfaces;
using Bank.Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Bank.Application.Customers.Commands.DeleteCustomer
{
    public record DeleteCustomerCommand(Guid Id) : IRequest<WrapperResult>;
    public class DeleteCustomerCommandHeandler : IRequestHandler<DeleteCustomerCommand, WrapperResult>
    {
        private readonly IApplicationDbContext _context;

        public DeleteCustomerCommandHeandler(IApplicationDbContext dbContext)
        {
            _context = dbContext;
        }

        public async Task<WrapperResult> Handle(DeleteCustomerCommand request, CancellationToken cancellationToken)
        {
            WrapperResult result = WrapperResult.Build<int>();
            Customer? model = await _context.Customers.FirstOrDefaultAsync(m => m.UID == request.Id);

            if (model is null) 
            {
                result.Message = ReferencesTextResponse.CustometNotFound;
                result.ExceptionObjects.Add(new NotFoundException(nameof(Customer), request.Id));
                return result;
            }

            _context.Customers.Remove(model);
            return result;
        }
    }
}

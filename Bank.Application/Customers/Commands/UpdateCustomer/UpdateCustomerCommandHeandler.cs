using AutoMapper;
using Bank.Application.Base;
using Bank.Application.Common.Exceptions;
using Bank.Application.Customers.ViewModels;
using Bank.Application.Interfaces;
using Bank.Domain;
using MediatR;
using System.Security.Claims;

namespace Bank.Application.Customers.Commands.UpdateCustomer
{
    public record UpdateCustomerCommand(CustomerPutUpdateViewModel ViewModel, ClaimsPrincipal User): IRequest;

    public class UpdateCustomerCommandHeandler : IRequestHandler<UpdateCustomerCommand>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;
        private readonly IValidator<CustomerPutUpdateViewModel> _validator;

        public UpdateCustomerCommandHeandler(IApplicationDbContext dbContext,
            IMapper mapper,
            IValidator<CustomerPutUpdateViewModel> validator)
        {
            _validator = validator;
            _context = dbContext;
            _mapper = mapper;
        }

        public async Task Handle(UpdateCustomerCommand request, CancellationToken cancellationToken)
        {
            Customer model = _context.Customers.FirstOrDefault(m => m.UID == request.ViewModel.Id) 
                ?? throw new NotFoundException(nameof(Customer), request.ViewModel.Id);

            ValidationResult<CustomerPutUpdateViewModel> validationResult = _validator.Validate(request.ViewModel, request.User);
            if (validationResult.IsValid) 
            {
                model.FirstName = request.ViewModel.FirstName;
                model.LastName = request.ViewModel.LastName;
                model.Patronymic = request.ViewModel.Patronymic;
                model.Telephone = request.ViewModel.Telephone;
                model.Passport = request.ViewModel.Passport;
            }

            await _context.SaveChangesAsync(cancellationToken);
        }
    }
}

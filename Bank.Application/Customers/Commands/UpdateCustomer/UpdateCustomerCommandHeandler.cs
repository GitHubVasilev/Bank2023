using AutoMapper;
using Bank.Application.Common;
using Bank.Application.Common.Exceptions;
using Bank.Application.Customers.ViewModels;
using Bank.Application.Interfaces;
using Bank.Domain;
using MediatR;
using System.Security.Claims;

namespace Bank.Application.Customers.Commands.UpdateCustomer
{
    public record UpdateCustomerCommand(CustomerPutUpdateViewModel ViewModel, ClaimsPrincipal User): IRequest<WrapperResult<int>>;

    public class UpdateCustomerCommandHeandler : IRequestHandler<UpdateCustomerCommand, WrapperResult<int>>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;

        public UpdateCustomerCommandHeandler(IApplicationDbContext dbContext, IMapper mapper)
        {
            _context = dbContext;
            _mapper = mapper;
        }

        public async Task<WrapperResult<int>> Handle(UpdateCustomerCommand request, CancellationToken cancellationToken)
        {
            WrapperResult<int> result = WrapperResult.Build<int>();
            Customer? model = _context.Customers.FirstOrDefault(m => m.UID == request.ViewModel.Id);
            if (model is null) 
            {
                result.ExceptionObjects.Add(new NotFoundException(nameof(Customer), request.ViewModel.Id));
                result.Message = ReferencesTextResponse.CustometNotFound;
                return result;
            }

            model.FirstName = request.ViewModel.FirstName;
            model.LastName = request.ViewModel.LastName;
            model.Patronymic = request.ViewModel.Patronymic;
            model.Telephone = request.ViewModel.Telephone;
            model.Passport = request.ViewModel.Passport;
            
            await _context.SaveChangesAsync(cancellationToken);
            return result;
        }
    }
}

using Bank.Application.Common;
using FluentValidation;
using MediatR;

namespace Bank.Application.Customers.Behaviors
{
    public class ValidatorBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
       where TRequest : IRequest<TResponse>
    {
        private readonly IEnumerable<IValidator<TRequest>> _validators;

        public ValidatorBehavior(IEnumerable<IValidator<TRequest>> validators) => _validators = validators;

        public Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
        {
            var failures = _validators
                .Select(x => x.Validate(new ValidationContext<TRequest>(request)))
                .SelectMany(x => x.Errors)
                .Where(x => x != null)
                .ToList();

            if (!failures.Any())
            {
                return next();
            }

            var type = typeof(TResponse);
            if (!type.IsSubclassOf(typeof(WrapperResult)))
            {
                throw new ValidationException(failures);
            }

            var result = Activator.CreateInstance(type);
            ((WrapperResult)result!).ExceptionObjects.Add(new ValidationException(failures));
            return Task.FromResult((TResponse)result!);
        }
    }
}

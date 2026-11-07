using FluentValidation;
using MediatR;

namespace Common.Common.Application.Pipelines;

public class ValidationBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse> where TRequest : notnull
{
    private readonly IEnumerable<IValidator<TRequest>> _validators;

    public ValidationBehavior(IEnumerable<IValidator<TRequest>> validators)
    {
        _validators = validators;
    }

    public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
    {
        var context = new ValidationContext<TRequest>(request);

        var errors = _validators
            .SelectMany(x => x.Validate(context).Errors)
            .Where(x => x != null)
            .ToList();

        if (errors.Any())
        {
            // باید بر اساس ساختار OperationResult پروژه پیاده‌سازی شود.
            throw new ValidationException(errors);
        }

        return await next(cancellationToken);
    }
}
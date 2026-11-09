using Common.Application;
using FluentValidation;
using MediatR;

namespace Common.Common.Application.Pipelines;

public class ExceptionBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse> where TRequest : notnull
{
    private readonly IEnumerable<IValidator<TRequest>> _validators;

    public ExceptionBehavior(IEnumerable<IValidator<TRequest>> validators)
    {
        _validators = validators;
    }
    public async Task<TResponse> Handle(
        TRequest request,
        RequestHandlerDelegate<TResponse> next,
        CancellationToken cancellationToken)
    {
        var context = new ValidationContext<TRequest>(request);

        var errors = _validators
            .SelectMany(x => x.Validate(context).Errors)
            .Where(x => x != null)
            .ToList();

        if (errors.Any())
            throw new ValidationException(errors);

        return await next(cancellationToken);
    }
}
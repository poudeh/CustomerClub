using Common.Application;
using FluentValidation;
using MediatR;

namespace Common.Common.Application.Pipelines;

public class ExceptionBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse> where TRequest : notnull
{
    public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
    {
        try
        {
            return await next(cancellationToken);
        }
        catch (InvalidOperationException ex)
        {
            return (TResponse)(object)OperationResult.Error(ex.Message);
        }
        catch (ValidationException ex)
        {
            var errors = ex.Errors
                .Select(x => x.ErrorMessage)
                .ToList();

            return (TResponse)(object)OperationResult.Error(errors);
        }
    }
}
using MediatR;

namespace Club.Infrastructure._Utilities.MediatR;

public interface ICustomPublisher
{
    PublishStrategy DefaultStrategy { get; set; }

    Task Publish<TNotification>(TNotification notification)
        where TNotification : INotification;

    Task Publish<TNotification>(
        TNotification notification,
        PublishStrategy strategy)
        where TNotification : INotification;

    Task Publish<TNotification>(
        TNotification notification,
        CancellationToken cancellationToken)
        where TNotification : INotification;

    Task Publish<TNotification>(
        TNotification notification,
        PublishStrategy strategy,
        CancellationToken cancellationToken)
        where TNotification : INotification;
}
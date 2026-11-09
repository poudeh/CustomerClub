using MediatR;

namespace Club.Infrastructure._Utilities.MediatR;

public class CustomMediator : INotificationPublisher
{
    private readonly Func<IEnumerable<NotificationHandlerExecutor>, INotification, CancellationToken, Task> _publish;

    public CustomMediator(Func<IEnumerable<NotificationHandlerExecutor>, INotification, CancellationToken, Task> publish)
    {
        _publish = publish;
    }

    public Task Publish(IEnumerable<NotificationHandlerExecutor> handlerExecutors, INotification notification, CancellationToken cancellationToken)
    {
        return _publish(
            handlerExecutors,
            notification,
            cancellationToken);
    }
}
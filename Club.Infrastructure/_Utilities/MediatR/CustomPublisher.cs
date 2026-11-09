using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Club.Infrastructure._Utilities.MediatR;

public class CustomPublisher : ICustomPublisher
{
    private readonly IServiceProvider _serviceProvider;

    private readonly IDictionary<PublishStrategy,
        Func<IEnumerable<NotificationHandlerExecutor>, INotification,
            CancellationToken, Task>> _publishStrategies;

    public PublishStrategy DefaultStrategy { get; set; } =
        PublishStrategy.SyncContinueOnException;

    public CustomPublisher(IServiceProvider serviceProvider)
    {
        _serviceProvider = serviceProvider;

        _publishStrategies = new Dictionary<PublishStrategy,
            Func<IEnumerable<NotificationHandlerExecutor>, INotification,
                CancellationToken, Task>>
        {
            [PublishStrategy.Async] = AsyncContinueOnException,
            [PublishStrategy.ParallelNoWait] = ParallelNoWait,
            [PublishStrategy.ParallelWhenAll] = ParallelWhenAll,
            [PublishStrategy.ParallelWhenAny] = ParallelWhenAny,
            [PublishStrategy.SyncContinueOnException] = SyncContinueOnException,
            [PublishStrategy.SyncStopOnException] = SyncStopOnException
        };
    }

    public Task Publish<TNotification>(TNotification notification) where TNotification : INotification
    {
        return Publish(notification, DefaultStrategy, CancellationToken.None);
    }

    public Task Publish<TNotification>(
        TNotification notification,
        PublishStrategy strategy)
        where TNotification : INotification
    {
        return Publish(notification, strategy, CancellationToken.None);
    }

    public Task Publish<TNotification>(
        TNotification notification,
        CancellationToken cancellationToken)
        where TNotification : INotification
    {
        return Publish(notification, DefaultStrategy, cancellationToken);
    }

    public Task Publish<TNotification>(
        TNotification notification,
        PublishStrategy strategy,
        CancellationToken cancellationToken)
        where TNotification : INotification
    {
        if (!_publishStrategies.TryGetValue(strategy, out var publish))
            throw new ArgumentException($"Unknown strategy: {strategy}");

        var handlers = _serviceProvider
            .GetServices<INotificationHandler<TNotification>>()
            .Select(handler => new NotificationHandlerExecutor(
                handler,
                (notification, token) =>
                    handler.Handle((TNotification)notification, token)))
            .ToList();

        return publish(handlers, notification, cancellationToken);
    }

    // 1. Async: اجرای غیرهمزمان Handlerها و انتظار برای همه
    private async Task AsyncContinueOnException(
        IEnumerable<NotificationHandlerExecutor> handlers,
        INotification notification,
        CancellationToken cancellationToken)
    {
        var tasks = new List<Task>();
        var exceptions = new List<Exception>();

        foreach (var handler in handlers)
        {
            try
            {
                tasks.Add(handler.HandlerCallback(
                    notification, cancellationToken));
            }
            catch (Exception ex) when (
                ex is not OutOfMemoryException &&
                ex is not StackOverflowException)
            {
                exceptions.Add(ex);
            }
        }

        try
        {
            await Task.WhenAll(tasks).ConfigureAwait(false);
        }
        catch (Exception ex) when (
            ex is not OutOfMemoryException &&
            ex is not StackOverflowException)
        {
            foreach (var task in tasks.Where(x => x.IsFaulted))
            {
                exceptions.AddRange(
                    task.Exception!.Flatten().InnerExceptions);
            }

            if (!tasks.Any(x => x.IsFaulted))
                exceptions.Add(ex);
        }

        if (exceptions.Any())
            throw new AggregateException(exceptions);
    }

    // 2. ParallelNoWait: اجرا بدون انتظار
    private Task ParallelNoWait(
        IEnumerable<NotificationHandlerExecutor> handlers,
        INotification notification,
        CancellationToken cancellationToken)
    {
        foreach (var handler in handlers)
        {
            _ = Task.Run(() =>
                handler.HandlerCallback(notification, cancellationToken));
        }

        return Task.CompletedTask;
    }

    // 3. ParallelWhenAll: اجرای موازی و انتظار برای همه
    private Task ParallelWhenAll(
        IEnumerable<NotificationHandlerExecutor> handlers,
        INotification notification,
        CancellationToken cancellationToken)
    {
        var tasks = handlers.Select(handler =>
            Task.Run(() =>
                handler.HandlerCallback(notification, cancellationToken)));

        return Task.WhenAll(tasks);
    }

    // 4. ParallelWhenAny: انتظار برای اولین Handler تکمیل‌شده
    private async Task ParallelWhenAny(
        IEnumerable<NotificationHandlerExecutor> handlers,
        INotification notification,
        CancellationToken cancellationToken)
    {
        var tasks = handlers.Select(handler =>
            Task.Run(() =>
                handler.HandlerCallback(notification, cancellationToken)))
            .ToList();

        if (tasks.Count == 0)
            return;

        await Task.WhenAny(tasks).ConfigureAwait(false);
    }

    // 5. SyncContinueOnException: اجرای ترتیبی با ادامه بعد از خطا
    private async Task SyncContinueOnException(
        IEnumerable<NotificationHandlerExecutor> handlers,
        INotification notification,
        CancellationToken cancellationToken)
    {
        var exceptions = new List<Exception>();

        foreach (var handler in handlers)
        {
            try
            {
                await handler.HandlerCallback(
                    notification, cancellationToken).ConfigureAwait(false);
            }
            catch (AggregateException ex)
            {
                exceptions.AddRange(ex.Flatten().InnerExceptions);
            }
            catch (Exception ex) when (
                ex is not OutOfMemoryException &&
                ex is not StackOverflowException)
            {
                exceptions.Add(ex);
            }
        }

        if (exceptions.Any())
            throw new AggregateException(exceptions);
    }

    // 6. SyncStopOnException: اجرای ترتیبی با توقف بعد از خطا
    private async Task SyncStopOnException(
        IEnumerable<NotificationHandlerExecutor> handlers,
        INotification notification,
        CancellationToken cancellationToken)
    {
        foreach (var handler in handlers)
        {
            await handler.HandlerCallback(
                notification, cancellationToken).ConfigureAwait(false);
        }
    }
}
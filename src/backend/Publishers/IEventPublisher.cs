namespace backend.Publishers;

using backend.Events;

public interface IEventPublisher
{
    Task PublishAsync(IEvent @event);
}

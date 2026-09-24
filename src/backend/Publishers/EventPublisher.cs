namespace backend.Publishers;

using backend.Events;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

public class EventPublisher : IEventPublisher
{
    private readonly Dictionary<Type, List<Func<IEvent, Task>>> _handlers = new();

    public void Subscribe<T>(Func<T, Task> handler) where T : IEvent
    {
        var eventType = typeof(T);
        if (!_handlers.ContainsKey(eventType))
        {
            _handlers[eventType] = new List<Func<IEvent, Task>>();
        }

        _handlers[eventType].Add(@event => handler((T)@event));
    }

    public async Task PublishAsync(IEvent @event)
    {
        var eventType = @event.GetType();

        if (_handlers.TryGetValue(eventType, out var handlers))
        {
            var tasks = handlers.Select(h => h(@event));
            await Task.WhenAll(tasks);
        }
    }
}

namespace backend.Events;

public interface IEvent
{
    Guid EventId { get; }
    DateTime Timestamp { get; }
}

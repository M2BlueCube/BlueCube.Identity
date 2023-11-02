namespace LiteChat.Games.Events;

public abstract record BaseEvent
{
    public int Id { get; init; }
    public DateTimeOffset TimeStamp { get; init; } = DateTimeOffset.UtcNow;
}
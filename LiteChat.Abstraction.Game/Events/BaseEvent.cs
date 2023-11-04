namespace LiteChat.Abstraction.Game.Events;

public abstract record BaseEvent
{
    public int Id { get; init; }
    public DateTimeOffset TimeStamp { get; init; } = DateTimeOffset.UtcNow;
}
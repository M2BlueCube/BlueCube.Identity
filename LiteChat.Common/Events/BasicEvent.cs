namespace LiteChat.Common.Events;


public abstract record BasicEvent
{
    public int Id { get; init; }
    public DateTimeOffset TimeStamp { get; init; } = DateTimeOffset.UtcNow;
}

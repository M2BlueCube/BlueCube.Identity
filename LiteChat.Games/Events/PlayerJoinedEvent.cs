namespace LiteChat.Games.Events;

public abstract record PlayerJoinedEvent : BaseEvent
{
    public Guid UserId { get; init; }
}

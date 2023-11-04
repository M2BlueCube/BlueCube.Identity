namespace LiteChat.Abstraction.Game.Events;

public abstract record PlayerJoinedEvent : BaseEvent
{
    public Guid UserId { get; init; }
}

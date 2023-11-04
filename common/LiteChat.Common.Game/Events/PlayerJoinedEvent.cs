using LiteChat.Common.Events;

namespace LiteChat.Common.Game.Events;

public abstract record PlayerJoinedEvent : BaseEvent
{
    public Guid UserId { get; init; }
}

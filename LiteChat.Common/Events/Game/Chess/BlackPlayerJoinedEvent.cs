using LiteChat.Common.Events.Game;

namespace LiteChat.Common.Chess.Events;

public sealed record BlackPlayerJoinedEvent : JoinGameEvent
{
    public override string EventName => nameof(BlackPlayerJoinedEvent);
}

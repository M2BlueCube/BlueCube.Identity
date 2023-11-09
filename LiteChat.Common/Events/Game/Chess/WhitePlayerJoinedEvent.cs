using LiteChat.Common.Events.Game;

namespace LiteChat.Common.Chess.Events;

public sealed record WhitePlayerJoinedEvent : JoinGameEvent
{
    public override string EventName => nameof(WhitePlayerJoinedEvent);
}

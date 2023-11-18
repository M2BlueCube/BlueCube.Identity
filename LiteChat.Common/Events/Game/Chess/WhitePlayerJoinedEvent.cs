namespace LiteChat.Common.Events.Game.Chess;

public sealed record WhitePlayerJoinedEvent : JoinGameEvent
{
    public override string EventName => nameof(WhitePlayerJoinedEvent);
}

namespace LiteChat.Common.Events.Game.Chess;

public sealed record BlackPlayerJoinedEvent : JoinGameEvent
{
    public override string EventName => nameof(BlackPlayerJoinedEvent);
}

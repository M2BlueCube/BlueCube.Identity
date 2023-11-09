using LiteChat.Common.Models.Games;
using System.Text.Json.Serialization;
using LiteChat.Common.Events.Game.Chess;

namespace LiteChat.Common.Events.Game;



[JsonDerivedType(typeof(GameCreatedEvent), nameof(GameCreatedEvent))]

[JsonDerivedType(typeof(ChessMoveEvent), nameof(ChessMoveEvent))]
[JsonDerivedType(typeof(ChessPromotePawnEvent), nameof(ChessPromotePawnEvent))]
[JsonDerivedType(typeof(WhitePlayerJoinedEvent), nameof(WhitePlayerJoinedEvent))]
[JsonDerivedType(typeof(BlackPlayerJoinedEvent), nameof(BlackPlayerJoinedEvent))]
public abstract record BasicGameEvent : BasicEvent 
{
    public Guid GameId { get; init; }
}

[JsonDerivedType(typeof(WhitePlayerJoinedEvent), nameof(WhitePlayerJoinedEvent))]
[JsonDerivedType(typeof(BlackPlayerJoinedEvent), nameof(BlackPlayerJoinedEvent))]
public abstract record JoinGameEvent : BasicGameEvent
{
    public Guid UserId { get; init; }
}

public record GameCreatedEvent : BasicGameEvent
{
    public GameType Game { get; init; }
    public override string EventName => nameof(GameCreatedEvent);
}

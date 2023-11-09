using LiteChat.Common.Events.Game;
using LiteChat.Common.Events.Social.Chat;
using System.Text.Json.Serialization;
using LiteChat.Common.Events.Game.Chess;

namespace LiteChat.Common.Events;

[JsonDerivedType(typeof(MessageSentEvent), nameof(MessageSentEvent))]
[JsonDerivedType(typeof(ChatCreatedEvent), nameof(ChatCreatedEvent))]
[JsonDerivedType(typeof(ChatDeletedEvent), nameof(ChatDeletedEvent))]
[JsonDerivedType(typeof(UserLeftChatEvent), nameof(UserLeftChatEvent))]
[JsonDerivedType(typeof(UserJoinedChatEvent), nameof(UserJoinedChatEvent))]


[JsonDerivedType(typeof(GameCreatedEvent), nameof(GameCreatedEvent))]

[JsonDerivedType(typeof(ChessMoveEvent), nameof(ChessMoveEvent))]
[JsonDerivedType(typeof(ChessPromotePawnEvent), nameof(ChessPromotePawnEvent))]
[JsonDerivedType(typeof(WhitePlayerJoinedEvent), nameof(WhitePlayerJoinedEvent))]
[JsonDerivedType(typeof(BlackPlayerJoinedEvent), nameof(BlackPlayerJoinedEvent))]
public abstract record BasicEvent
{
    public int Id { get; init; }
    public abstract string EventName { get; }
    public DateTimeOffset TimeStamp { get; init; } = DateTimeOffset.UtcNow;
}

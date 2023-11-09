using LiteChat.Common.Models.Games.Chess;

namespace LiteChat.Common.Events.Game.Chess;

public record ChessPromotePawnEvent : ChessMoveEvent
{
    public ChessPieceType PromoteTo { get; init; }
    public override string EventName => nameof(ChessPromotePawnEvent);
}
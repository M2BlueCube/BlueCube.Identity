using LiteChat.Common.Chess.Models;

namespace LiteChat.Common.Chess.Events;

public record ChessPromotePawnEvent : ChessMoveEvent
{
    public ChessPieceType PromoteTo { get; init; }
}
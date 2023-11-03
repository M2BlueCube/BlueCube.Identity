using LiteChat.Chess.Models;

namespace LiteChat.Chess.Events;

public record ChessPromotePawnEvent : ChessMoveEvent
{
    public ChessPieceType PromoteTo { get; init; }
}
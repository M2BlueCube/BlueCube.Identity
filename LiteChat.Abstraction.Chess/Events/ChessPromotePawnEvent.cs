using LiteChat.Abstraction.Chess.Models;

namespace LiteChat.Abstraction.Chess.Events;

public record ChessPromotePawnEvent : ChessMoveEvent
{
    public ChessPieceType PromoteTo { get; init; }
}
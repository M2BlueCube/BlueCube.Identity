using LiteChat.Abstraction.Chess.Models;
using LiteChat.Abstraction.Game.Events;

namespace LiteChat.Abstraction.Chess.Events;

public record ChessMoveEvent : BaseEvent
{
    public ChessPiece Piece { get; init; } = ChessPiece.Empty;
    public ChessSquares To { get; init; } = ChessSquares.None;
    public ChessSquares From { get; init; } = ChessSquares.None;
}
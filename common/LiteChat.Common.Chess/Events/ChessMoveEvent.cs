using LiteChat.Common.Chess.Models;
using LiteChat.Common.Events;

namespace LiteChat.Common.Chess.Events;

public record ChessMoveEvent : BaseEvent
{
    public ChessPiece Piece { get; init; } = ChessPiece.Empty;
    public ChessSquares To { get; init; } = ChessSquares.None;
    public ChessSquares From { get; init; } = ChessSquares.None;
}
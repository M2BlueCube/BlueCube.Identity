using LiteChat.Chess.Models;
using LiteChat.Games.Events;
using LiteChat.Games.States;

namespace LiteChat.Chess.Events;

public record ChessMoveEvent : BaseEvent
{
    public ChessPiece Piece { get; init; }
    public ChessSquares From { get; init; }
    public ChessSquares To { get; init; }
}
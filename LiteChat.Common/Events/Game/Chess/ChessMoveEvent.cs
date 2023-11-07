
using LiteChat.Common.Events;
using LiteChat.Common.Models.Games.Chess;

namespace LiteChat.Common.Chess.Events;

public record ChessMoveEvent : BasicEvent
{
    public ChessSquares To { get; init; } = ChessSquares.None;
    public ChessSquares From { get; init; } = ChessSquares.None;
}
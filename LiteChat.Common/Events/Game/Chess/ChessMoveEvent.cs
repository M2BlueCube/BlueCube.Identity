using LiteChat.Common.Models.Games.Chess;

namespace LiteChat.Common.Events.Game.Chess;

public record ChessMoveEvent : BasicEvent
{
    public ChessSquares To { get; init; } = ChessSquares.None;
    public ChessSquares From { get; init; } = ChessSquares.None;

    public override string EventName => nameof(ChessMoveEvent);
}
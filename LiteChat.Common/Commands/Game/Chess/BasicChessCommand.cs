using LiteChat.Common.Models.Games.Chess;

namespace LiteChat.Common.Commands.Game.Chess;

public abstract record BasicChessCommand : BasicGameCommand
{
    public Guid GameId { get; init; }
}

public record JoinGameCommand : BasicChessCommand
{
    public ChessPieceColor Color { get; init; } = ChessPieceColor.None;
}

public record MoveChessPieceCommand : BasicChessCommand
{
    public ChessPieceType Piece { get; init; } = ChessPieceType.None;
    public ChessSquares To { get; init; } = ChessSquares.None;
    public ChessSquares From { get; init; } = ChessSquares.None;
}
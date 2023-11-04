namespace LiteChat.Abstraction.Chess.Models;

public record ChessPiece(ChessPieceType Type = ChessPieceType.None, ChessPieceColor Color = ChessPieceColor.None) 
{
    public static ChessPiece Empty => new();
}

public record ChessPiecePosition(ChessSquares Square, ChessPieceType Type = ChessPieceType.None, ChessPieceColor Color = ChessPieceColor.None);

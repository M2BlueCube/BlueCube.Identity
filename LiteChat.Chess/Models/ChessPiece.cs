namespace LiteChat.Chess.Models;

public record ChessPiece(ChessPieceType Type, ChessPieceColor Color);
public record ChessPiecePosition(ChessSquares Square,ChessPieceType Type, ChessPieceColor Color);


using LiteChat.Common.Commands.Game.Chess;
using System.Diagnostics.CodeAnalysis;

namespace LiteChat.Common.Models.Games.Chess;

public abstract record ChessPiece
{
    public abstract ChessPieceType Type { get; }
    public required ChessPieceColor Color { get; init; }
    public abstract bool CanMove(ChessState state, MoveChessPieceCommand command, [MaybeNullWhen(false)] out ChessPiece piece);

    public static ChessPawn WhitePawn => new() { Color = ChessPieceColor.White };
    public static ChessPawn BlackPawn => new() { Color = ChessPieceColor.Black };

    public static ChessRook WhiteRook => new() { Color = ChessPieceColor.White };
    public static ChessRook BlackRook => new() { Color = ChessPieceColor.Black };

    public static ChessKnight WhiteKnight => new() { Color = ChessPieceColor.White };
    public static ChessKnight BlackKnight => new() { Color = ChessPieceColor.Black };

    public static ChessBishop WhiteBishop => new() { Color = ChessPieceColor.White };
    public static ChessBishop BlackBishop => new() { Color = ChessPieceColor.Black };

    public static ChessQueen WhiteQueen => new() { Color = ChessPieceColor.White };
    public static ChessQueen BlackQueen => new() { Color = ChessPieceColor.Black };

    public static ChessKing WhiteKing => new() { Color = ChessPieceColor.White };
    public static ChessKing BlackKing => new() { Color = ChessPieceColor.Black };

    public static ChessPiece PromotePiece(ChessPawn pawn, ChessPieceType type) =>
        type switch
        {
            ChessPieceType.Pawn => pawn,
            
            ChessPieceType.Rook when pawn.Color is ChessPieceColor.White => WhiteRook,
            ChessPieceType.Rook when pawn.Color is ChessPieceColor.Black => BlackRook,
            
            ChessPieceType.Knight when pawn.Color is ChessPieceColor.White => WhiteKnight,
            ChessPieceType.Knight when pawn.Color is ChessPieceColor.Black => BlackKnight,

            ChessPieceType.Bishop when pawn.Color is ChessPieceColor.White => WhiteBishop,
            ChessPieceType.Bishop when pawn.Color is ChessPieceColor.Black => BlackBishop,

            ChessPieceType.Queen when pawn.Color is ChessPieceColor.White => WhiteQueen,
            ChessPieceType.Queen when pawn.Color is ChessPieceColor.Black => BlackQueen,

            _ => throw new ArgumentException(),
        };

    protected bool CheckDestination(ChessPiecePosition[] positions, ChessSquares to)
    {
        return positions.FirstOrDefault(piece => piece.Square == to)?.Piece.Color != Color;
    }

    protected bool CheckIfCheck(ChessPiecePosition[] positions, ChessSquares from, ChessSquares to)
    {
        var kingPosition = positions.First(piece => piece.Piece.Type == ChessPieceType.King && piece.Piece.Color == Color);

        throw new NotImplementedException();
        //return positions.Where(piece => piece.Piece.Color != Color)
        //    .Any(oppositePiece => oppositePiece.Piece.CanMove(positions, oppositePiece.Square, kingPosition.Square, out _));
    }
}

public record ChessPawn : ChessPiece
{
    public override ChessPieceType Type => ChessPieceType.Pawn;

    public override bool CanMove(ChessState state, MoveChessPieceCommand command, [MaybeNullWhen(false)] out ChessPiece piece)
    {
        throw new NotImplementedException();
    }
}

public record InitialChessPawn : ChessPiece
{
    public override ChessPieceType Type => ChessPieceType.Pawn;

    public override bool CanMove(ChessState state, MoveChessPieceCommand command, [MaybeNullWhen(false)] out ChessPiece piece)
    {
        throw new NotImplementedException();
    }
}

public record ChessRook : ChessPiece
{
    public override ChessPieceType Type => ChessPieceType.Rook;

    
    public override bool CanMove(ChessState state, MoveChessPieceCommand command, [MaybeNullWhen(false)] out ChessPiece piece)
    {
        throw new NotImplementedException();
    }
}

public record ChessKnight : ChessPiece
{
    public override ChessPieceType Type => ChessPieceType.Knight;

    public override bool CanMove(ChessState state, MoveChessPieceCommand command, [MaybeNullWhen(false)] out ChessPiece piece)
    {
        throw new NotImplementedException();
    }
}

public record ChessBishop : ChessPiece
{
    public override ChessPieceType Type => ChessPieceType.Bishop;

    public override bool CanMove(ChessState state, MoveChessPieceCommand command, [MaybeNullWhen(false)] out ChessPiece piece)
    {
        throw new NotImplementedException();
    }
}

public record ChessQueen : ChessPiece
{
    public override ChessPieceType Type => ChessPieceType.Queen;

    public override bool CanMove(ChessState state, MoveChessPieceCommand command, [MaybeNullWhen(false)] out ChessPiece piece)
    {
        throw new NotImplementedException();
    }
}

public record ChessKing : ChessPiece
{
    public override ChessPieceType Type => ChessPieceType.King;

    public override bool CanMove(ChessState state, MoveChessPieceCommand command, [MaybeNullWhen(false)] out ChessPiece piece)
    {
        throw new NotImplementedException();
    }
}

public record ChessPiecePosition(ChessSquares Square, ChessPiece Piece);

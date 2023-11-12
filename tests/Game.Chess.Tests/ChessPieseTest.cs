using LiteChat.Common.Models.Games.Chess;

namespace Game.Chess.Tests;

public class ChessPieceTest
{
    //[Theory]
    //[InlineData(ChessPieceType.Pawn, ChessPieceColor.White, "♙")]
    //[InlineData(ChessPieceType.Pawn, ChessPieceColor.Black, "♟")]
    //[InlineData(ChessPieceType.Rook, ChessPieceColor.White, "♖")]
    //[InlineData(ChessPieceType.Rook, ChessPieceColor.Black, "♜")]
    //[InlineData(ChessPieceType.Knight, ChessPieceColor.White, "♘")]
    //[InlineData(ChessPieceType.Knight, ChessPieceColor.Black, "♞")]
    //[InlineData(ChessPieceType.Bishop, ChessPieceColor.White, "♗")]
    //[InlineData(ChessPieceType.Bishop, ChessPieceColor.Black, "♝")]
    //[InlineData(ChessPieceType.Queen, ChessPieceColor.White, "♕")]
    //[InlineData(ChessPieceType.Queen, ChessPieceColor.Black, "♛")]
    //[InlineData(ChessPieceType.King, ChessPieceColor.White, "♔")]
    //[InlineData(ChessPieceType.King, ChessPieceColor.Black, "♚")]
    //public void ChessPieceToString(ChessPieceType type, ChessPieceColor color, string expected)
    //{
    //    // Arrange
    //}

    [Fact]
    public void Vertical_Distance()
    {
        // Arrange
        
        ChessSquares to = ChessSquares.A2;
        ChessSquares from = ChessSquares.A1;

        // Act

        bool resultD = from.DiagonalDistance(to, out int valueD);
        bool resultP = from.VerticalDistance(to, out int valueP);

        // Assert
        
        Assert.True(resultP);
        Assert.False(resultD);

        Assert.Equal(1, valueP);
        Assert.Equal(0, valueD);
    }

    [Fact]
    public void Horizontal_Distance()
    {
        // Arrange
        
        ChessSquares to = ChessSquares.A2;
        ChessSquares from = ChessSquares.C2;

        // Act

        bool resultD = from.DiagonalDistance(to, out int valueD);
        bool resultP = from.HorizontalDistance(to, out int valueP);

        // Assert

        Assert.True(resultP);
        Assert.False(resultD);

        Assert.Equal(-2, valueP);
        Assert.Equal(0, valueD);
    }

    [Fact]
    public void Diagonal_Distance()
    {
        // Arrange
        
        ChessSquares to = ChessSquares.C4;
        ChessSquares from = ChessSquares.A2;

        // Act

        bool resultD = from.DiagonalDistance(to, out int valueD);
        bool resultP = from.HorizontalDistance(to, out int valueP);

        // Assert

        Assert.False(resultP);
        Assert.True(resultD);

        Assert.Equal(2, valueD);
        Assert.Equal(0, valueP);
    }

}

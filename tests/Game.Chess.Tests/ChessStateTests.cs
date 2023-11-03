using LiteChat.Chess.Implementations;
using LiteChat.Chess.Models;

namespace Game.Chess.Tests
{
    public class ChessStateTests
    {
        [Theory]
        [InlineData(1, 1, ChessPieceType.Rook, ChessPieceColor.White)]
        [InlineData(1, 2, ChessPieceType.Knight, ChessPieceColor.White)]
        [InlineData(1, 3, ChessPieceType.Bishop, ChessPieceColor.White)]
        [InlineData(1, 4, ChessPieceType.Queen, ChessPieceColor.White)]
        [InlineData(1, 5, ChessPieceType.King, ChessPieceColor.White)]
        [InlineData(1, 6, ChessPieceType.Bishop, ChessPieceColor.White)]
        [InlineData(1, 7, ChessPieceType.Knight, ChessPieceColor.White)]
        [InlineData(1, 8, ChessPieceType.Rook, ChessPieceColor.White)]
        [InlineData(2, 1, ChessPieceType.Pawn, ChessPieceColor.White)]
        [InlineData(2, 2, ChessPieceType.Pawn, ChessPieceColor.White)]
        [InlineData(2, 3, ChessPieceType.Pawn, ChessPieceColor.White)]
        [InlineData(2, 4, ChessPieceType.Pawn, ChessPieceColor.White)]
        [InlineData(2, 5, ChessPieceType.Pawn, ChessPieceColor.White)]
        [InlineData(2, 6, ChessPieceType.Pawn, ChessPieceColor.White)]
        [InlineData(2, 7, ChessPieceType.Pawn, ChessPieceColor.White)]
        [InlineData(2, 8, ChessPieceType.Pawn, ChessPieceColor.White)]
        [InlineData(7, 1, ChessPieceType.Pawn, ChessPieceColor.Black)]
        [InlineData(7, 2, ChessPieceType.Pawn, ChessPieceColor.Black)]
        [InlineData(7, 3, ChessPieceType.Pawn, ChessPieceColor.Black)]
        [InlineData(7, 4, ChessPieceType.Pawn, ChessPieceColor.Black)]
        [InlineData(7, 5, ChessPieceType.Pawn, ChessPieceColor.Black)]
        [InlineData(7, 6, ChessPieceType.Pawn, ChessPieceColor.Black)]
        [InlineData(7, 7, ChessPieceType.Pawn, ChessPieceColor.Black)]
        [InlineData(7, 8, ChessPieceType.Pawn, ChessPieceColor.Black)]
        [InlineData(8, 1, ChessPieceType.Rook, ChessPieceColor.Black)]
        [InlineData(8, 2, ChessPieceType.Knight, ChessPieceColor.Black)]
        [InlineData(8, 3, ChessPieceType.Bishop, ChessPieceColor.Black)]
        [InlineData(8, 4, ChessPieceType.Queen, ChessPieceColor.Black)]
        [InlineData(8, 5, ChessPieceType.King, ChessPieceColor.Black)]
        [InlineData(8, 6, ChessPieceType.Bishop, ChessPieceColor.Black)]
        [InlineData(8, 7, ChessPieceType.Knight, ChessPieceColor.Black)]
        [InlineData(8, 8, ChessPieceType.Rook, ChessPieceColor.Black)]
        public void GetPiecePosition(byte x, byte y, ChessPieceType type, ChessPieceColor color)
        {
            ChessState state = new();
            ChessSquares square = new(x, y);

            var piece = state.GetPiecePosition(square);

            Assert.NotNull(piece);
            Assert.Equal(type, piece.Type);
            Assert.Equal(color, piece.Color);
        }

        [Theory]
        [InlineData(1, 1, ChessPieceType.Rook, ChessPieceColor.White)]
        [InlineData(1, 2, ChessPieceType.Knight, ChessPieceColor.White)]
        [InlineData(1, 3, ChessPieceType.Bishop, ChessPieceColor.White)]
        [InlineData(1, 4, ChessPieceType.Queen, ChessPieceColor.White)]
        [InlineData(1, 5, ChessPieceType.King, ChessPieceColor.White)]
        [InlineData(1, 6, ChessPieceType.Bishop, ChessPieceColor.White)]
        [InlineData(1, 7, ChessPieceType.Knight, ChessPieceColor.White)]
        [InlineData(1, 8, ChessPieceType.Rook, ChessPieceColor.White)]
        [InlineData(2, 1, ChessPieceType.Pawn, ChessPieceColor.White)]
        [InlineData(2, 2, ChessPieceType.Pawn, ChessPieceColor.White)]
        [InlineData(2, 3, ChessPieceType.Pawn, ChessPieceColor.White)]
        [InlineData(2, 4, ChessPieceType.Pawn, ChessPieceColor.White)]
        [InlineData(2, 5, ChessPieceType.Pawn, ChessPieceColor.White)]
        [InlineData(2, 6, ChessPieceType.Pawn, ChessPieceColor.White)]
        [InlineData(2, 7, ChessPieceType.Pawn, ChessPieceColor.White)]
        [InlineData(2, 8, ChessPieceType.Pawn, ChessPieceColor.White)]
        [InlineData(7, 1, ChessPieceType.Pawn, ChessPieceColor.Black)]
        [InlineData(7, 2, ChessPieceType.Pawn, ChessPieceColor.Black)]
        [InlineData(7, 3, ChessPieceType.Pawn, ChessPieceColor.Black)]
        [InlineData(7, 4, ChessPieceType.Pawn, ChessPieceColor.Black)]
        [InlineData(7, 5, ChessPieceType.Pawn, ChessPieceColor.Black)]
        [InlineData(7, 6, ChessPieceType.Pawn, ChessPieceColor.Black)]
        [InlineData(7, 7, ChessPieceType.Pawn, ChessPieceColor.Black)]
        [InlineData(7, 8, ChessPieceType.Pawn, ChessPieceColor.Black)]
        [InlineData(8, 1, ChessPieceType.Rook, ChessPieceColor.Black)]
        [InlineData(8, 2, ChessPieceType.Knight, ChessPieceColor.Black)]
        [InlineData(8, 3, ChessPieceType.Bishop, ChessPieceColor.Black)]
        [InlineData(8, 4, ChessPieceType.Queen, ChessPieceColor.Black)]
        [InlineData(8, 5, ChessPieceType.King, ChessPieceColor.Black)]
        [InlineData(8, 6, ChessPieceType.Bishop, ChessPieceColor.Black)]
        [InlineData(8, 7, ChessPieceType.Knight, ChessPieceColor.Black)]
        [InlineData(8, 8, ChessPieceType.Rook, ChessPieceColor.Black)]
        public void GetPieceAllPosition(byte x, byte y, ChessPieceType type, ChessPieceColor color)
        {
            ChessState state = new();

            var pieces = state.GetPiecePositions();
            var piece = pieces.FirstOrDefault(p => p.Square.X == x && p.Square.Y == y);
            
            Assert.NotNull(piece);
            Assert.Equal(type, piece.Type);
            Assert.Equal(color, piece.Color);
        }

    }
}
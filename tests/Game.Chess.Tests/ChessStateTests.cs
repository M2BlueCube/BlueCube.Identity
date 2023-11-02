using LiteChat.Chess.Implementations;
using LiteChat.Chess.Models;

namespace Game.Chess.Tests
{
    public class ChessStateTests
    {
        [Theory]
        [InlineData(1, 'A', ChessPieceType.Rook, ChessPieceColor.White)]
        [InlineData(1, 'B', ChessPieceType.Knight, ChessPieceColor.White)]
        [InlineData(1, 'C', ChessPieceType.Bishop, ChessPieceColor.White)]
        [InlineData(1, 'D', ChessPieceType.Queen, ChessPieceColor.White)]
        [InlineData(1, 'E', ChessPieceType.King, ChessPieceColor.White)]
        [InlineData(1, 'F', ChessPieceType.Bishop, ChessPieceColor.White)]
        [InlineData(1, 'G', ChessPieceType.Knight, ChessPieceColor.White)]
        [InlineData(1, 'H', ChessPieceType.Rook, ChessPieceColor.White)]
        [InlineData(2, 'A', ChessPieceType.Pawn, ChessPieceColor.White)]
        [InlineData(2, 'B', ChessPieceType.Pawn, ChessPieceColor.White)]
        [InlineData(2, 'C', ChessPieceType.Pawn, ChessPieceColor.White)]
        [InlineData(2, 'D', ChessPieceType.Pawn, ChessPieceColor.White)]
        [InlineData(2, 'E', ChessPieceType.Pawn, ChessPieceColor.White)]
        [InlineData(2, 'F', ChessPieceType.Pawn, ChessPieceColor.White)]
        [InlineData(2, 'G', ChessPieceType.Pawn, ChessPieceColor.White)]
        [InlineData(2, 'H', ChessPieceType.Pawn, ChessPieceColor.White)]
        [InlineData(7, 'A', ChessPieceType.Pawn, ChessPieceColor.Black)]
        [InlineData(7, 'B', ChessPieceType.Pawn, ChessPieceColor.Black)]
        [InlineData(7, 'C', ChessPieceType.Pawn, ChessPieceColor.Black)]
        [InlineData(7, 'D', ChessPieceType.Pawn, ChessPieceColor.Black)]
        [InlineData(7, 'E', ChessPieceType.Pawn, ChessPieceColor.Black)]
        [InlineData(7, 'F', ChessPieceType.Pawn, ChessPieceColor.Black)]
        [InlineData(7, 'G', ChessPieceType.Pawn, ChessPieceColor.Black)]
        [InlineData(7, 'H', ChessPieceType.Pawn, ChessPieceColor.Black)]
        [InlineData(8, 'A', ChessPieceType.Rook, ChessPieceColor.Black)]
        [InlineData(8, 'B', ChessPieceType.Knight, ChessPieceColor.Black)]
        [InlineData(8, 'C', ChessPieceType.Bishop, ChessPieceColor.Black)]
        [InlineData(8, 'D', ChessPieceType.Queen, ChessPieceColor.Black)]
        [InlineData(8, 'E', ChessPieceType.King, ChessPieceColor.Black)]
        [InlineData(8, 'F', ChessPieceType.Bishop, ChessPieceColor.Black)]
        [InlineData(8, 'G', ChessPieceType.Knight, ChessPieceColor.Black)]
        [InlineData(8, 'H', ChessPieceType.Rook, ChessPieceColor.Black)]
        public void GetPiecePosition(byte x, char y, ChessPieceType type, ChessPieceColor color)
        {
            ChessState state = new();
            ChessSquares square = new(x, y);

            var piece = state.GetPiecePosition(square);

            Assert.NotNull(piece);
            Assert.Equal(type, piece.Type);
            Assert.Equal(color, piece.Color);
        }

        [Theory]
        [InlineData(1, 'A', ChessPieceType.Rook, ChessPieceColor.White)]
        [InlineData(1, 'B', ChessPieceType.Knight, ChessPieceColor.White)]
        [InlineData(1, 'C', ChessPieceType.Bishop, ChessPieceColor.White)]
        [InlineData(1, 'D', ChessPieceType.Queen, ChessPieceColor.White)]
        [InlineData(1, 'E', ChessPieceType.King, ChessPieceColor.White)]
        [InlineData(1, 'F', ChessPieceType.Bishop, ChessPieceColor.White)]
        [InlineData(1, 'G', ChessPieceType.Knight, ChessPieceColor.White)]
        [InlineData(1, 'H', ChessPieceType.Rook, ChessPieceColor.White)]
        [InlineData(2, 'A', ChessPieceType.Pawn, ChessPieceColor.White)]
        [InlineData(2, 'B', ChessPieceType.Pawn, ChessPieceColor.White)]
        [InlineData(2, 'C', ChessPieceType.Pawn, ChessPieceColor.White)]
        [InlineData(2, 'D', ChessPieceType.Pawn, ChessPieceColor.White)]
        [InlineData(2, 'E', ChessPieceType.Pawn, ChessPieceColor.White)]
        [InlineData(2, 'F', ChessPieceType.Pawn, ChessPieceColor.White)]
        [InlineData(2, 'G', ChessPieceType.Pawn, ChessPieceColor.White)]
        [InlineData(2, 'H', ChessPieceType.Pawn, ChessPieceColor.White)]
        [InlineData(7, 'A', ChessPieceType.Pawn, ChessPieceColor.Black)]
        [InlineData(7, 'B', ChessPieceType.Pawn, ChessPieceColor.Black)]
        [InlineData(7, 'C', ChessPieceType.Pawn, ChessPieceColor.Black)]
        [InlineData(7, 'D', ChessPieceType.Pawn, ChessPieceColor.Black)]
        [InlineData(7, 'E', ChessPieceType.Pawn, ChessPieceColor.Black)]
        [InlineData(7, 'F', ChessPieceType.Pawn, ChessPieceColor.Black)]
        [InlineData(7, 'G', ChessPieceType.Pawn, ChessPieceColor.Black)]
        [InlineData(7, 'H', ChessPieceType.Pawn, ChessPieceColor.Black)]
        [InlineData(8, 'A', ChessPieceType.Rook, ChessPieceColor.Black)]
        [InlineData(8, 'B', ChessPieceType.Knight, ChessPieceColor.Black)]
        [InlineData(8, 'C', ChessPieceType.Bishop, ChessPieceColor.Black)]
        [InlineData(8, 'D', ChessPieceType.Queen, ChessPieceColor.Black)]
        [InlineData(8, 'E', ChessPieceType.King, ChessPieceColor.Black)]
        [InlineData(8, 'F', ChessPieceType.Bishop, ChessPieceColor.Black)]
        [InlineData(8, 'G', ChessPieceType.Knight, ChessPieceColor.Black)]
        [InlineData(8, 'H', ChessPieceType.Rook, ChessPieceColor.Black)]
        public void GetPieceAllPosition(byte x, char y, ChessPieceType type, ChessPieceColor color)
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
using LiteChat.Common.Events;
using LiteChat.Common.Events.Game.Chess;

namespace LiteChat.Common.Models.Games.Chess;

public class ChessState : GameState
{
    public ChessPlayer? WhitePlayer { get; private set; }
    public ChessPlayer? BlackPlayer { get; private set; }

    private readonly Dictionary<ChessSquares, ChessPiece> _pieces = DefaultPieces();

    public override void Apply(BasicEvent @event)
    {
        switch (@event)
        {
            case WhitePlayerJoinedEvent whitePlayerJoinedEvent:
                WhitePlayer = new ChessPlayer { UserId = whitePlayerJoinedEvent.UserId };
                break;

            case BlackPlayerJoinedEvent blackPlayerJoinedEvent:
                BlackPlayer = new ChessPlayer { UserId = blackPlayerJoinedEvent.UserId };
                break;

            case ChessPromotePawnEvent chessPromotePawnEvent:
                ChessPromotePawn(chessPromotePawnEvent);
                break;

            case ChessMoveEvent chessMoveEvent:
                MovePiece(chessMoveEvent);
                break;

            default:
                throw new ArgumentException();
        }

        base.Apply(@event);
    }

    private void ChessPromotePawn(ChessPromotePawnEvent @event)
    {
        if (!_pieces.TryGetValue(@event.From, out ChessPiece? piece) || piece is not ChessPawn pawn) return;

        _pieces.Remove(@event.From);
        _pieces[@event.To] = ChessPiece.PromotePiece(pawn, @event.PromoteTo);
    }

    public Player? PlayerTurn()
    {
        if (WhitePlayer is null || BlackPlayer is null) return null;
        return AllEvents.Count % 2 == 0 ? WhitePlayer : BlackPlayer;
    }

    public ChessPiecePosition[] GetPiecePositions() =>
        _pieces.Select(pair => new ChessPiecePosition(pair.Key, pair.Value)).ToArray();

    public ChessPiecePosition? GetPiecePosition(ChessSquares square) =>
        _pieces.TryGetValue(square, out var piece) ? new ChessPiecePosition(square, piece) : null;

    private void MovePiece(ChessMoveEvent @event)
    {
        if (!_pieces.TryGetValue(@event.From, out var piece)) return;

        _pieces.Remove(@event.From);
        _pieces[@event.To] = piece;
    }

    private static Dictionary<ChessSquares, ChessPiece> DefaultPieces()
    {
        List<KeyValuePair<ChessSquares, ChessPiece>> output = [
            .. GetDefaultWhitePawns(),
            .. GetDefaultWhitePieces(), 
            .. GetDefaultBlackPawns(), 
            .. GetDefaultBlackPieces()];

        return output.ToDictionary();
    }

    private static IEnumerable<KeyValuePair<ChessSquares, ChessPiece>> GetDefaultWhitePieces() =>
        ChessSquares.All1Squares.Select(square => square.Y switch
        {
            1 or 8 => new KeyValuePair<ChessSquares, ChessPiece>(square, ChessPiece.WhiteRook),
            2 or 7 => new KeyValuePair<ChessSquares, ChessPiece>(square, ChessPiece.WhiteKnight),
            3 or 6 => new KeyValuePair<ChessSquares, ChessPiece>(square, ChessPiece.WhiteBishop),
            4 => new KeyValuePair<ChessSquares, ChessPiece>(square, ChessPiece.WhiteQueen),
            5 => new KeyValuePair<ChessSquares, ChessPiece>(square, ChessPiece.WhiteKing),

            _ => throw new NotImplementedException(),
        });

    private static IEnumerable<KeyValuePair<ChessSquares, ChessPiece>> GetDefaultWhitePawns() => 
        ChessSquares.All2Squares.Select(square => new KeyValuePair<ChessSquares, ChessPiece>(square, ChessPiece.WhitePawn));

    private static IEnumerable<KeyValuePair<ChessSquares, ChessPiece>> GetDefaultBlackPawns() => 
        ChessSquares.All7Squares.Select(square => new KeyValuePair<ChessSquares, ChessPiece>(square, ChessPiece.BlackPawn));

    private static IEnumerable<KeyValuePair<ChessSquares, ChessPiece>> GetDefaultBlackPieces() =>
        ChessSquares.All8Squares.Select(square => square.Y switch
        {
            1 or 8 => new KeyValuePair<ChessSquares, ChessPiece>(square, ChessPiece.BlackRook),
            2 or 7 => new KeyValuePair<ChessSquares, ChessPiece>(square, ChessPiece.BlackKnight),
            3 or 6 => new KeyValuePair<ChessSquares, ChessPiece>(square, ChessPiece.BlackBishop),
            4 => new KeyValuePair<ChessSquares, ChessPiece>(square, ChessPiece.BlackQueen),
            5 => new KeyValuePair<ChessSquares, ChessPiece>(square, ChessPiece.BlackKing),

            _ => throw new NotImplementedException(),
        });
}

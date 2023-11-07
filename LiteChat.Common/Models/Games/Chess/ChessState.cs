using LiteChat.Common.Chess.Events;
using LiteChat.Common.Events;

namespace LiteChat.Common.Models.Games.Chess;

public class ChessState : GameState
{
    public ChessPlayer? WhitePlayer { get; private set; }
    public ChessPlayer? BlackPlayer { get; private set; }

    private readonly Dictionary<ChessSquares, ChessPiece> _pieces;

    public ChessState()
    {
        _pieces = DefaultPieces();
    }

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
        if (!_pieces.TryGetValue(@event.From, out ChessPiece piece)) return;

        _pieces.Remove(@event.From);
        _pieces[@event.To] = piece with { Type = @event.PromoteTo };
    }

    public Player? PlayerTurn()
    {
        if (WhitePlayer is null || BlackPlayer is null) return null;
        return _events.Count % 2 == 0 ? WhitePlayer : BlackPlayer;
    }

    public ChessPiecePosition[] GetPiecePositions() =>
        _pieces.Select(pair => new ChessPiecePosition(pair.Key, pair.Value.Type, pair.Value.Color)).ToArray();

    public ChessPiecePosition? GetPiecePosition(ChessSquares square) =>
        _pieces.TryGetValue(square, out ChessPiece? value) ? new ChessPiecePosition(square, value.Type, value.Color) : null;

    private void MovePiece(ChessMoveEvent @event)
    {
        if (!_pieces.TryGetValue(@event.From, out ChessPiece piece)) return;

        _pieces.Remove(@event.From);
        _pieces[@event.To] = piece;
    }

    private static Dictionary<ChessSquares, ChessPiece> DefaultPieces()
    {
        List<KeyValuePair<ChessSquares, ChessPiece>> output = [.. GetDefaultWhitePawns(), .. GetDefaultWhitePieces(), .. GetDefaultBlackPawns(), .. GetDefaultBlackPieces()];
        return output.ToDictionary();
    }

    private static IEnumerable<KeyValuePair<ChessSquares, ChessPiece>> GetDefaultWhitePieces() =>
        ChessSquares.All1Squares.Select(square => square.Y switch
        {
            1 or 8 => new KeyValuePair<ChessSquares, ChessPiece>(square, new ChessPiece(ChessPieceType.Rook, ChessPieceColor.White)),
            2 or 7 => new KeyValuePair<ChessSquares, ChessPiece>(square, new ChessPiece(ChessPieceType.Knight, ChessPieceColor.White)),
            3 or 6 => new KeyValuePair<ChessSquares, ChessPiece>(square, new ChessPiece(ChessPieceType.Bishop, ChessPieceColor.White)),
            4 => new KeyValuePair<ChessSquares, ChessPiece>(square, new ChessPiece(ChessPieceType.Queen, ChessPieceColor.White)),
            5 => new KeyValuePair<ChessSquares, ChessPiece>(square, new ChessPiece(ChessPieceType.King, ChessPieceColor.White)),

            _ => throw new NotImplementedException(),
        });

    private static IEnumerable<KeyValuePair<ChessSquares, ChessPiece>> GetDefaultWhitePawns() => 
        ChessSquares.All2Squares.Select(square => new KeyValuePair<ChessSquares, ChessPiece>(square, new ChessPiece(ChessPieceType.Pawn, ChessPieceColor.White)));

    private static IEnumerable<KeyValuePair<ChessSquares, ChessPiece>> GetDefaultBlackPawns() => 
        ChessSquares.All7Squares.Select(square => new KeyValuePair<ChessSquares, ChessPiece>(square, new ChessPiece(ChessPieceType.Pawn, ChessPieceColor.Black)));

    private static IEnumerable<KeyValuePair<ChessSquares, ChessPiece>> GetDefaultBlackPieces() =>
        ChessSquares.All8Squares.Select(square => square.Y switch
        {
            1 or 8 => new KeyValuePair<ChessSquares, ChessPiece>(square, new ChessPiece(ChessPieceType.Rook, ChessPieceColor.Black)),
            2 or 7 => new KeyValuePair<ChessSquares, ChessPiece>(square, new ChessPiece(ChessPieceType.Knight, ChessPieceColor.Black)),
            3 or 6 => new KeyValuePair<ChessSquares, ChessPiece>(square, new ChessPiece(ChessPieceType.Bishop, ChessPieceColor.Black)),
            4 => new KeyValuePair<ChessSquares, ChessPiece>(square, new ChessPiece(ChessPieceType.Queen, ChessPieceColor.Black)),
            5 => new KeyValuePair<ChessSquares, ChessPiece>(square, new ChessPiece(ChessPieceType.King, ChessPieceColor.Black)),

            _ => throw new NotImplementedException(),
        });
    
}

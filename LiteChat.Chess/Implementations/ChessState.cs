using LiteChat.Chess.Events;
using LiteChat.Chess.Models;
using LiteChat.Games.Events;
using LiteChat.Games.States;

namespace LiteChat.Chess.Implementations;

public class ChessState : GameState, IChessState
{
    public IChessPlayer? _whitePlayer { get; private set; }
    public IChessPlayer? _blackPlayer { get; private set; }

    private readonly Dictionary<ChessSquares, ChessPiece> _pieces;

    public ChessState()
    {
        _pieces = DefaultPieces();
    }

    public override void ApplyEvent(BaseEvent @event)
    {
        switch (@event)
        {
            case WhitePlayerJoinedEvent whitePlayerJoinedEvent:
                _whitePlayer = new ChessPlayer { UserId = whitePlayerJoinedEvent.UserId };
                break;

            case BlackPlayerJoinedEvent blackPlayerJoinedEvent:
                _blackPlayer = new ChessPlayer { UserId = blackPlayerJoinedEvent.UserId };
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

        base.ApplyEvent(@event);
    }

    private void ChessPromotePawn(ChessPromotePawnEvent @event)
    {
        if (!_pieces.TryGetValue(@event.From, out ChessPiece? piece) || piece.Type != @event.Piece.Type ||
            piece.Color != @event.Piece.Color) throw new ArgumentException();

        _pieces.Remove(@event.From);
        _pieces[@event.To] = piece with { Type = @event.PromoteTo };
    }

    public IPlayer? PlayerTurn()
    {
        if (_whitePlayer is null || _blackPlayer is null) return null;
        return _events.Count % 2 == 0 ? _whitePlayer : _blackPlayer;
    }

    public ChessPiecePosition[] GetPiecePositions() =>
        _pieces.Select(pair => new ChessPiecePosition(pair.Key, pair.Value.Type, pair.Value.Color)).ToArray();

    public ChessPiecePosition? GetPiecePosition(ChessSquares square) =>
        _pieces.TryGetValue(square, out ChessPiece? value) ? new ChessPiecePosition(square, value.Type, value.Color) : null;

    private void MovePiece(ChessMoveEvent @event)
    {
        if (!_pieces.TryGetValue(@event.From, out ChessPiece? piece) || piece.Type != @event.Piece.Type ||
            piece.Color != @event.Piece.Color) throw new ArgumentException();
        
        _pieces.Remove(@event.From);
        _pieces[@event.To] = piece;
    }

    private static Dictionary<ChessSquares, ChessPiece> DefaultPieces()
    {
        List<KeyValuePair<ChessSquares, ChessPiece>> output = [.. GetDefaultWhitePieces(), .. GetDefaultBlackPieces()];
        return output.ToDictionary();
    }

    private static IEnumerable<KeyValuePair<ChessSquares, ChessPiece>> GetDefaultWhitePieces() =>
        ChessSquares.All1Squares.Concat(ChessSquares.All2Squares).Select(square => square switch
        {
            (1, 1) or (1, 8) => new KeyValuePair<ChessSquares, ChessPiece>(square, new ChessPiece(ChessPieceType.Rook, ChessPieceColor.White)),
            (1, 2) or (1, 7) => new KeyValuePair<ChessSquares, ChessPiece>(square, new ChessPiece(ChessPieceType.Knight, ChessPieceColor.White)),
            (1, 3) or (1, 6) => new KeyValuePair<ChessSquares, ChessPiece>(square, new ChessPiece(ChessPieceType.Bishop, ChessPieceColor.White)),
            (1, 4) => new KeyValuePair<ChessSquares, ChessPiece>(square, new ChessPiece(ChessPieceType.Queen, ChessPieceColor.White)),
            (1, 5) => new KeyValuePair<ChessSquares, ChessPiece>(square, new ChessPiece(ChessPieceType.King, ChessPieceColor.White)),

            (2, 1) or (2, 2) or (2, 3) or (2, 4) or (2, 5) or (2, 6) or (2, 7) or (2, 8)
                => new KeyValuePair<ChessSquares, ChessPiece>(square, new ChessPiece(ChessPieceType.Pawn, ChessPieceColor.White)),

            _ => throw new NotImplementedException(),
        });

    private static IEnumerable<KeyValuePair<ChessSquares, ChessPiece>> GetDefaultBlackPieces() =>
        ChessSquares.All7Squares.Concat(ChessSquares.All8Squares).Select(square => square switch
        {
            (8, 1) or (8, 8) => new KeyValuePair<ChessSquares, ChessPiece>(square, new ChessPiece(ChessPieceType.Rook, ChessPieceColor.Black)),
            (8, 2) or (8, 7) => new KeyValuePair<ChessSquares, ChessPiece>(square, new ChessPiece(ChessPieceType.Knight, ChessPieceColor.Black)),
            (8, 3) or (8, 6) => new KeyValuePair<ChessSquares, ChessPiece>(square, new ChessPiece(ChessPieceType.Bishop, ChessPieceColor.Black)),
            (8, 4) => new KeyValuePair<ChessSquares, ChessPiece>(square, new ChessPiece(ChessPieceType.Queen, ChessPieceColor.Black)),
            (8, 5) => new KeyValuePair<ChessSquares, ChessPiece>(square, new ChessPiece(ChessPieceType.King, ChessPieceColor.Black)),

            (7, 1) or (7, 2) or (7, 3) or (7, 4) or (7, 5) or (7, 6) or (7, 7) or (7, 8)
                        => new KeyValuePair<ChessSquares, ChessPiece>(square, new ChessPiece(ChessPieceType.Pawn, ChessPieceColor.Black)),

            _ => throw new NotImplementedException(),
        });
}

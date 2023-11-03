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

            case ChessMoveEvent chessMoveEvent:
                MovePiece(chessMoveEvent);
                break;

            default:
                throw new ArgumentException();
        }

        base.ApplyEvent(@event);
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
            (1, 'A') or (1, 'H') => new KeyValuePair<ChessSquares, ChessPiece>(square, new ChessPiece(ChessPieceType.Rook, ChessPieceColor.White)),
            (1, 'B') or (1, 'G') => new KeyValuePair<ChessSquares, ChessPiece>(square, new ChessPiece(ChessPieceType.Knight, ChessPieceColor.White)),
            (1, 'C') or (1, 'F') => new KeyValuePair<ChessSquares, ChessPiece>(square, new ChessPiece(ChessPieceType.Bishop, ChessPieceColor.White)),
            (1, 'D') => new KeyValuePair<ChessSquares, ChessPiece>(square, new ChessPiece(ChessPieceType.Queen, ChessPieceColor.White)),
            (1, 'E') => new KeyValuePair<ChessSquares, ChessPiece>(square, new ChessPiece(ChessPieceType.King, ChessPieceColor.White)),

            (2, 'A') or (2, 'B') or (2, 'C') or (2, 'D') or (2, 'E') or (2, 'F') or (2, 'G') or (2, 'H')
                => new KeyValuePair<ChessSquares, ChessPiece>(square, new ChessPiece(ChessPieceType.Pawn, ChessPieceColor.White)),

            _ => throw new NotImplementedException(),
        });

    private static IEnumerable<KeyValuePair<ChessSquares, ChessPiece>> GetDefaultBlackPieces() =>
        ChessSquares.All7Squares.Concat(ChessSquares.All8Squares).Select(square => square switch
        {
            (8, 'A') or (8, 'H') => new KeyValuePair<ChessSquares, ChessPiece>(square, new ChessPiece(ChessPieceType.Rook, ChessPieceColor.Black)),
            (8, 'B') or (8, 'G') => new KeyValuePair<ChessSquares, ChessPiece>(square, new ChessPiece(ChessPieceType.Knight, ChessPieceColor.Black)),
            (8, 'C') or (8, 'F') => new KeyValuePair<ChessSquares, ChessPiece>(square, new ChessPiece(ChessPieceType.Bishop, ChessPieceColor.Black)),
            (8, 'D') => new KeyValuePair<ChessSquares, ChessPiece>(square, new ChessPiece(ChessPieceType.Queen, ChessPieceColor.Black)),
            (8, 'E') => new KeyValuePair<ChessSquares, ChessPiece>(square, new ChessPiece(ChessPieceType.King, ChessPieceColor.Black)),

            (7, 'A') or (7, 'B') or (7, 'C') or (7, 'D') or (7, 'E') or (7, 'F') or (7, 'G') or (7, 'H')
                        => new KeyValuePair<ChessSquares, ChessPiece>(square, new ChessPiece(ChessPieceType.Pawn, ChessPieceColor.Black)),

            _ => throw new NotImplementedException(),
        });
}

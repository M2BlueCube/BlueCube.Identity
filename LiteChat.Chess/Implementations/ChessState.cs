﻿using LiteChat.Chess.Events;
using LiteChat.Chess.Models;
using LiteChat.Games.Events;
using LiteChat.Games.States;

namespace LiteChat.Chess.Implementations;

public class ChessState : GameState, IChessState
{
    public IChessPlayer? _whitePlayer { get; private set; } = null;
    public IChessPlayer? _blackPlayer { get; private set; } = null;

    private Dictionary<ChessSquares, ChessPiece> _pieces = new Dictionary<ChessSquares, ChessPiece>();

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

    private static Dictionary<ChessSquares, ChessPiece> DefaultPieces()
    {
        List<KeyValuePair<ChessSquares, ChessPiece>> output = new();

        var whitePawns = ChessSquares.AllBSquares.Select(square =>
            new KeyValuePair<ChessSquares, ChessPiece>(square, new ChessPiece(ChessPieceType.Pawn, ChessPieceColor.White)));
        
        
        
        return output.ToDictionary();
    }

    private static IEnumerable<KeyValuePair<ChessSquares, ChessPiece>> GetDefaultWhitePieces()
    {
        ChessSquares.AllASquares.Concat(ChessSquares.AllBSquares).Select(square => square switch
        {
            
        })
    }
}

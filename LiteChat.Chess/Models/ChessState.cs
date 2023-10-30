using LiteChat.Games.Events;
using LiteChat.Games.States;

namespace LiteChat.Chess.Models;

public interface IChessState : IGameState
{
}

public class ChessState : GameState, IChessState
{
}

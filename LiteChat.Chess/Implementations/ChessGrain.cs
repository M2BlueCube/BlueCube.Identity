using LiteChat.Chess.Models;
using LiteChat.Games;
using LiteChat.Games.Commands;
using LiteChat.Games.Events;
using LiteChat.Games.States;
using Orleans;

namespace LiteChat.Chess.Implementations;

internal class ChessGrain : Grain, IChess
{
    
    public ValueTask<ChessState> GetState()
    {
        throw new NotImplementedException();
    }

    public Task HandelCommand(BaseCommand command)
    {
        throw new NotImplementedException();
    }

    public ValueTask<int> GetVersion()
    {
        throw new NotImplementedException();
    }

    ValueTask<IChessState> IGames<IChessState>.GetState()
    {
        throw new NotImplementedException();
    }

    public ValueTask<IPlayer[]> GetParticipants()
    {
        throw new NotImplementedException();
    }

    public ValueTask<BaseEvent[]> GetLatestEvents(int count = 50)
    {
        throw new NotImplementedException();
    }

    public ValueTask<BaseEvent[]> GetNextEvents(int id = 0, int count = 50)
    {
        throw new NotImplementedException();
    }

    public Task HandleCommand(BaseCommand command)
    {
        throw new NotImplementedException();
    }
}

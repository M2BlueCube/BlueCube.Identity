using LiteChat.Abstraction.Chess;
using LiteChat.Abstraction.Chess.Implementations;
using LiteChat.Abstraction.Game.Commands;
using LiteChat.Abstraction.Game.Events;
using LiteChat.Abstraction.Game.Models;
using LiteChat.Games;
using Orleans;

namespace LiteChat.Chess.Implementations;

internal class ChessGrain : Grain, IChess
{
    private ChessState _state = new();

    public override Task OnActivateAsync(CancellationToken cancellationToken)
    {
        return base.OnActivateAsync(cancellationToken);
    }

    public ValueTask<ChessState> GetState() => ValueTask.FromResult(_state);
    public ValueTask<int> GetVersion() => ValueTask.FromResult(_state.Version);

    
    public ValueTask<Player?[]> GetParticipants()
    {
        Player?[] players = new[] { _state.WhitePlayer, _state.BlackPlayer };
        return ValueTask.FromResult(players);
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
 
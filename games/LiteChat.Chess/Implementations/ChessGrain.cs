using LiteChat.Common.Chess.Implementations;
using LiteChat.Common.Commands;
using LiteChat.Common.Events;
using LiteChat.Common.Game.Models;
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
 
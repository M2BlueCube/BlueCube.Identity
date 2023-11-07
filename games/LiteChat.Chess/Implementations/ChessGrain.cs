using LiteChat.Common.Commands.Game;
using LiteChat.Common.Events.Game;
using LiteChat.Common.Models.Games;
using LiteChat.Common.Models.Games.Chess;
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

    public ValueTask<BasicGameEvent[]> GetLatestEvents(int count = 50)
    {
        throw new NotImplementedException();
    }

    public ValueTask<BasicGameEvent[]> GetNextEvents(int id = 0, int count = 50)
    {
        throw new NotImplementedException();
    }

    public Task HandleCommand(BasicGameCommand command)
    {
        throw new NotImplementedException();
    }
}
 
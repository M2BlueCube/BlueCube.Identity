using LiteChat.Common.Commands.Game;
using LiteChat.Common.Events.Game;
using LiteChat.Common.Models.Games;
using Orleans;

namespace LiteChat.Games;

public interface IGames<TGameState> : IGrainWithGuidKey where TGameState : GameState
{
    ValueTask<int> GetVersion();
    ValueTask<TGameState> GetState();
    ValueTask<Player?[]> GetParticipants();
    ValueTask<BasicGameEvent[]> GetLatestEvents(int count = 50);
    ValueTask<BasicGameEvent[]> GetNextEvents(int id = 0, int count = 50);
    
    Task HandleCommand(BasicGameCommand command);
}

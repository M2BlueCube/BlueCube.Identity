using LiteChat.Common.Commands;
using LiteChat.Common.Events;
using LiteChat.Common.Game.Models;
using Orleans;

namespace LiteChat.Games;

public interface IGames<TGameState> : IGrainWithGuidKey where TGameState : GameState
{
    ValueTask<int> GetVersion();
    ValueTask<TGameState> GetState();
    ValueTask<Player?[]> GetParticipants();
    ValueTask<BaseEvent[]> GetLatestEvents(int count = 50);
    ValueTask<BaseEvent[]> GetNextEvents(int id = 0, int count = 50);

    Task HandleCommand(BaseCommand command);
}

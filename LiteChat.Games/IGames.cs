using LiteChat.Games.Commands;
using LiteChat.Games.Events;
using LiteChat.Games.States;
using Orleans;

namespace LiteChat.Games;

public interface IGames<TGameState> : IGrainWithGuidKey where TGameState : IGameState
{
    ValueTask<int> GetVersion();
    ValueTask<TGameState> GetState();
    ValueTask<IPlayer[]> GetParticipants();
    ValueTask<BaseEvent[]> GetLatestEvents(int count = 50);
    ValueTask<BaseEvent[]> GetNextEvents(int id = 0, int count = 50);

    Task HandleCommand(BaseCommand command);
}

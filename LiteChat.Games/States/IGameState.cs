using LiteChat.Games.Events;

namespace LiteChat.Games.States;

public interface IGameState
{
    int Version { get; }
    void ApplyEvent(BaseEvent @event);
}

public abstract class GameState : IGameState
{
    protected readonly List<BaseEvent> events = [];

    public int Version => events.Count > 0 ? events.Last().Id : 0;
    public void ApplyEvent(BaseEvent @event) => events.Add(@event);
}


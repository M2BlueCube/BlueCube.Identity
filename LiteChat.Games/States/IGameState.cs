using LiteChat.Games.Events;

namespace LiteChat.Games.States;

public interface IGameState
{
    int Version { get; }
    void Apply(BaseEvent @event);
}

public abstract class GameState : IGameState
{
    protected readonly List<BaseEvent> _events = new();

    public int Version => _events.Count > 0 ? _events.Last().Id : 0;
    public virtual void Apply(BaseEvent @event) => _events.Add(@event);
}


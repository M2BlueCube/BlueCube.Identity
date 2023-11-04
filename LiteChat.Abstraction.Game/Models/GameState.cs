using LiteChat.Abstraction.Game.Events;

namespace LiteChat.Abstraction.Game.Models;

public abstract class GameState
{
    protected readonly List<BaseEvent> _events = new();

    public int Version => _events.Count > 0 ? _events.Last().Id : 0;
    public virtual void Apply(BaseEvent @event) => _events.Add(@event);
}


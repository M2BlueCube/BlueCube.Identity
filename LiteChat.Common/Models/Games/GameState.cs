using LiteChat.Common.Events;

namespace LiteChat.Common.Models.Games;

public abstract class GameState
{
    protected readonly List<BasicEvent> _events = new();

    public int Version => _events.Count > 0 ? _events.Last().Id : 0;
    public virtual void Apply(BasicEvent @event) => _events.Add(@event);
}


using LiteChat.Common.Events;

namespace LiteChat.Common.Models.Games;

public abstract class GameState
{
    protected readonly List<BasicEvent> AllEvents = new();

    public int Version => AllEvents.Count > 0 ? AllEvents.Last().Id : 0;
    public virtual void Apply(BasicEvent @event) => AllEvents.Add(@event);
}


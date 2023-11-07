namespace LiteChat.Common.Events.Game;

public enum Game { None, Chess, Mensch, Poker };


public abstract record BasicGameEvent : BasicEvent 
{
    public Guid GameId { get; init; }
}

public abstract record JoinGameEvent : BasicGameEvent
{
    public Guid UserId { get; init; }
}

public abstract record GameCreatedEvent : BasicGameEvent;


namespace LiteChat.Games.States;

public interface IPlayer
{
    Guid UserId { get; }
}

public abstract record Player : IPlayer
{
    public Guid UserId { get; init; }
}

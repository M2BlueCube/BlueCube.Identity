namespace LiteChat.Abstraction.Game.Models;

public abstract record Player
{
    public Guid UserId { get; init; }
}

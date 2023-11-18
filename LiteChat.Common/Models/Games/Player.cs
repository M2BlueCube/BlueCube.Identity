namespace LiteChat.Common.Models.Games;

public abstract record Player
{
    public Guid UserId { get; init; }
}

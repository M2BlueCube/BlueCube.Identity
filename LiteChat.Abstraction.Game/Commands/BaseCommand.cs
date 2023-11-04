namespace LiteChat.Abstraction.Game.Commands;

public abstract record BaseCommand
{
    public Guid UserId { get; init; }
}

namespace LiteChat.Games.Commands;

public abstract record BaseCommand
{
    public Guid UserId { get; init; }
}

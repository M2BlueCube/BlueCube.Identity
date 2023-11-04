namespace LiteChat.Common.Commands;

public abstract record BaseCommand
{
    public Guid UserId { get; init; }
}

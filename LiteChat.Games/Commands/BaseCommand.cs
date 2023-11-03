namespace LiteChat.Games.Commands;

public abstract record BaseCommand
{
    public Guid UserId { get; init; }
}

public record JoinToGameCommand: BaseCommand
{
}

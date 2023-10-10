namespace BlueCube.Models.Commands;

public interface IBaseCommand
{
    string UserId { get; init; }
    DateTimeOffset DateTime { get; init; }
}

public interface IChatCommand : IBaseCommand
{
    string ChatId { get; init; }
}


public abstract record BaseCommand : IBaseCommand
{
    public string UserId { get; init; } = string.Empty;
    public DateTimeOffset DateTime { get; init; } = DateTimeOffset.UtcNow;
}

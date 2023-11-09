namespace LiteChat.Common.Commands;

public abstract record BasicCommand
{
    public Guid UserId { get; init; }
    public DateTimeOffset TimeStamp { get; init; } = DateTimeOffset.UtcNow;
}

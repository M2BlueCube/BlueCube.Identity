namespace BlueCube.Models.Events;

public interface IBaseEvent
{
    long Id { get; init; }
    DateTimeOffset DateTime { get; init; }
}

public interface IUserEvent : IBaseEvent
{
    string UserId { get; init; }
}

public interface IChatEvent : IBaseEvent
{
    string ChatId { get; init; }
}

public abstract record BaseEvent : IBaseEvent
{
    public long Id { get; init; }
    public DateTimeOffset DateTime { get; init; } = DateTimeOffset.UtcNow;
}

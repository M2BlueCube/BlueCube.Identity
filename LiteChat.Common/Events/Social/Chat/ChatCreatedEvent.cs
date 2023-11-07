using System.Text.Json.Serialization;
namespace LiteChat.Common.Events.Social.Chat;

[JsonDerivedType(typeof(MessageSentEvent), nameof(MessageSentEvent))]
[JsonDerivedType(typeof(ChatCreatedEvent), nameof(ChatCreatedEvent))]
[JsonDerivedType(typeof(ChatDeletedEvent), nameof(ChatDeletedEvent))]
[JsonDerivedType(typeof(UserLeftChatEvent), nameof(UserLeftChatEvent))]
[JsonDerivedType(typeof(UserJoinedChatEvent), nameof(UserJoinedChatEvent))]
public abstract record BasicChatEvent : BasicEvent
{
    public Guid ChatId { get; init; }
}

public record ChatCreatedEvent : BasicChatEvent;

public record ChatDeletedEvent : BasicChatEvent;

public record UserJoinedChatEvent : BasicChatEvent
{
    public Guid UserId { get; init; }
    public string Key { get; init; } = string.Empty;
}

public record UserLeftChatEvent : BasicChatEvent
{
    public Guid UserId { get; init; }
}

public record MessageSentEvent : BasicChatEvent
{
    public Guid UserId { get; init; }
    public string Message { get; init; } = string.Empty;
}

namespace LiteChat.Common.Events.Social;

public enum Social { None, FriendRequested, FriendRequestApproved, FriendRequestRejected };

public abstract record BasicSocialEvent : BasicEvent
{
    public Guid UserId { get; init; }
}

public record FriendRequestedEvent : BasicSocialEvent
{
    public Guid FriendId { get; init; }
}



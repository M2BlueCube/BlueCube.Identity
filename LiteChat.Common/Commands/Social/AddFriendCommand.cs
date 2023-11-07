namespace LiteChat.Common.Commands.Social;

public record AddFriendCommand : BasicCommand
{
    public Guid FriendId { get; init; }
}

public record ApproveFriendRequestCommand: BasicCommand
{
    public int FriendRequestId { get; init; }
}

public record RejectFriendRequestCommand: BasicCommand
{
    public int FriendRequestId { get; init; }
}


using System.ComponentModel.DataAnnotations;
using System.Security.Cryptography;
using LiteChat.Extensions;

namespace LiteChat.Models;

public record ChatMessageDto(string To, int Latest, int Count, 
    //[Required, RegularExpression(KeyManagements.DateOnlyRegex)]
    string Date);

public record GetChatQuery
{
    [Required, MaxLength(63), RegularExpression(KeyManagements.GuidRegex)]
    public string To { get; init; } = string.Empty;

    public int Latest { get; init; } = 0;

    public int Count { get; init; } = 10;

    [Required, MaxLength(12)]//, RegularExpression(KeyManagements.DateOnlyRegex)]
    public string Date { get; init; } = string.Empty;
}

public record AppendChatMessage
{
    [Required, MaxLength(63), RegularExpression(KeyManagements.GuidRegex)]
    public string To { get; init; } = string.Empty;

    [Required, MaxLength(1023)] 
    public string Message { get; init; } = string.Empty;
}


[GenerateSerializer]
public abstract record EventDto(int Id, DateTime OccurredAt)
{
    public DateOnly Day => DateOnly.FromDateTime(OccurredAt);
}

[GenerateSerializer]
public record ChatMessageEventDto(int Id, Guid From, Guid To, Guid Chat, string Message, DateTime OccurredAt) : EventDto(Id, OccurredAt);

[GenerateSerializer] 
public abstract record CommandDto(Guid From, DateTime RequestedAt);

[GenerateSerializer]
public record AppendChatMessageCommandDto(Guid From, Guid To, string Message, DateTime RequestedAt) : CommandDto(From, RequestedAt);

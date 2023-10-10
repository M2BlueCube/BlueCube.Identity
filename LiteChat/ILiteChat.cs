using LiteChat.Models;

namespace LiteChat;

public interface ILiteChat : IGrainWithGuidKey
{
    ValueTask AppendChatMessage(AppendChatMessageCommandDto command);
    ValueTask<ChatMessageEventDto[]> GetChatMessages(int latest, int count, DateOnly date);
}
using LiteChat.Models;

namespace LiteChat.Implementations;

public sealed class LiteChatGrain : Grain, ILiteChat
{
    private readonly List<ChatMessageEventDto> _message = new();

    public override Task OnActivateAsync(CancellationToken cancellationToken)
    {
        DelayDeactivation(TimeSpan.FromDays(1));
        return base.OnActivateAsync(cancellationToken);
    }

    public ValueTask AppendChatMessage(AppendChatMessageCommandDto command)
    {
        var chatId = this.GetPrimaryKey();
        var date = DateOnly.FromDateTime(DateTime.UtcNow);

        var todaysMessage = _message.Where(m => m.Day == date);

        var maxId = todaysMessage.Any() ? todaysMessage.Max(x => x.Id) : 0;
        var message = new ChatMessageEventDto(maxId + 1, command.From, command.To, chatId, command.Message,
            DateTime.UtcNow);
        _message.Add(message);

        return ValueTask.CompletedTask;
    }

    public ValueTask<ChatMessageEventDto[]> GetChatMessages(int latest, int count, DateOnly date)
    {
        var messages = _message.Where(m => m.Day == date && m.Id > latest)
            .Take(count).ToArray();

        return ValueTask.FromResult(messages);
    }
}

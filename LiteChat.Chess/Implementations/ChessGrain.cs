using LiteChat.Chess.Models;
using LiteChat.Games;
using LiteChat.Games.Commands;
using LiteChat.Games.Events;
using LiteChat.Games.States;
using Orleans.EventSourcing;

namespace LiteChat.Chess.Implementations;

internal class ChessGrain : JournaledGrain<ChessState, BaseEvent>, IChess
{
    public override Task OnActivateAsync(CancellationToken cancellationToken)
    {
        return base.OnActivateAsync(cancellationToken);
    }

    protected override void RaiseEvent<TEvent>(TEvent @event)
    {
        base.RaiseEvent(@event);
    }

    protected override void RaiseEvents<TEvent>(IEnumerable<TEvent> events)
    {
        base.RaiseEvents(events);
    }

    protected override Task<bool> RaiseConditionalEvent<TEvent>(TEvent @event)
    {
        return base.RaiseConditionalEvent(@event);
    }

    protected override Task<bool> RaiseConditionalEvents<TEvent>(IEnumerable<TEvent> events)
    {
        return base.RaiseConditionalEvents(events);
    }


    public ValueTask<ChessState> GetState()
    {
        throw new NotImplementedException();
    }

    public Task HandelCommand(BaseCommand command)
    {
        throw new NotImplementedException();
    }

    public ValueTask<int> GetVersion()
    {
        throw new NotImplementedException();
    }

    ValueTask<IChessState> IGames<IChessState>.GetState()
    {
        throw new NotImplementedException();
    }

    public ValueTask<IPlayer[]> GetParticipants()
    {
        throw new NotImplementedException();
    }

    public ValueTask<BaseEvent[]> GetLatestEvents(int count = 50)
    {
        throw new NotImplementedException();
    }

    public ValueTask<BaseEvent[]> GetNextEvents(int id = 0, int count = 50)
    {
        throw new NotImplementedException();
    }

    public Task HandleCommand(BaseCommand command)
    {
        throw new NotImplementedException();
    }
}

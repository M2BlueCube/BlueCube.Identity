using LiteChat.Common.Commands.Game;
using LiteChat.Common.Commands.Game.Chess;
using LiteChat.Common.Events.Game;
using LiteChat.Common.Events.Game.Chess;
using LiteChat.Common.Models.Games;
using LiteChat.Common.Models.Games.Chess;
using Orleans;

namespace LiteChat.Chess.Implementations;

internal class ChessGrain : Grain, IChess
{
    private readonly ChessState _state = new();

    public override Task OnActivateAsync(CancellationToken cancellationToken)
    {
        return base.OnActivateAsync(cancellationToken);
    }

    public ValueTask<ChessState> GetState() => ValueTask.FromResult(_state);
    public ValueTask<int> GetVersion() => ValueTask.FromResult(_state.Version);

    
    public ValueTask<Player?[]> GetParticipants()
    {
        Player?[] players = new[] { _state.WhitePlayer, _state.BlackPlayer };
        return ValueTask.FromResult(players);
    }

    public ValueTask<BasicGameEvent[]> GetLatestEvents(int count = 50)
    {
        throw new NotImplementedException();
    }

    public ValueTask<BasicGameEvent[]> GetNextEvents(int id = 0, int count = 50)
    {
        throw new NotImplementedException();
    }

    public Task HandleCommand(BasicGameCommand command) =>
        command switch
        {
            JoinGameCommand joinGameCommand => HandleJoinGameCommand(joinGameCommand),
            MoveChessPieceCommand moveChessPieceCommand => HandleMoveChessPieceCommand(moveChessPieceCommand),
            _ => Task.CompletedTask
        };

    private Task HandleMoveChessPieceCommand(MoveChessPieceCommand moveChessPieceCommand)
    {
        var piece = _state.GetPiecePosition(moveChessPieceCommand.From);
        if (piece is null || piece.Type != moveChessPieceCommand.Piece) return Task.CompletedTask;



        throw new NotImplementedException();
    }

    private Task HandleJoinGameCommand(JoinGameCommand joinGameCommand) =>
        joinGameCommand.Color switch
        {
            ChessPieceColor.None => Task.CompletedTask,
            ChessPieceColor.White when _state.WhitePlayer is not null => Task.CompletedTask,
            ChessPieceColor.Black when _state.BlackPlayer is not null => Task.CompletedTask,
            ChessPieceColor.White => Apply(new WhitePlayerJoinedEvent { UserId = joinGameCommand.UserId }),
            ChessPieceColor.Black => Apply(new BlackPlayerJoinedEvent { UserId = joinGameCommand.UserId }),
            _ => Task.CompletedTask
        };

    public Task Apply(BasicGameEvent @event)
    {
        _state.Apply(@event);
        return Task.CompletedTask;
    }
}
 
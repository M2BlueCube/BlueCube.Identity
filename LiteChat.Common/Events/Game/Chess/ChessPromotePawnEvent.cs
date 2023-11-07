
using LiteChat.Common.Models.Games.Chess;

namespace LiteChat.Common.Chess.Events;

public record ChessPromotePawnEvent : ChessMoveEvent
{
    public ChessPieceType PromoteTo { get; init; }
}
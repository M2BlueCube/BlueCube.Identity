using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LiteChat.Common.Commands;

public abstract record BasicCommand
{
    public Guid UserId { get; init; }
    public DateTimeOffset TimeStamp { get; init; } = DateTimeOffset.UtcNow;
}

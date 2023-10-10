using System.ComponentModel.DataAnnotations;
using System.Security.Claims;
using LiteChat;
using LiteChat.Extensions;
using LiteChat.Models;
using Microsoft.AspNetCore.Mvc;

namespace BlueCube.Identity.Controllers;

[ApiController, Route("api/[controller]")]
public class LiteChatController : ControllerBase
{
    private readonly IClusterClient _client;

    public LiteChatController(IClusterClient client)
    {
        _client = client;
    }

    [HttpPost("GetMessages")]
    public async Task<ActionResult<ChatMessageEventDto[]>> GetMessages([Required, FromBody] GetChatQuery query)
    {
        var userId = HttpContext.User.Claims.Single(c => c.Type == ClaimTypes.NameIdentifier).Value;
        var chatId = KeyManagements.XorStringCalculation(userId, query.To);
        var grain = _client.GetGrain<ILiteChat>(chatId);

        var dateOnly = DateOnly.Parse(query.Date);
        var messages = await grain.GetChatMessages(query.Latest, query.Count, dateOnly);
        
        return Ok(messages);
    }

    [HttpPost("AppendMessage")]
    public async Task<IActionResult> AppendMessagesAsync([Required, FromBody] AppendChatMessage command)
    {
        var userId = HttpContext.User.Claims.Single(c => c.Type == ClaimTypes.NameIdentifier).Value;
        var chatId = KeyManagements.XorStringCalculation(userId, command.To);
        var to = Guid.Parse(command.To);
        var from = Guid.Parse(userId);

        var grain = _client.GetGrain<ILiteChat>(chatId);
        var appendCommand = new AppendChatMessageCommandDto(from, to, command.Message, DateTime.UtcNow);

        await grain.AppendChatMessage(appendCommand);
        return Ok();
    }
}
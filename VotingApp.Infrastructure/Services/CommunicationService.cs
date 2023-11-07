using System.Net.WebSockets;
using System.Text.Json;
using System.Text.Json.Serialization;
using VotingApp.Infrastructure.Managers;

namespace VotingApp.Infrastructure.Services;

internal class CommunicationService : ICommunicationService
{
    private readonly IWebSocketManager _webSocketManager;

    public CommunicationService(IWebSocketManager webSocketManager)
    {
        _webSocketManager = webSocketManager;
    }
    
    public async Task SendMessageToAllAsync(object message)
    {
        var sockets = _webSocketManager.GetAllSockets();
        var options = new JsonSerializerOptions
        {
            Converters = { new JsonStringEnumConverter() }
        };
        var serializedMessage = JsonSerializer.SerializeToUtf8Bytes(message, options);
        
        foreach (var socket in sockets)
        {
            await socket.SendAsync(serializedMessage, WebSocketMessageType.Text, true, CancellationToken.None);
        }
    }
}
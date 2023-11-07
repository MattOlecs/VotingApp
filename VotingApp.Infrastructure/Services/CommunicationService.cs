using System.Net.WebSockets;
using System.Text.Json;
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
        var serializedMessage = JsonSerializer.SerializeToUtf8Bytes(message);
        
        foreach (var socket in sockets)
        {
            await socket.SendAsync(serializedMessage, WebSocketMessageType.Text, true, CancellationToken.None);
        }
    }
}
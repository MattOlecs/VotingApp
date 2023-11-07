using System.Collections.Concurrent;
using System.Net.WebSockets;

namespace VotingApp.Infrastructure.Managers;

internal class WebSocketManager : IWebSocketManager
{
    private ConcurrentDictionary<Guid, WebSocket> _sockets = new();

    public Guid AddSocket(WebSocket socket)
    {
        Guid connectionId = Guid.NewGuid();
        _sockets.TryAdd(connectionId, socket);
        Console.WriteLine($"Add new websocket: {connectionId}");
        return connectionId;
    }

    public List<WebSocket> GetAllSockets() => _sockets.Values.Where(x => x.State == WebSocketState.Open).ToList();
}
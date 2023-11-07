using System.Net.WebSockets;

namespace VotingApp.Infrastructure.Managers;

internal interface IWebSocketManager
{
    Guid AddSocket(WebSocket socket);
    List<WebSocket> GetAllSockets();
}
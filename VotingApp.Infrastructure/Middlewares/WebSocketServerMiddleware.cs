using System.Net.WebSockets;
using System.Text;
using Microsoft.AspNetCore.Http;
using VotingApp.Infrastructure.Managers;

namespace VotingApp.Infrastructure.Middlewares;

internal class WebSocketServerMiddleware
{
    private readonly IWebSocketManager _webSocketManager;
    private readonly RequestDelegate _next;

    public WebSocketServerMiddleware(IWebSocketManager webSocketManager, RequestDelegate next)
    {
        _webSocketManager = webSocketManager;
        _next = next;
    }

    public async Task InvokeAsync(HttpContext context)
    {
        
        if (context.WebSockets.IsWebSocketRequest)
        {
            
            WebSocket webSocket = await context.WebSockets.AcceptWebSocketAsync();

            _webSocketManager.AddSocket(webSocket);
            Console.WriteLine("WebSocket Connected");

            await Receive(webSocket, async (result, buffer) =>
            {
                if (result.MessageType == WebSocketMessageType.Text)
                {
                    Console.WriteLine($"Received message: {Encoding.UTF8.GetString(buffer, 0, result.Count)}");
                    return;
                }

                if (result.MessageType == WebSocketMessageType.Close)
                {
                    Console.WriteLine($"Websocket connection closed");
                }
            });
        }
        else
        {
            await _next(context);
        }   
    }

    private async Task Receive(WebSocket socket, Action<WebSocketReceiveResult, byte[]> handleMessage)
    {
        var buffer = new byte[1024 * 4];

        while (socket.State == WebSocketState.Open)
        {
            var result = await socket.ReceiveAsync(buffer: new ArraySegment<byte>(buffer), cancellationToken: CancellationToken.None);

            handleMessage(result, buffer);
        }
    }
}
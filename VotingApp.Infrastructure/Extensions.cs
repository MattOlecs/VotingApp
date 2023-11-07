using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using VotingApp.Infrastructure.CQRS;
using VotingApp.Infrastructure.CQRS.Interfaces;
using VotingApp.Infrastructure.Managers;
using VotingApp.Infrastructure.Middlewares;
using VotingApp.Infrastructure.Services;

namespace VotingApp.Infrastructure;

public static class Extensions
{
    public static IServiceCollection RegisterCQRS(this IServiceCollection services)
    {
        return services
            .AddTransient<ICommandDispatcher, CommandDispatcher>()
            .AddTransient<IQueryDispatcher, QueryDispatcher>();
    }

    public static IServiceCollection RegisterWebSocketServices(this IServiceCollection services)
    {
        return services
            .AddTransient<ICommunicationService, CommunicationService>()
            .AddSingleton<IWebSocketManager, WebSocketManager>();
    }

    public static IApplicationBuilder AddVotingAppWebSockets(this IApplicationBuilder app)
    {
        return app
            .UseMiddleware<WebSocketServerMiddleware>();
    }
}
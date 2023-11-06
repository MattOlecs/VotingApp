using VotingApp.Infrastructure;
using VotingApp.Services;
using VotingApp.Services.Interfaces;

namespace VotingApp.Extensions;

internal static class ServicesExtensions
{
    public static IServiceCollection RegisterServices(this IServiceCollection services)
    {
        services
            .AddSingleton<IVotesService, VotesService>();

        services.RegisterCQRS();

        return services;
    }
}
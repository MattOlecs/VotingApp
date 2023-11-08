using VotingApp.CQRS.Commands.AddCandidateCommand;
using VotingApp.CQRS.Commands.AddVoterCommand;
using VotingApp.CQRS.Commands.VoteCommand;
using VotingApp.CQRS.Queries.GetCandidatesQuery;
using VotingApp.DTOs;
using VotingApp.Infrastructure;
using VotingApp.Infrastructure.CQRS.Interfaces;
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
        services.RegisterCommandHandlers();
        services.RegisterQueryHandlers();

        return services;
    }

    private static IServiceCollection RegisterCommandHandlers(this IServiceCollection services)
    {
        return services
            .AddTransient<ICommandHandler<AddVoterCommand, Guid>, AddVoterCommandHandler>()
            .AddTransient<ICommandHandler<AddCandidateCommand, Guid>, AddCandidateCommandHandler>()
            .AddTransient<ICommandHandler<VoteCommand>, VoteCommandHandler>();
    }
    
    private static IServiceCollection RegisterQueryHandlers(this IServiceCollection services)
    {
        return services
            .AddTransient<IQueryHandler<GetCandidatesQuery, ReadCandidateDto[]>, GetCandidatesQueryHandler>();
    }
}
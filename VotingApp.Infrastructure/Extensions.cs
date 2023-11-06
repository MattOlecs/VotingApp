﻿using Microsoft.Extensions.DependencyInjection;
using VotingApp.Infrastructure.CQRS;
using VotingApp.Infrastructure.CQRS.Interfaces;

namespace VotingApp.Infrastructure;

public static class Extensions
{
    public static IServiceCollection RegisterCQRS(this IServiceCollection services)
    {
        return services
            .AddSingleton<ICommandDispatcher, CommandDispatcher>()
            .AddSingleton<IQueryDispatcher, QueryDispatcher>();
    }
}
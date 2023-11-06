using Microsoft.Extensions.DependencyInjection;
using VotingApp.Infrastructure.CQRS.Interfaces;

namespace VotingApp.Infrastructure.CQRS;

internal class CommandDispatcher : ICommandDispatcher
{
    private readonly IServiceProvider _serviceProvider;

    public CommandDispatcher(IServiceProvider serviceProvider)
    {
        _serviceProvider = serviceProvider;
    }
    
    public async Task Dispatch<TCommand>(TCommand command) where TCommand : ICommand
    {
        var scope = _serviceProvider.CreateAsyncScope();
        var commandHandler = scope.ServiceProvider.GetRequiredService<ICommandHandler<TCommand>>();
        await commandHandler.Execute(command);
    }

    public async Task<TResult> Dispatch<TCommand, TResult>(TCommand command) where TCommand : ICommand<TResult>
    {
        var scope = _serviceProvider.CreateAsyncScope();
        var commandHandler = scope.ServiceProvider.GetRequiredService<ICommandHandler<TCommand, TResult>>();
        return await commandHandler.Execute(command);
    }
}
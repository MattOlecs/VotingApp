using VotingApp.Infrastructure.CQRS.Interfaces;
using VotingApp.Services.Interfaces;

namespace VotingApp.CQRS.Commands.AddVoteCommand;

public class AddVotingCommandHandler : ICommandHandler<AddVotingCommand, Guid>
{
    private readonly IVotesService _votesService;

    public AddVotingCommandHandler(IVotesService votesService)
    {
        _votesService = votesService;
    }
    
    public Task<Guid> Execute(AddVotingCommand command)
    {
        var newVotingGuid = _votesService.AddVoting();
        return Task.FromResult(newVotingGuid);
    }
}
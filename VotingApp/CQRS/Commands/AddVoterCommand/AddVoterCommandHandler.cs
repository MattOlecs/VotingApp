using VotingApp.Infrastructure.CQRS.Interfaces;
using VotingApp.Records;
using VotingApp.Services.Interfaces;

namespace VotingApp.CQRS.Commands.AddVoterCommand;

public class AddVoterCommandHandler : ICommandHandler<AddVoterCommand, Guid>
{
    private readonly IVotesService _votesService;

    public AddVoterCommandHandler(IVotesService votesService)
    {
        _votesService = votesService;
    }
    
    public Task<Guid> Execute(AddVoterCommand command)
    {
        var voterId = _votesService.AddVoter(command.VotingIdentifier, new Voter(command.Name));
        return Task.FromResult(voterId);
    }
}
using VotingApp.Infrastructure.CQRS.Interfaces;
using VotingApp.Services.Interfaces;

namespace VotingApp.CQRS.Commands.VoteCommand;

public class VoteCommandHandler : ICommandHandler<VoteCommand>
{
    private readonly IVotesService _votesService;

    public VoteCommandHandler(IVotesService votesService)
    {
        _votesService = votesService;
    }
    
    public Task Execute(VoteCommand command)
    {
        _votesService.Vote(command.VoterId, command.CandidateId);
        return Task.CompletedTask;
    }
}
using VotingApp.Infrastructure.CQRS.Interfaces;
using VotingApp.Records;
using VotingApp.Services.Interfaces;

namespace VotingApp.CQRS.Commands.AddCandidateCommand;

public class AddCandidateCommandHandler : ICommandHandler<AddCandidateCommand, Guid>
{
    private readonly IVotesService _votesService;

    public AddCandidateCommandHandler(IVotesService votesService)
    {
        _votesService = votesService;
    }
    
    public Task<Guid> Execute(AddCandidateCommand command)
    {
        var candidateId = _votesService.AddCandidate(command.VotingId, new Candidate(command.CandidateName));
        return Task.FromResult(candidateId);
    }
}
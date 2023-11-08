using VotingApp.DTOs;
using VotingApp.Infrastructure.CQRS.Interfaces;
using VotingApp.Services.Interfaces;

namespace VotingApp.CQRS.Queries.GetVotersQuery;

public class GetVotersQueryHandler : IQueryHandler<GetVotersQuery, ReadVoterDto[]>
{
    private readonly IVotesService _votesService;

    public GetVotersQueryHandler(IVotesService votesService)
    {
        _votesService = votesService;
    }
    
    public Task<ReadVoterDto[]> Handle(GetVotersQuery query)
    {
        var voters = _votesService.GetVoters()
            .Select(x => new ReadVoterDto(x.Key, x.Value.Name, x.Value.HasVoted))
            .ToArray();
        return Task.FromResult(voters);
    }
}
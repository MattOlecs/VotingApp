using VotingApp.DTOs;
using VotingApp.Infrastructure.CQRS.Interfaces;
using VotingApp.Services.Interfaces;

namespace VotingApp.CQRS.Queries.GetCandidatesQuery;

public class GetCandidatesQueryHandler : IQueryHandler<GetCandidatesQuery, ReadCandidateDto[]>
{
    private readonly IVotesService _votesService;

    public GetCandidatesQueryHandler(IVotesService votesService)
    {
        _votesService = votesService;
    }
    
    public Task<ReadCandidateDto[]> Handle(GetCandidatesQuery query)
    {
        var candidates = _votesService.GetCandidates()
            .Select(x => new ReadCandidateDto(x.Key, x.Value.Name, x.Value.Votes))
            .ToArray();
        return Task.FromResult(candidates);
    }
}
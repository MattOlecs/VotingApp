using VotingApp.Classes;
using VotingApp.Infrastructure.CQRS.Interfaces;
using VotingApp.Services.Interfaces;

namespace VotingApp.CQRS.Queries.GetVotingInfoQuery;

public class GetVotingInfoQueryHandler : IQueryHandler<GetVotingInfoQuery, VotingBaseInfo>
{
    private readonly IVotesService _votesService;

    public GetVotingInfoQueryHandler(IVotesService votesService)
    {
        _votesService = votesService;
    }
    
    public Task<VotingBaseInfo> Handle(GetVotingInfoQuery query)
    {
        var votingInfo = _votesService.GetVotingInfo(query.VotingId);
        return Task.FromResult(votingInfo);
    }
}
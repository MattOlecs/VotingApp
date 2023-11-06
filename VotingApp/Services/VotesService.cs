using System.Collections.Concurrent;
using VotingApp.Classes;
using VotingApp.Infrastructure.Exceptions;
using VotingApp.Records;
using VotingApp.Services.Interfaces;

namespace VotingApp.Services;

internal class VotesService : IVotesService
{
    private readonly ConcurrentDictionary<Guid, Voting> _votes = new();

    public Guid AddVoting()
    {
        var guid = Guid.NewGuid();
        _votes.TryAdd(guid, new Voting());
        return guid;
    }

    public Guid AddVoter(Guid votingId, Voter voter)
    {
        var voting = GetVoting(votingId);
        return voting.AddVoter(voter);
    }

    public Guid AddCandidate(Guid votingId, Candidate candidate)
    {
        var voting = GetVoting(votingId);
        return voting.AddCandidate(candidate);
    }

    public void Vote(Guid votingId, Guid voterId, Guid candidateId)
    {
        var voting = GetVoting(votingId);
        voting.Vote(voterId, candidateId);
    }

    public VotingBaseInfo GetVotingInfo(Guid votingId)
    {
        var voting = GetVoting(votingId);
        return new VotingBaseInfo(votingId, voting.GetVoters(), voting.GetCandidates());
    }

    private Voting GetVoting(Guid id)
    {
        _votes.TryGetValue(id, out Voting? voting);

        if (voting is null)
        {
            throw new NotFoundException("Voting not found");
        }

        return voting;
    }    
}
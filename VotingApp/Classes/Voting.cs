using VotingApp.Infrastructure.Exceptions;
using VotingApp.Records;

namespace VotingApp.Classes;

public class Voting
{
    private readonly Dictionary<Guid, Voter> _votersMap = new();
    private readonly Dictionary<Guid, Candidate> _candidatesMap = new();

    public Guid AddVoter(Voter voter)
    {
        var guid = Guid.NewGuid();
        _votersMap.TryAdd(guid, voter);
        return guid;
    }

    public Guid AddCandidate(Candidate candidate)
    {
        var guid = Guid.NewGuid();
        _candidatesMap.TryAdd(guid, candidate);
        return guid;
    }

    public void Vote(Guid voterId, Guid candidateId)
    {
        var voter = GetVoter(voterId);
        var candidate = GetCandidate(candidateId);

        if (voter.HasVoted)
        {
            throw new Exception($"$Voter: {voter.Name} has already voted");
        }
        
        candidate.AddVote();
        voter.MarkAsVoted();
    }

    public Dictionary<Guid, Voter> GetVoters() => _votersMap;
    public Dictionary<Guid, Candidate> GetCandidates() => _candidatesMap;

    private Voter GetVoter(Guid voterId)
    {
        _votersMap.TryGetValue(voterId, out Voter? voter);

        if (voter is null)
        {
            throw new NotFoundException($"Voter {voterId} not found");
        }

        return voter;
    }
    
    private Candidate GetCandidate(Guid candidateId)
    {
        _candidatesMap.TryGetValue(candidateId, out Candidate? candidate);

        if (candidate is null)
        {
            throw new NotFoundException($"Candidate {candidateId} not found");
        }

        return candidate;
    }
}
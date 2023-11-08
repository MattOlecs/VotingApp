using VotingApp.Classes;
using VotingApp.Records;
using VotingApp.Services.Interfaces;

namespace VotingApp.Services;

public class VotesService : IVotesService
{
    private Voting _voting = new();
    
    public Guid AddVoter(Voter voter)
    {
        return _voting.AddVoter(voter);
    }

    public Guid AddCandidate(Candidate candidate)
    {
        return _voting.AddCandidate(candidate);
    }

    public void Vote(Guid voterId, Guid candidateId)
    {
        _voting.Vote(voterId, candidateId);
    }

    public Dictionary<Guid, Voter> GetVoters()
    {
        return _voting.GetVoters();
    }

    public Dictionary<Guid, Candidate> GetCandidates()
    {
        return _voting.GetCandidates();
    }

    public void ResetVoting()
    {
        _voting = new Voting();
    }
}
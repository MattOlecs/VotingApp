using VotingApp.Records;

namespace VotingApp.Services.Interfaces;

public interface IVotesService
{
    Guid AddVoter(Voter voter);
    Guid AddCandidate(Candidate candidate);
    void Vote(Guid voterId, Guid candidateId);
    Dictionary<Guid, Voter> GetVoters();
    Dictionary<Guid, Candidate> GetCandidates();
    void ResetVoting();
}
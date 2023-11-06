using VotingApp.Classes;
using VotingApp.Records;

namespace VotingApp.Services.Interfaces;

public interface IVotesService
{
    Guid AddVoting();
    Guid AddVoter(Guid votingId, Voter voter);
    Guid AddCandidate(Guid votingId, Candidate candidate);
    void Vote(Guid votingId, Guid voterId, Guid candidateId);
    VotingBaseInfo GetVotingInfo(Guid votingId);
}
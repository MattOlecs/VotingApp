using VotingApp.Records;

namespace VotingApp.Classes;

public class VotingBaseInfo
{
    public VotingBaseInfo(Guid identifier, Dictionary<Guid, Voter> voters, Dictionary<Guid, Candidate> candidates)
    {
        Identifier = identifier;
        Voters = voters;
        Candidates = candidates;
    }

    public Guid Identifier { get; }
    public Dictionary<Guid, Voter> Voters { get; }
    public Dictionary<Guid, Candidate> Candidates { get; }
}
namespace VotingApp.Records;

public class Candidate
{
    public Candidate(string name)
    {
        Name = name;
    }

    public string Name { get; }
    public int Votes { get; private set; }

    public void AddVote() => Votes++;
}
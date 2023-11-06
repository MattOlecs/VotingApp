namespace VotingApp.Records;

public class Voter
{
    public Voter(string name)
    {
        Name = name;
        HasVoted = false;
    }

    public string Name { get; }
    public bool HasVoted { get; private set; }

    public void MarkAsVoted() => HasVoted = true;
}
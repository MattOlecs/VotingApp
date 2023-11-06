using System.Collections.Concurrent;
using VotingApp.Classes;
using VotingApp.Services.Interfaces;

namespace VotingApp.Services;

public class VotesService : IVotesService
{
    private readonly ConcurrentDictionary<Guid, Voting> _votes = new();

    public Guid AddVoting()
    {
        var guid = Guid.NewGuid();
        _votes.TryAdd(guid, new Voting());
        return guid;
    }
}
using FluentAssertions;
using VotingApp.Records;
using VotingApp.Services;
using VotingApp.Services.Interfaces;
using Xunit;

namespace VotingApp.Tests.CandidatesTests;

public class AddCandidateTests
{
    private void Act(Candidate voter) => _votesService.AddCandidate(voter);

    [Fact]
    public void new_voter_is_correctly_added_to_voting()
    {
        //Given
        Candidate newCandidate = new Candidate("Mateusz Oleksik");

        //When
        Act(newCandidate);

        //Then
        _votesService.GetVoters().Should().BeEmpty();
        _votesService.GetCandidates().Count.Should().Be(1);
        _votesService.GetCandidates().First().Value.Name.Should().Be(newCandidate.Name);
        _votesService.GetCandidates().First().Value.Votes.Should().Be(0);
    }
    
    [Fact]
    public void multiple_new_voters_are_correctly_added_to_voting()
    {
        //Given
        Candidate[] candidates = 
        {
            new Candidate("Mateusz Oleksik"),
            new Candidate("Jan Kowalski"), 
            new Candidate("John Smith")
        };

        //When
        foreach (var candidate in candidates)
        {
            Act(candidate);
        }

        //Then
        _votesService.GetVoters().Should().BeEmpty();
        _votesService.GetCandidates().Count.Should().Be(3);
    }
    
    #region Arrange

    private readonly IVotesService _votesService = new VotesService();

    #endregion
}
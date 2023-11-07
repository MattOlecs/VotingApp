using FluentAssertions;
using VotingApp.Records;
using VotingApp.Services;
using VotingApp.Services.Interfaces;
using Xunit;

namespace VotingApp.Tests.VotersTests;

public class AddVoterTests
{
    private void Act(Voter voter) => _votesService.AddVoter(voter);

    [Fact]
    public void new_voter_is_correctly_added_to_voting()
    {
        //Given
        Voter newVoter = new Voter("Mateusz Oleksik");

        //When
        Act(newVoter);

        //Then
        _votesService.GetCandidates().Should().BeEmpty();
        _votesService.GetVoters().Count.Should().Be(1);
        _votesService.GetVoters().First().Value.Name.Should().Be(newVoter.Name);
        _votesService.GetVoters().First().Value.HasVoted.Should().BeFalse();
    }
    
    [Fact]
    public void multiple_new_voters_are_correctly_added_to_voting()
    {
        //Given
        Voter[] voters = 
        {
            new Voter("Mateusz Oleksik"),
            new Voter("Jan Kowalski"), 
            new Voter("John Smith")
        };

        //When
        foreach (var voter in voters)
        {
            Act(voter);
        }

        //Then
        _votesService.GetCandidates().Should().BeEmpty();
        _votesService.GetVoters().Count.Should().Be(3);
    }
    
    #region Arrange

    private readonly IVotesService _votesService = new VotesService();

    #endregion
}
using FluentAssertions;
using VotingApp.Classes;
using VotingApp.Records;
using VotingApp.Services;
using VotingApp.Services.Interfaces;
using Xunit;

namespace VotingApp.Tests.VotingTests;

public class ResetVotingTests
{
    private void Act() => _votesService.ResetVoting();

    [Fact]
    public void voting_reset_properly_clears_all_properties()
    {
        //Given
        _votesService.AddVoter(new Voter("Mateusz"));
        _votesService.AddVoter(new Voter("John"));

        _votesService.AddCandidate(new Candidate("Joe"));
        _votesService.AddCandidate(new Candidate("Peter"));
        
        //When
        Act();
        
        //Then
        _votesService.GetVoters().Should().BeEmpty();
        _votesService.GetCandidates().Should().BeEmpty();
    }
    
    #region Arrange

    private readonly IVotesService _votesService = new VotesService();

    #endregion
}
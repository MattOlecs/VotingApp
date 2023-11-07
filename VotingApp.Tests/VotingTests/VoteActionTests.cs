using FluentAssertions;
using VotingApp.Records;
using VotingApp.Services;
using VotingApp.Services.Interfaces;
using Xunit;

namespace VotingApp.Tests.VotingTests;

public class VoteActionTests
{
    private void Act(Guid voterId, Guid candidateId) => _votesService.Vote(voterId, candidateId);

    [Fact]
    public void voting_action_changes_voter_and_candidate_properties_correctly()
    {
        //Given
        var voterId = _votesService.AddVoter(new Voter("Mateusz Oleksik"));
        var candidateId = _votesService.AddCandidate(new Candidate("John Smith"));

        //When
        Act(voterId, candidateId);
        
        //Then
        var voter = _votesService.GetVoters()[voterId];
        var candidate = _votesService.GetCandidates()[candidateId];
        voter.HasVoted.Should().BeTrue();
        candidate.Votes.Should().Be(1);
    }
    
    [Fact]
    public void voting_action_changes_single_voter_and_single_candidate_properties_correctly()
    {
        //Given
        _votesService.AddVoter(new Voter("Jan Kowalski"));
        _votesService.AddCandidate(new Candidate("Keanu Reeves"));
        
        var voterId = _votesService.AddVoter(new Voter("Mateusz Oleksik"));
        var candidateId = _votesService.AddCandidate(new Candidate("John Smith"));
        
        //When
        Act(voterId, candidateId);
        
        //Then
        var voter = _votesService.GetVoters()[voterId];
        var candidate = _votesService.GetCandidates()[candidateId];
        voter.HasVoted.Should().BeTrue();
        candidate.Votes.Should().Be(1);
    }
    
    #region Arrange

    private readonly IVotesService _votesService = new VotesService();

    #endregion
}
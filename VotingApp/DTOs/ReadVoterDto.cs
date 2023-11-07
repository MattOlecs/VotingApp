namespace VotingApp.DTOs;

public record ReadVoterDto(Guid Id, string Name, bool HasVoted);
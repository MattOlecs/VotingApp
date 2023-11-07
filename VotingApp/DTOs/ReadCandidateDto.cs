namespace VotingApp.DTOs;

public record ReadCandidateDto(Guid Id, string Name, int Votes);
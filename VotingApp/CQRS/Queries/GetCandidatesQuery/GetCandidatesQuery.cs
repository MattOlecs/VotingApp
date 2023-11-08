using VotingApp.DTOs;
using VotingApp.Infrastructure.CQRS.Interfaces;

namespace VotingApp.CQRS.Queries.GetCandidatesQuery;

public record GetCandidatesQuery : IQuery<ReadCandidateDto[]>;
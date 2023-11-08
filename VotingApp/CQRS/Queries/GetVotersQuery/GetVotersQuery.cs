using VotingApp.DTOs;
using VotingApp.Infrastructure.CQRS.Interfaces;

namespace VotingApp.CQRS.Queries.GetVotersQuery;

public record GetVotersQuery : IQuery<ReadVoterDto[]>;
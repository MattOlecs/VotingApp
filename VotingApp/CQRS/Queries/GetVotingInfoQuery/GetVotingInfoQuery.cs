using VotingApp.Classes;
using VotingApp.Infrastructure.CQRS.Interfaces;

namespace VotingApp.CQRS.Queries.GetVotingInfoQuery;

public record GetVotingInfoQuery(Guid VotingId) : IQuery<VotingBaseInfo>;

using VotingApp.Infrastructure.CQRS.Interfaces;

namespace VotingApp.CQRS.Commands.VoteCommand;

public record VoteCommand(Guid VotingId, Guid VoterId, Guid CandidateId) : ICommand;
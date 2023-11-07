
using VotingApp.Infrastructure.CQRS.Interfaces;

namespace VotingApp.CQRS.Commands.VoteCommand;

public record VoteCommand(Guid VoterId, Guid CandidateId) : ICommand;
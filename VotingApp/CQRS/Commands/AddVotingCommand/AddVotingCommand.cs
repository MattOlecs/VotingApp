using VotingApp.Infrastructure.CQRS.Interfaces;

namespace VotingApp.CQRS.Commands.AddVoteCommand;

public record AddVotingCommand() : ICommand<Guid>;
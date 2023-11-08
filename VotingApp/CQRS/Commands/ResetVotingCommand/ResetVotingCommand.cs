using VotingApp.Infrastructure.CQRS.Interfaces;

namespace VotingApp.CQRS.Commands.ResetVotingCommand;

public record ResetVotingCommand() : ICommand;
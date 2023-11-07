using VotingApp.Infrastructure.CQRS.Interfaces;

namespace VotingApp.CQRS.Commands.AddVoterCommand;

public record AddVoterCommand(string Name) : ICommand<Guid>;
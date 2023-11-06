using VotingApp.Infrastructure.CQRS.Interfaces;

namespace VotingApp.CQRS.Commands.AddVoterCommand;

public record AddVoterCommand(Guid VotingIdentifier, string Name) : ICommand<Guid>;
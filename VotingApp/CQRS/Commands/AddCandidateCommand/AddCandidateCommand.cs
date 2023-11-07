using VotingApp.Infrastructure.CQRS.Interfaces;

namespace VotingApp.CQRS.Commands.AddCandidateCommand;

public record AddCandidateCommand(string CandidateName) : ICommand<Guid>;
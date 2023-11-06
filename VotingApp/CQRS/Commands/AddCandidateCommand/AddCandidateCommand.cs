using VotingApp.Infrastructure.CQRS.Interfaces;

namespace VotingApp.CQRS.Commands.AddCandidateCommand;

public record AddCandidateCommand(Guid VotingId, string CandidateName) : ICommand<Guid>;
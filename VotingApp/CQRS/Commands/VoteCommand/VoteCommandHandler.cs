using VotingApp.Infrastructure.CQRS.Interfaces;
using VotingApp.Infrastructure.Services;
using VotingApp.Infrastructure.WebSocketMessages;
using VotingApp.Services.Interfaces;

namespace VotingApp.CQRS.Commands.VoteCommand;

public class VoteCommandHandler : ICommandHandler<VoteCommand>
{
    private readonly IVotesService _votesService;
    private readonly ICommunicationService _communicationService;

    public VoteCommandHandler(IVotesService votesService, ICommunicationService communicationService)
    {
        _votesService = votesService;
        _communicationService = communicationService;
    }
    
    public Task Execute(VoteCommand command)
    {
        _votesService.Vote(command.VoterId, command.CandidateId);
        _communicationService.SendMessageToAllAsync(RefreshMessage.RefreshAll);
        return Task.CompletedTask;
    }
}
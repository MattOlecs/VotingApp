using VotingApp.Infrastructure.CQRS.Interfaces;
using VotingApp.Infrastructure.Services;
using VotingApp.Infrastructure.WebSocketMessages;
using VotingApp.Services.Interfaces;

namespace VotingApp.CQRS.Commands.ResetVotingCommand;

public class ResetVotingCommandHandler : ICommandHandler<ResetVotingCommand>
{
    private readonly IVotesService _votesService;
    private readonly ICommunicationService _communicationService;

    public ResetVotingCommandHandler(
        IVotesService votesService,
        ICommunicationService communicationService)
    {
        _votesService = votesService;
        _communicationService = communicationService;
    }
    
    public async Task Execute(ResetVotingCommand command)
    {
        _votesService.ResetVoting();
        await _communicationService.SendMessageToAllAsync(RefreshMessage.RefreshAll);
    }
}
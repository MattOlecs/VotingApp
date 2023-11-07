using VotingApp.Infrastructure.CQRS.Interfaces;
using VotingApp.Infrastructure.Services;
using VotingApp.Infrastructure.WebSocketMessages;
using VotingApp.Records;
using VotingApp.Services.Interfaces;

namespace VotingApp.CQRS.Commands.AddVoterCommand;

public class AddVoterCommandHandler : ICommandHandler<AddVoterCommand, Guid>
{
    private readonly IVotesService _votesService;
    private readonly ICommunicationService _communicationService;

    public AddVoterCommandHandler(
        IVotesService votesService,
        ICommunicationService communicationService)
    {
        _votesService = votesService;
        _communicationService = communicationService;
    }
    
    public async Task<Guid> Execute(AddVoterCommand command)
    {
        var voterId = _votesService.AddVoter(command.VotingIdentifier, new Voter(command.Name));
        await _communicationService.SendMessageToAllAsync(RefreshMessage.RefreshVoters);
        return voterId;
    }
}
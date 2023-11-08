using Moq;
using VotingApp.CQRS.Commands.VoteCommand;
using VotingApp.Infrastructure.Services;
using VotingApp.Infrastructure.WebSocketMessages;
using VotingApp.Records;
using VotingApp.Services;
using VotingApp.Services.Interfaces;
using Xunit;

namespace VotingApp.IntegrationTests.CommandHandlers;

public class VoteCommandHandlerTests
{
    private async Task Act() => await _commandHandler.Execute(_command);

    [Fact]
    public async Task when_user_voted_message_to_refresh_all_is_send()
    {
        //When
        await Act();
 
        //Then
        _communicationServiceMock.Verify(x => 
                x.SendMessageToAllAsync(
                    It.Is<RefreshMessage>(m => m.MessageType == MessageType.RefreshAll)), 
            Times.Once);
    }
    
    #region arrange
    
    private readonly Mock<ICommunicationService> _communicationServiceMock;
    private readonly VoteCommandHandler _commandHandler;
    private readonly VoteCommand _command;

    public VoteCommandHandlerTests()
    {
        IVotesService votesService = new VotesService();
        _communicationServiceMock = new Mock<ICommunicationService>();
        _commandHandler = new VoteCommandHandler(votesService, _communicationServiceMock.Object);
        
        var voterId = votesService.AddVoter(new Voter("Mateusz"));
        var candidateId = votesService.AddCandidate(new Candidate("John"));
        _command = new VoteCommand(voterId, candidateId);
    }

    #endregion
}
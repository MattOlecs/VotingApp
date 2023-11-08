using Moq;
using VotingApp.CQRS.Commands.ResetVotingCommand;
using VotingApp.Infrastructure.Services;
using VotingApp.Infrastructure.WebSocketMessages;
using VotingApp.Services;
using VotingApp.Services.Interfaces;
using Xunit;

namespace VotingApp.IntegrationTests.CommandHandlers;

public class ResetVotingCommandHandlerTests
{
    private async Task Act() => await _commandHandler.Execute(new ResetVotingCommand());

    [Fact]
    public async Task when_voting_is_reset_message_to_refresh_all_is_send()
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
    private readonly ResetVotingCommandHandler _commandHandler;

    public ResetVotingCommandHandlerTests()
    {
        IVotesService votesService = new VotesService();
        _communicationServiceMock = new Mock<ICommunicationService>();
        _commandHandler = new ResetVotingCommandHandler(votesService, _communicationServiceMock.Object);
    }

    #endregion
}
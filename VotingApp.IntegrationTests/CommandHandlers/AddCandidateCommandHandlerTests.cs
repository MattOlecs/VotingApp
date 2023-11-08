using Moq;
using VotingApp.CQRS.Commands.AddCandidateCommand;
using VotingApp.Infrastructure.Services;
using VotingApp.Infrastructure.WebSocketMessages;
using VotingApp.Services;
using VotingApp.Services.Interfaces;
using Xunit;

namespace VotingApp.IntegrationTests.CommandHandlers;

public class AddCandidateCommandHandlerTests
{
    private async Task Act() => await _commandHandler.Execute(new AddCandidateCommand("Mateusz"));

    [Fact]
    public async Task when_candidate_is_added_message_to_refresh_candidates_is_send()
    {
        //When
        await Act();
 
        //Then
        _communicationServiceMock.Verify(x => 
            x.SendMessageToAllAsync(
                It.Is<RefreshMessage>(m => m.MessageType == MessageType.RefreshCandidates)), 
            Times.Once);
    }
    
    #region arrange
    
    private readonly Mock<ICommunicationService> _communicationServiceMock;
    private readonly AddCandidateCommandHandler _commandHandler;

    public AddCandidateCommandHandlerTests()
    {
        IVotesService votesService = new VotesService();
        _communicationServiceMock = new Mock<ICommunicationService>();
        _commandHandler = new AddCandidateCommandHandler(votesService, _communicationServiceMock.Object);
    }

    #endregion
}
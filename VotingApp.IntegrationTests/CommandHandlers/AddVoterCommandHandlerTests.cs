using Moq;
using VotingApp.CQRS.Commands.AddCandidateCommand;
using VotingApp.CQRS.Commands.AddVoterCommand;
using VotingApp.Infrastructure.Services;
using VotingApp.Infrastructure.WebSocketMessages;
using VotingApp.Services;
using VotingApp.Services.Interfaces;
using Xunit;

namespace VotingApp.IntegrationTests.CommandHandlers;

public class AddVoterCommandHandlerTests
{
    private async Task Act() => await _commandHandler.Execute(new AddVoterCommand("John"));

    [Fact]
    public async Task when_voter_is_added_message_to_refresh_voters_is_send()
    {
        //When
        await Act();
 
        //Then
        _communicationServiceMock.Verify(x => 
                x.SendMessageToAllAsync(
                    It.Is<RefreshMessage>(m => m.MessageType == MessageType.RefreshVoters)), 
            Times.Once);
    }
    
    #region arrange
    
    private readonly Mock<ICommunicationService> _communicationServiceMock;
    private readonly AddVoterCommandHandler _commandHandler;

    public AddVoterCommandHandlerTests()
    {
        IVotesService votesService = new VotesService();
        _communicationServiceMock = new Mock<ICommunicationService>();
        _commandHandler = new AddVoterCommandHandler(votesService, _communicationServiceMock.Object);
    }

    #endregion
}
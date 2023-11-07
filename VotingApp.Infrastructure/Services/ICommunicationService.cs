namespace VotingApp.Infrastructure.Services;

public interface ICommunicationService
{
    Task SendMessageToAllAsync(object message);
}
namespace VotingApp.Infrastructure.WebSocketMessages;

public class RefreshMessage
{
    private RefreshMessage(MessageType messageType)
    {
        MessageType = messageType;
    }

    public MessageType MessageType { get; }

    public static RefreshMessage RefreshVoters => new RefreshMessage(MessageType.RefreshVoters);
    public static RefreshMessage RefreshCandidates => new RefreshMessage(MessageType.RefreshCandidates);
    public static RefreshMessage RefreshAll => new RefreshMessage(MessageType.RefreshAll);
}
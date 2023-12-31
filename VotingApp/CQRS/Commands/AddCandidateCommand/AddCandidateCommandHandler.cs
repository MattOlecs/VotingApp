﻿using VotingApp.Infrastructure.CQRS.Interfaces;
using VotingApp.Infrastructure.Services;
using VotingApp.Infrastructure.WebSocketMessages;
using VotingApp.Records;
using VotingApp.Services.Interfaces;

namespace VotingApp.CQRS.Commands.AddCandidateCommand;

public class AddCandidateCommandHandler : ICommandHandler<AddCandidateCommand, Guid>
{
    private readonly IVotesService _votesService;
    private readonly ICommunicationService _communicationService;

    public AddCandidateCommandHandler(
        IVotesService votesService,
        ICommunicationService communicationService)
    {
        _votesService = votesService;
        _communicationService = communicationService;
    }
    
    public async Task<Guid> Execute(AddCandidateCommand command)
    {
        var candidateId = _votesService.AddCandidate(new Candidate(command.CandidateName));
        await _communicationService.SendMessageToAllAsync(RefreshMessage.RefreshCandidates);
        return candidateId;
    }
}
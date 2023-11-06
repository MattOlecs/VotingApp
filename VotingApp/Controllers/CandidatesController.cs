using Microsoft.AspNetCore.Mvc;
using VotingApp.CQRS.Commands.AddCandidateCommand;
using VotingApp.DTOs;
using VotingApp.Infrastructure.CQRS.Interfaces;

namespace VotingApp.Controllers;

public class CandidatesController : AbstractController
{
    private readonly ICommandDispatcher _commandDispatcher;

    public CandidatesController(ICommandDispatcher commandDispatcher)
    {
        _commandDispatcher = commandDispatcher;
    }
    
    [HttpPost("candidate")]
    public async Task<Guid> AddCandidate([FromBody] AddCandidateDto addCandidateDto)
    {
        return await _commandDispatcher.Dispatch<AddCandidateCommand, Guid>(
            new AddCandidateCommand(addCandidateDto.VotingId, addCandidateDto.CandidateName));
    }
}
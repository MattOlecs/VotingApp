using Microsoft.AspNetCore.Mvc;
using VotingApp.CQRS.Commands.AddVoterCommand;
using VotingApp.DTOs;
using VotingApp.Infrastructure.CQRS.Interfaces;

namespace VotingApp.Controllers;

public class VotersController : AbstractController
{
    private readonly ICommandDispatcher _commandDispatcher;

    public VotersController(ICommandDispatcher commandDispatcher)
    {
        _commandDispatcher = commandDispatcher;
    }
    
    [HttpPost("candidate")]
    public async Task<Guid> AddVoter([FromBody] AddVoterDto addVoterDto)
    {
        return await _commandDispatcher.Dispatch<AddVoterCommand, Guid>(
            new AddVoterCommand(addVoterDto.VotingId, addVoterDto.VoterName));
    }
}
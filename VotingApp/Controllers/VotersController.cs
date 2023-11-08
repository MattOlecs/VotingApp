using Microsoft.AspNetCore.Mvc;
using VotingApp.CQRS.Commands.AddVoterCommand;
using VotingApp.CQRS.Queries.GetVotersQuery;
using VotingApp.DTOs;
using VotingApp.Infrastructure.CQRS.Interfaces;

namespace VotingApp.Controllers;

public class VotersController : AbstractController
{
    private readonly ICommandDispatcher _commandDispatcher;
    private readonly IQueryDispatcher _queryDispatcher;

    public VotersController(
        ICommandDispatcher commandDispatcher, 
        IQueryDispatcher queryDispatcher)
    {
        _commandDispatcher = commandDispatcher;
        _queryDispatcher = queryDispatcher;
    }
    
    [HttpGet]
    public async Task<ReadVoterDto[]> GetVoters()
    {
        return await _queryDispatcher.Dispatch<GetVotersQuery, ReadVoterDto[]>(new GetVotersQuery());
    }
    
    [HttpPost("voter")]
    public async Task<Guid> AddVoter([FromBody] AddVoterDto addVoterDto)
    {
        return await _commandDispatcher.Dispatch<AddVoterCommand, Guid>(
            new AddVoterCommand(addVoterDto.Name));
    }
}
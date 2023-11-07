using Microsoft.AspNetCore.Mvc;
using VotingApp.CQRS.Commands.AddVoterCommand;
using VotingApp.DTOs;
using VotingApp.Infrastructure.CQRS.Interfaces;
using VotingApp.Records;
using VotingApp.Services.Interfaces;

namespace VotingApp.Controllers;

public class VotersController : AbstractController
{
    private readonly ICommandDispatcher _commandDispatcher;
    private readonly IVotesService _votesService;

    public VotersController(ICommandDispatcher commandDispatcher, IVotesService votesService)
    {
        _commandDispatcher = commandDispatcher;
        _votesService = votesService;
    }
    
    [HttpGet]
    public Task<ReadVoterDto[]> GetVoters()
    {
        var voters = _votesService.GetVoters()
            .Select(x => new ReadVoterDto(x.Key, x.Value.Name, x.Value.HasVoted))
            .ToArray();
        return Task.FromResult(voters);
    }
    
    [HttpPost("voter")]
    public async Task<Guid> AddVoter([FromBody] AddVoterDto addVoterDto)
    {
        return await _commandDispatcher.Dispatch<AddVoterCommand, Guid>(
            new AddVoterCommand(addVoterDto.Name));
    }
}
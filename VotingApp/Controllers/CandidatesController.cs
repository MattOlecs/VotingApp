using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using VotingApp.CQRS.Commands.AddCandidateCommand;
using VotingApp.DTOs;
using VotingApp.Infrastructure.CQRS.Interfaces;
using VotingApp.Records;
using VotingApp.Services.Interfaces;

namespace VotingApp.Controllers;

public class CandidatesController : AbstractController
{
    private readonly ICommandDispatcher _commandDispatcher;
    private readonly IVotesService _votesService;

    public CandidatesController(ICommandDispatcher commandDispatcher, IVotesService votesService)
    {
        _commandDispatcher = commandDispatcher;
        _votesService = votesService;
    }

    [HttpGet]
    public Task<ReadCandidateDto[]> GetCandidates()
    {
        var candidates = _votesService.GetCandidates()
            .Select(x => new ReadCandidateDto(x.Key, x.Value.Name, x.Value.Votes))
            .ToArray();
        return Task.FromResult(candidates);
    }
    
    [HttpPost("candidate")]
    public async Task<Guid> AddCandidate([FromBody] AddCandidateDto addCandidateDto)
    {
        return await _commandDispatcher.Dispatch<AddCandidateCommand, Guid>(
            new AddCandidateCommand(addCandidateDto.Name));
    }
}
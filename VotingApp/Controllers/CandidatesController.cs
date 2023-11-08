using Microsoft.AspNetCore.Mvc;
using VotingApp.CQRS.Commands.AddCandidateCommand;
using VotingApp.CQRS.Queries.GetCandidatesQuery;
using VotingApp.DTOs;
using VotingApp.Infrastructure.CQRS.Interfaces;

namespace VotingApp.Controllers;

public class CandidatesController : AbstractController
{
    private readonly ICommandDispatcher _commandDispatcher;
    private readonly IQueryDispatcher _queryDispatcher;

    public CandidatesController(
        ICommandDispatcher commandDispatcher,
        IQueryDispatcher queryDispatcher)
    {
        _commandDispatcher = commandDispatcher;
        _queryDispatcher = queryDispatcher;
    }

    [HttpGet]
    public async Task<ReadCandidateDto[]> GetCandidates()
    {
        return await _queryDispatcher.Dispatch<GetCandidatesQuery, ReadCandidateDto[]>(new GetCandidatesQuery());
    }
    
    [HttpPost("candidate")]
    public async Task<Guid> AddCandidate([FromBody] AddCandidateDto addCandidateDto)
    {
        return await _commandDispatcher.Dispatch<AddCandidateCommand, Guid>(
            new AddCandidateCommand(addCandidateDto.Name));
    }
}
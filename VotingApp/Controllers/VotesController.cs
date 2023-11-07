using Microsoft.AspNetCore.Mvc;
using VotingApp.Classes;
using VotingApp.CQRS.Commands.AddVoteCommand;
using VotingApp.CQRS.Commands.VoteCommand;
using VotingApp.CQRS.Queries.GetVotingInfoQuery;
using VotingApp.DTOs;
using VotingApp.Infrastructure.CQRS.Interfaces;

namespace VotingApp.Controllers;

public class VotesController : AbstractController
{
    private readonly ICommandDispatcher _commandDispatcher;
    private readonly IQueryDispatcher _queryDispatcher;

    public VotesController(ICommandDispatcher commandDispatcher, IQueryDispatcher queryDispatcher)
    {
        _commandDispatcher = commandDispatcher;
        _queryDispatcher = queryDispatcher;
    }

    [HttpPost("voting/vote")]
    public async Task Vote([FromBody] VoteDto voteDto)
    {
        await _commandDispatcher.Dispatch(new VoteCommand(voteDto.VoterId, voteDto.CandidateId));
    }
    

    [HttpGet("voting/{identifier}")]
    public async Task<VotingBaseInfo> GetVotingInfo(Guid identifier)
    {
        return await _queryDispatcher.Dispatch<GetVotingInfoQuery, VotingBaseInfo>(new GetVotingInfoQuery(identifier));
    }
}
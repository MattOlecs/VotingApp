using Microsoft.AspNetCore.Mvc;
using VotingApp.CQRS.Commands.ResetVotingCommand;
using VotingApp.CQRS.Commands.VoteCommand;
using VotingApp.DTOs;
using VotingApp.Infrastructure.CQRS.Interfaces;

namespace VotingApp.Controllers;

public class VotesController : AbstractController
{
    private readonly ICommandDispatcher _commandDispatcher;

    public VotesController(ICommandDispatcher commandDispatcher)
    {
        _commandDispatcher = commandDispatcher;
    }

    [HttpPost("voting/vote")]
    public async Task Vote([FromBody] VoteDto voteDto)
    {
        await _commandDispatcher.Dispatch(new VoteCommand(voteDto.VoterId, voteDto.CandidateId));
    }

    [HttpPost("voting/reset")]
    public async Task ResetVoting()
    {
        await _commandDispatcher.Dispatch(new ResetVotingCommand());
    }
}
using Microsoft.AspNetCore.Mvc;
using VotingApp.CQRS.Commands.AddVoteCommand;
using VotingApp.Infrastructure.CQRS.Interfaces;

namespace VotingApp.Controllers;

public class VotesController : AbstractController
{
    private readonly ICommandDispatcher _commandDispatcher;

    public VotesController(ICommandDispatcher commandDispatcher)
    {
        _commandDispatcher = commandDispatcher;
    }
    
    [HttpPost("voting")]
    public async Task<Guid> AddNewVoting()
    {
        return await _commandDispatcher.Dispatch<AddVoteCommand, Guid>(new AddVoteCommand());
    }
}
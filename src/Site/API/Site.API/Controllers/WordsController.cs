using Infrastructure.Application.Commands;
using Infrastructure.AspNetCore.Controllers;
using Infrastructure.AspNetCore.Nh;
using Microsoft.AspNetCore.Mvc;
using Site.API.Handlers;

namespace Site.API.Controllers;

[DbSession]
[Route("words")]
public class WordsController : ApiController
{
    private readonly CommandHandler _commandHandler;

    public WordsController(CommandHandler commandHandler)
    {
        _commandHandler = commandHandler;
    }

    [HttpGet("get-all")]
    public async Task<ActionResult<List<WoldCatalogDTO>>> GetAll()
    {
        var result = await _commandHandler.HandleAsync(QueryWordCatalogCommand.Instance);

        return Result<List<WoldCatalogDTO>>(result);
    }

    [HttpGet("get-word")]
    public async Task<ActionResult<WordDTO>> GetWord(long wordId)
    {
        var command = new QueryWordCommand(wordId);

        var result = await _commandHandler.HandleAsync(command);

        return Result<WordDTO>(result);
    }

    [HttpPost("create")]
    public async Task<ActionResult<WordDTO>> Create(CreateWordCommand command,
                                                    CancellationToken cancellationToken)
    {
        var result = await _commandHandler.HandleAsync(command, cancellationToken);

        return Result<WordDTO>(result);
    }

    [HttpPost("delete")]
    public async Task<IActionResult> Delete(DeleteWordCommand command,
                                            CancellationToken cancellationToken)
    {
        var result = await _commandHandler.HandleAsync(command, cancellationToken);

        if (result.IsFailure)
            return BadRequest(result.Error);

        return Ok();
    }
}
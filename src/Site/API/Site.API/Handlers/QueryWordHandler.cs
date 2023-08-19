using DictionarySystem.Application.Words;
using Infrastructure.Application.Commands;

namespace Site.API.Handlers;

public sealed class QueryWordCommand
{
    public long WordId { get; set; }

    public QueryWordCommand(long wordId)
    {
        WordId = wordId;
    }
}

public sealed class QueryWordHandler : BaseCommandAsyncHandler<QueryWordCommand>
{
    private readonly WordRepository _wordRepository;

    public QueryWordHandler(WordRepository wordRepository)
    {
        _wordRepository = wordRepository;
    }

    public override async Task<CommandHandlerResult> HandleAsync(QueryWordCommand command, CancellationToken cancellationToken)
    {
        var word = await _wordRepository.GetAsync(command.WordId, cancellationToken);

        var result = word.MapToDTO();

        return Success(result);
    }
}
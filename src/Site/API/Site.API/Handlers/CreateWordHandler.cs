using DictionarySystem.Application.Words;
using DictionarySystem.Core.Words;
using Infrastructure.Application.Commands;

namespace Site.API.Handlers;

public sealed class CreateWordCommand
{
    public string Russian { get; set; } = null!;

    public string English { get; set; } = null!;
}

public sealed class CreateWordHandler : BaseCommandAsyncHandler<CreateWordCommand>
{
    private readonly WordRepository _wordRepository;

    public CreateWordHandler(WordRepository wordRepository)
    {
        _wordRepository = wordRepository;
    }

    public override async Task<CommandHandlerResult> HandleAsync(CreateWordCommand command, CancellationToken cancellationToken)
    {
        var word = Word.Create(command.Russian, command.English);

        var result = word.MapToDTO();

        await _wordRepository.SaveAsync(word, cancellationToken);

        return Success(result);
    }
}
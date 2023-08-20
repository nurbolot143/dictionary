using DictionarySystem.Application.Words;
using Infrastructure.Application.Commands;
using JetBrains.Annotations;

namespace Site.API.Handlers;

[UsedImplicitly(ImplicitUseTargetFlags.WithMembers)]
public sealed class DeleteWordCommand
{
    public long WordId { get; set; }
}

public sealed class DeleteWordHandler : BaseCommandAsyncHandler<DeleteWordCommand>
{
    private readonly WordRepository _wordRepository;

    public DeleteWordHandler(WordRepository wordRepository)
    {
        _wordRepository = wordRepository;
    }

    public override async Task<CommandHandlerResult> HandleAsync(DeleteWordCommand command, CancellationToken cancellationToken)
    {
        await _wordRepository.DeleteAsync(command.WordId, cancellationToken);

        return Success();
    }
}
using DictionarySystem.Core.Words;
using Infrastructure.DataAccess;

namespace DictionarySystem.Application.Words;

public sealed class WordRepository
{
    public async Task<Word> GetAsync(long wordId, CancellationToken cancellationToken)
    {
        var nhSession = DbSession.CurrentNhSession;

        return await nhSession.GetAsync<Word>(wordId, cancellationToken);
    }

    public async Task SaveAsync(Word word, CancellationToken cancellationToken)
    {
        var nhSession = DbSession.CurrentNhSession;

        await nhSession.SaveOrUpdateAsync(word, cancellationToken);

        await nhSession.FlushAsync(cancellationToken);
    }

    public async Task DeleteAsync(long wordId, CancellationToken cancellationToken)
    {
        var nhSession = DbSession.CurrentNhSession;

        var word = await nhSession.GetAsync<Word>(wordId, cancellationToken);

        await nhSession.DeleteAsync(word, cancellationToken);
        await nhSession.FlushAsync(cancellationToken);
    }
}
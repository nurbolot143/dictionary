using DictionarySystem.Core.Words;

namespace Site.API.Handlers;

public sealed class WordDTO
{
    public long Id { get; set; }

    public string Russian { get; set; } = null!;

    public string English { get; set; } = null!;

    public static WordDTO Map(Word word)
    {
        return new WordDTO
        {
            Id      = word.Id,
            Russian = word.Russian,
            English = word.English
        };
    }
}
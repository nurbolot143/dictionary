using DictionarySystem.Core.Words;

namespace Site.API.Handlers;

public static class WordExtensions
{
    public static WordDTO MapToDTO(this Word word)
    {
        return WordDTO.Map(word);
    }
}
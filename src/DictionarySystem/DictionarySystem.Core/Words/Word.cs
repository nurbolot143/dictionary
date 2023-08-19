using CSharpFunctionalExtensions;

namespace DictionarySystem.Core.Words;

public class Word : Entity
{
    public virtual string Russian { get; set; } = null!;

    public virtual string English { get; set; } = null!;

    protected Word()
    {
    }

    public static Word Create(string russian,
                              string english)
    {
        return new Word
        {
            Russian = russian,
            English = english
        };
    }

    public virtual void EditRussian(string word)
    {
        Russian = word;
    }

    public virtual void EditEnglish(string word)
    {
        English = word;
    }
}
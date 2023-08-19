using CSharpFunctionalExtensions;

namespace DictionarySystem.Core.Words;

public class Word : Entity
{
    public virtual string Russian { get; set; } = null!;

    public virtual string English { get; set; } = null!;

    protected Word()
    {
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
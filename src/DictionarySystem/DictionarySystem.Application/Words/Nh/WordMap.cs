using DictionarySystem.Core.Words;
using FluentNHibernate.Mapping;
using Infrastructure.Application;
using JetBrains.Annotations;

namespace DictionarySystem.Application.Words.Nh;

[UsedImplicitly]
public sealed class WordMap : ClassMap<Word>
{
    public WordMap()
    {
        Schema(DatabaseSchemas.DictionarySystem);

        Id(x => x.Id);

        Map(x => x.Russian);

        Map(x => x.English);
    }
}
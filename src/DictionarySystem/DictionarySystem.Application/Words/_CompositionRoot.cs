using Autofac;
using JetBrains.Annotations;
using Module = Autofac.Module;

namespace DictionarySystem.Application.Words;

[UsedImplicitly]
public class CompositionRoot : Module
{
    protected override void Load(ContainerBuilder builder)
    {
        builder.RegisterType<WordRepository>().SingleInstance();
    }
}
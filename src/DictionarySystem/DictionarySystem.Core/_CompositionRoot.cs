using System.Reflection;
using Autofac;
using JetBrains.Annotations;
using Module = Autofac.Module;

namespace DictionarySystem.Core;

[UsedImplicitly]
public class CompositionRoot : Module
{
    protected override void Load(ContainerBuilder builder)
    {
        builder.RegisterAssemblyModules(Assembly.Load("Infrastructure.Seedwork"));
    }
}
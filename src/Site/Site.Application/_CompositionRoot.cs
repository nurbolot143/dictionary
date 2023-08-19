using System.Reflection;
using Autofac;
using JetBrains.Annotations;
using Module = Autofac.Module;

namespace Site.Application;

[UsedImplicitly]
internal class CompositionRoot : Module
{
    protected override void Load(ContainerBuilder builder)
    {
        builder.RegisterAssemblyModules(Assembly.Load("DictionarySystem.Application"));
    }
}
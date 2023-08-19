using Autofac;
using JetBrains.Annotations;

namespace Infrastructure.EndpointClients;

[UsedImplicitly]
internal class CompositionRoot : Module
{
    protected override void Load(ContainerBuilder builder)
    {
        builder.RegisterType<EndpointClientFactory>().SingleInstance();
    }
}
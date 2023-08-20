using Autofac;
using Infrastructure.Application.Commands;
using JetBrains.Annotations;

namespace Site.API.Handlers;

[UsedImplicitly]
internal class CompositionRoot : Module
{
    protected override void Load(ContainerBuilder builder)
    {
        builder.RegisterHandler<CreateWordCommand, CreateWordHandler>();
        builder.RegisterHandler<DeleteWordCommand, DeleteWordHandler>();
        builder.RegisterHandler<QueryWordCatalogCommand, QueryWordCatalogHandler>();
        builder.RegisterHandler<QueryWordCommand, QueryWordHandler>();
    }
}
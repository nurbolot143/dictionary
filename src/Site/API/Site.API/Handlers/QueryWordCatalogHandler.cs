using Dapper;
using Infrastructure.Application.Commands;
using Infrastructure.DataAccess;

namespace Site.API.Handlers;

public sealed class QueryWordCatalogCommand
{
    public static readonly QueryWordCatalogCommand Instance = new();

    private QueryWordCatalogCommand()
    {
    }
}

public sealed class WoldCatalogDTO
{
    public long Id { get; set; }

    public string Russian { get; set; } = null!;

    public string English { get; set; } = null!;
}

public sealed class QueryWordCatalogHandler : BaseCommandAsyncHandler<QueryWordCatalogCommand>
{
    public override async Task<CommandHandlerResult> HandleAsync(QueryWordCatalogCommand command, CancellationToken cancellationToken)
    {
        const string sql = @"
select t.id,
       t.russian,
       t.english
 from dictionary_system.words t
";
        var connection = DbSession.CurrentConnection;

        var row = await connection.QueryAsync<WoldCatalogDTO>(sql);

        var result = row.ToList();

        return Success(result);
    }
}
using System.Data;
using Dapper;
using Infrastructure.Seedwork.DataTypes;

namespace Infrastructure.DataAccess.Dapper;

public sealed class CurrencyHandler : SqlMapper.TypeHandler<Currency>
{
    public override void SetValue(IDbDataParameter parameter,
                                  Currency dateTime)
    {
        parameter.Value = dateTime.Key;
    }

    public override Currency Parse(object value)
    {
        var currency = (string)value;

        return Currency.Create(currency);
    }
}
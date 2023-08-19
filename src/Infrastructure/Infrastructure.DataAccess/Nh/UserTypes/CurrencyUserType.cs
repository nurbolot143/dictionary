using Infrastructure.Seedwork.DataTypes;
using NHibernate;
using NHibernate.Type;

namespace Infrastructure.DataAccess.Nh.UserTypes;

internal sealed class CurrencyUserType : SingleValueObjectType<Currency>
{
    protected override NullableType PrimitiveType => NHibernateUtil.String;

    protected override Currency Create(object value)
    {
        var currency = Convert.ToString(value)!;

        return Currency.Create(currency);
    }

    protected override object GetValue(Currency currency)
    {
        return currency.Key;
    }
}
using JetBrains.Annotations;
using NHibernate;
using NHibernate.Type;
using DayOfWeek = Infrastructure.Seedwork.DataTypes.DayOfWeek;

namespace Infrastructure.DataAccess.Nh.UserTypes;

[UsedImplicitly]
public sealed class DayOfWeekUserType : SingleValueObjectType<DayOfWeek>
{
    protected override NullableType PrimitiveType => NHibernateUtil.String;

    protected override DayOfWeek Create(object value)
    {
        var kind = Convert.ToString(value);

        return DayOfWeek.Create(kind!);
    }

    protected override object GetValue(DayOfWeek state)
    {
        return state.Key;
    }
}
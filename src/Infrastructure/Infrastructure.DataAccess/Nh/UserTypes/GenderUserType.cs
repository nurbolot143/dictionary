using Infrastructure.Seedwork.DataTypes;
using JetBrains.Annotations;
using NHibernate;
using NHibernate.Type;

namespace Infrastructure.DataAccess.Nh.UserTypes;

[UsedImplicitly]
public sealed class GenderUserType : SingleValueObjectType<Gender>
{
    protected override NullableType PrimitiveType => NHibernateUtil.String;

    protected override Gender Create(object value)
    {
        var kind = Convert.ToString(value);

        return Gender.Create(kind!);
    }

    protected override object GetValue(Gender state)
    {
        return state.Key;
    }
}
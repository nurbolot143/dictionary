using Infrastructure.Seedwork.DataTypes;
using JetBrains.Annotations;
using NHibernate;
using NHibernate.Type;

namespace Infrastructure.DataAccess.Nh.UserTypes;

[UsedImplicitly]
public sealed class MaritalStatusUserType : SingleValueObjectType<MaritalStatus>
{
    protected override NullableType PrimitiveType => NHibernateUtil.String;

    protected override MaritalStatus Create(object value)
    {
        var kind = Convert.ToString(value);

        return MaritalStatus.Create(kind!);
    }

    protected override object GetValue(MaritalStatus state)
    {
        return state.Key;
    }
}
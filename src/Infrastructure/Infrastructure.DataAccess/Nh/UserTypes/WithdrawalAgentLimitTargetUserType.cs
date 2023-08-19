using Infrastructure.Seedwork.DataTypes;
using JetBrains.Annotations;
using NHibernate;
using NHibernate.Type;

namespace Infrastructure.DataAccess.Nh.UserTypes;

[UsedImplicitly]
public sealed class WithdrawalAgentLimitTargetUserType : SingleValueObjectType<WithdrawalAgentLimitTarget>
{
    protected override NullableType PrimitiveType => NHibernateUtil.String;

    protected override WithdrawalAgentLimitTarget Create(object value)
    {
        var kind = Convert.ToString(value);

        return WithdrawalAgentLimitTarget.Create(kind!);
    }

    protected override object GetValue(WithdrawalAgentLimitTarget state)
    {
        return state.Key;
    }
}
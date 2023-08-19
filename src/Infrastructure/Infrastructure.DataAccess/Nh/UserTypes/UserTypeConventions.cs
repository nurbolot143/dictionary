using FluentNHibernate.Conventions;
using FluentNHibernate.Conventions.Instances;
using Infrastructure.Seedwork.DataTypes;
using DayOfWeek = Infrastructure.Seedwork.DataTypes.DayOfWeek;

namespace Infrastructure.DataAccess.Nh.UserTypes;

internal class UserTypesConventions : IPropertyConvention, IIdConvention
{
    public void Apply(IPropertyInstance instance)
    {
        if (instance.Property.PropertyType == typeof(Currency))
            instance.CustomType<CurrencyUserType>();

        if (instance.Property.PropertyType == typeof(UtcDateTime))
            instance.CustomType<UtcDateTimeUserType>();

        if (instance.Property.PropertyType == typeof(Date))
            instance.CustomType<DateUserType>();

        if (instance.Property.PropertyType == typeof(Gender))
            instance.CustomType<GenderUserType>();

        if (instance.Property.PropertyType == typeof(MaritalStatus))
            instance.CustomType<MaritalStatusUserType>();
        
        if (instance.Property.PropertyType == typeof(DayOfWeek))
            instance.CustomType<DayOfWeekUserType>();
    }

    public void Apply(IIdentityInstance instance)
    {
        if (instance.Type == typeof(Currency))
            instance.CustomType<CurrencyUserType>();

        if (instance.Type == typeof(UtcDateTime))
            instance.CustomType<UtcDateTimeUserType>();

        if (instance.Type == typeof(Date))
            instance.CustomType<DateUserType>();

        if (instance.Type == typeof(Gender))
            instance.CustomType<GenderUserType>();

        if (instance.Type == typeof(MaritalStatus))
            instance.CustomType<MaritalStatusUserType>();
        
        if (instance.Type == typeof(DayOfWeek))
            instance.CustomType<DayOfWeekUserType>();
    }
}
using FluentNHibernate.Conventions;
using FluentNHibernate.Conventions.Instances;
using FluentNHibernate.Mapping;
using Humanizer;

namespace Infrastructure.DataAccess.Nh.Conventions;

public sealed class ReferenceConvention : IReferenceConvention
{
    public void Apply(IManyToOneInstance instance)
    {
        instance.LazyLoad(Laziness.Proxy);
        instance.Cascade.SaveUpdate();
        instance.Column(instance.Name.Underscore() + "_id");
    }
}

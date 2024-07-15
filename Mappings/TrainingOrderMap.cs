using FluentNHibernate.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrainingNHibernate.Domain;

namespace TrainingNHibernate.Mappings
{
    public class TrainingOrderMap : ClassMap<TrainingOrder>
    {
        public TrainingOrderMap() {
            Table("TrainingOrder");
            Id(x => x.Id).GeneratedBy.Guid();
            Map(x => x.OrderNumber).Column("OrderNumber").Length(20).Not.Nullable();
            HasMany(x => x.TrainingOrderItems)
                .KeyColumn("Order_ID_FK")
                .Cascade.All()
                .Inverse()
                .LazyLoad()
                .AsBag();
        }
    }
}

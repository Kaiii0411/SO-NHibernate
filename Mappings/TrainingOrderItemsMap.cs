using FluentNHibernate.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrainingNHibernate.Domain;

namespace TrainingNHibernate.Mappings
{
    public class TrainingOrderItemsMap : ClassMap<TrainingOrderItem>
    {
        public TrainingOrderItemsMap()
        {
            Table("TrainingOrderItem");
            Id(x => x.Id).GeneratedBy.Guid();
            References(x => x.TrainingOrder, "Order_ID_FK").Cascade.SaveUpdate();
            Map(x => x.ProductSku).Column("ProductSku").Length(50).Not.Nullable();
            Map(x => x.ItemPrice).Column("ItemPrice").CustomType<decimal>().Not.Nullable();
        }
    }
}

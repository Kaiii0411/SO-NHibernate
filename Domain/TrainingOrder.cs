using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrainingNHibernate.Domain
{
    public class TrainingOrder
    {
        public virtual Guid Id { get; set; }
        public virtual string OrderNumber { get; set; }
        public virtual IList<TrainingOrderItem> TrainingOrderItems { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrainingNHibernate.Domain
{
    public class TrainingOrderItem
    {
        public virtual Guid Id { get; set; }
        public virtual Guid Order_ID_FK { get; set; }
        public virtual string ProductSku { get; set; }
        public virtual decimal ItemPrice { get; set; }
        public virtual TrainingOrder TrainingOrder { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrainingNHibernate.Domain;

namespace TrainingNHibernate.Repositories
{
    public interface IOrderRepository
    {
        void CreateOrder(Guid orderId, string orderNumber, List<TrainingOrderItem> items);
        IList<TrainingOrderItem> GetOrderItemsByOrderNumber(string orderNumber);
        void UpdateOrderItems(string orderNumber, List<TrainingOrderItem> trainingOrderItems);
    }
}

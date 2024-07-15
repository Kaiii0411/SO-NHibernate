using NHibernate.Criterion;
using NHibernate.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;
using System.Windows.Forms;
using TrainingNHibernate.Domain;

namespace TrainingNHibernate.Repositories
{
    public class OrderRepository : IOrderRepository
    {
        public OrderRepository() { }

        public void CreateOrder(Guid orderId, string orderNumber, List<TrainingOrderItem> items)
        {
            using (var session = NHibernateHelper.OpenSession())
            {
                var existingOrder = session.Query<TrainingOrder>()
                           .FirstOrDefault(o => o.OrderNumber == orderNumber.Trim());

                if (existingOrder != null)
                    throw new Exception("Order number already exists.");

                using (var transaction = session.BeginTransaction())
                {
                    var order = new TrainingOrder
                    {
                        Id = orderId,
                        OrderNumber = orderNumber
                    };

                    List<TrainingOrderItem> trainingOrderItems = new List<TrainingOrderItem>();

                    foreach (var item in items)
                    {
                        TrainingOrderItem orderItem = new TrainingOrderItem();
                        orderItem.Order_ID_FK = orderId;
                        orderItem.ProductSku = item.ProductSku;
                        orderItem.ItemPrice = item.ItemPrice;
                        orderItem.TrainingOrder = order;
                        trainingOrderItems.Add(orderItem);
                    }

                    order.TrainingOrderItems = trainingOrderItems;

                    session.Save(order);
                    transaction.Commit();
                }
            }
        }

        public IList<TrainingOrderItem> GetOrderItemsByOrderNumber(string orderNumber) 
        {
            try
            {
                using (var session = NHibernateHelper.OpenSession())
                {
                    var order = session.Query<TrainingOrder>()
                        .FetchMany(o => o.TrainingOrderItems)
                        .SingleOrDefault(o => o.OrderNumber == orderNumber.Trim());

                    if(order == null)
                        throw new Exception("Order not found.");

                    return order.TrainingOrderItems;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void UpdateOrderItems(string orderNumber , List<TrainingOrderItem> trainingOrderItems)
        {
            using (var session = NHibernateHelper.OpenSession())
            {
                using (var transaction = session.BeginTransaction())
                {
                    try
                    {
                        var existingOrder = session.Query<TrainingOrder>()
                                       .Where(o => o.OrderNumber == orderNumber.Trim())
                                       .SingleOrDefault();

                        if (existingOrder == null)
                            throw new Exception("Order not found.");

                        var existingItems = existingOrder.TrainingOrderItems.ToDictionary(item => item.Id);

                        // Track items to add, update, and remove
                        var itemsToUpdateOrAdd = new List<TrainingOrderItem>();
                        var itemsToRemove = existingOrder.TrainingOrderItems
                            .Where(item => !trainingOrderItems.Any(updatedItem => updatedItem.Id == item.Id))
                            .ToList();

                        foreach (var updatedItem in trainingOrderItems)
                        {
                            if (existingItems.TryGetValue(updatedItem.Id, out var existingItem))
                            {
                                // Update existing item
                                existingItem.Order_ID_FK = existingItem.Id;
                                existingItem.ProductSku = updatedItem.ProductSku;
                                existingItem.ItemPrice = updatedItem.ItemPrice;
                                itemsToUpdateOrAdd.Add(existingItem);
                            }
                            else
                            {
                                // Add new item
                                updatedItem.Order_ID_FK = existingOrder.Id;
                                updatedItem.TrainingOrder = existingOrder;
                                itemsToUpdateOrAdd.Add(updatedItem);
                            }
                        }

                        // Update or add items
                        foreach (var item in itemsToUpdateOrAdd)
                        {
                            if (item.Id == Guid.Empty)
                            { 
                                item.Id = Guid.NewGuid();
                                session.Save(item);
                            }
                            else
                                session.Update(item);
                        }

                        // Remove items
                        foreach (var item in itemsToRemove)
                        {
                            existingOrder.TrainingOrderItems.Remove(item);
                            session.Delete(item);
                        }

                        session.Update(existingOrder);
                        transaction.Commit();
                    }
                    catch (Exception)
                    {
                        transaction.Rollback();
                        throw;
                    }
                }
            }
        }
    }
}

using NHibernate.Criterion;
using Remotion.Linq.Clauses;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TrainingNHibernate.Domain;
using TrainingNHibernate.Repositories;

namespace TrainingNHibernate
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void btnAddItem_Click(object sender, EventArgs e)
        {
            dgvOrderItems.Rows.Add();
        }

        private void btnCreateNewOrder_Click(object sender, EventArgs e)
        {
            try
            {
                string orderNumber = txtOrderNumber.Text;

                if (string.IsNullOrEmpty(orderNumber)) {
                    MessageBox.Show("Order Number must not be empty!", "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                Guid orderId = Guid.NewGuid();
                (List<TrainingOrderItem> orderItems, List<int> emptyIndexs) orderItems  = GetOrderItemsFromGrid(orderId);

                if (orderItems.Item1.Count == 0) {
                    MessageBox.Show("No products added!", "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if(orderItems.emptyIndexs.Count() > 0)
                {
                    MessageBox.Show($"Product Sku or Item Price must not be empty at line {string.Join(", ", orderItems.emptyIndexs)}!", "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                IOrderRepository orderRepo = new OrderRepository();
                orderRepo.CreateOrder(orderId, orderNumber, orderItems.Item1);

                MessageBox.Show($"{orderItems.Item1.Count()} products added!", "Success",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"{ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }

        private (List<TrainingOrderItem>, List<int> emptyIndex ) GetOrderItemsFromGrid(Guid orderId)
        {
            var items = new List<TrainingOrderItem>();

            List<int> emptyIndex = new List<int>();

            foreach (DataGridViewRow row in dgvOrderItems.Rows)
            {
                if (row.IsNewRow) continue;

                var productSku = row.Cells["ProductSku"].Value;
                var itemPrice = row.Cells["ItemPrice"].Value;

                if (productSku == null || itemPrice == null) 
                    emptyIndex.Add(row.Index + 1);
                else
                {
                    items.Add(new TrainingOrderItem
                    {
                        Id = Guid.NewGuid(),
                        Order_ID_FK = orderId,
                        ProductSku = productSku.ToString(),
                        ItemPrice = Convert.ToDecimal(row.Cells["ItemPrice"].Value)
                    });
                }
            }

            return (items, emptyIndex);
        }

        private void PopulateGridWithOrderItems(IList<TrainingOrderItem> items)
        {
            dgvOrderItems.Rows.Clear();
            foreach (var item in items)
            {
                dgvOrderItems.Rows.Add(item.ProductSku,item.Id, item.ItemPrice);
            }
        }

        private void btnLoadExistingOrder_Click(object sender, EventArgs e)
        {
            try
            {
                string orderNumber = txtOrderNumber.Text;

                if (string.IsNullOrEmpty(orderNumber))
                {
                    MessageBox.Show("Order Number must not be empty!", "Warning",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                IList<TrainingOrderItem> orderItems = GetOrderItemsByOrderNumber(orderNumber);

                if (orderItems.Count() == 0)
                {
                    MessageBox.Show("There is no data matching the order number!", "Warning",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                PopulateGridWithOrderItems(orderItems);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"{ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }

        public IList<TrainingOrderItem> GetOrderItemsByOrderNumber(string orderNumber)
        {
            try
            {
                IOrderRepository orderRepo = new OrderRepository();
                IList<TrainingOrderItem> orderItems = orderRepo.GetOrderItemsByOrderNumber(orderNumber);
                return orderItems;
            }
            catch (Exception)
            {
                throw;
            }
        }

        private void btnUpdateExistingOrder_Click(object sender, EventArgs e)
        {
            try
            {
                string orderNumber = txtOrderNumber.Text;

                if (string.IsNullOrEmpty(orderNumber))
                {
                    MessageBox.Show("Order Number must not be empty!", "Warning",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                var items = new List<TrainingOrderItem>();

                foreach (DataGridViewRow row in dgvOrderItems.Rows)
                {
                    if (row.IsNewRow) continue;

                    var productSku = row.Cells["ProductSku"].Value;
                    var itemId = row.Cells["Id"].Value;
                    var itemPrice = row.Cells["ItemPrice"].Value;

                    items.Add(new TrainingOrderItem
                    {
                        Id = itemId != null ? new Guid(itemId.ToString()) : Guid.Empty,
                        ProductSku = productSku.ToString(),
                        ItemPrice = Convert.ToDecimal(row.Cells["ItemPrice"].Value)
                    });
                }

                if (items.Count() == 0)
                {
                    MessageBox.Show("Please fill in more order items to update!", "Warning",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                IOrderRepository orderRepository = new OrderRepository();
                orderRepository.UpdateOrderItems(orderNumber, items);

                MessageBox.Show($"Order updated!", "Success",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"{ex.Message}", "Error",
                     MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }

        private void btnRemoveItem_Click(object sender, EventArgs e)
        {
            try
            {
                int selectedTotal = dgvOrderItems.SelectedRows.Count;

                if(selectedTotal == 0)
                {
                    MessageBox.Show($"No rows are selected", "Information",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                List<DataGridViewRow> existOrderRemoveItems = new List<DataGridViewRow>();

                foreach (DataGridViewRow row in dgvOrderItems.SelectedRows)
                {
                    var rowId = row.Cells["Id"].Value;
                    var orderItemId = rowId != null ? new Guid(rowId.ToString()) : Guid.Empty;

                    if(orderItemId != Guid.Empty)
                    {
                        existOrderRemoveItems.Add(row);
                        continue;
                    }

                    dgvOrderItems.Rows.Remove(row);
                }

                int existTotal = existOrderRemoveItems.Count();
                if (existTotal > 0)
                {
                    DialogResult dialogResult = MessageBox.Show($"Are you sure to remove,{existTotal} item has been stored in the database?", "Confirm",
                        MessageBoxButtons.YesNo);
                    if (dialogResult == DialogResult.No)
                        return;
                    else
                    {
                        foreach(DataGridViewRow row in existOrderRemoveItems)
                        {
                            dgvOrderItems.Rows.Remove(row);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"{ex.Message}", "Error",
                     MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }
    }
}

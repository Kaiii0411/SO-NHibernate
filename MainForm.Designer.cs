namespace TrainingNHibernate
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.lblOrderNumber = new System.Windows.Forms.Label();
            this.dgvOrderItems = new System.Windows.Forms.DataGridView();
            this.ProductSku = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ItemPrice = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnAddItem = new System.Windows.Forms.Button();
            this.btnRemoveItem = new System.Windows.Forms.Button();
            this.btnCreateNewOrder = new System.Windows.Forms.Button();
            this.btnLoadExistingOrder = new System.Windows.Forms.Button();
            this.btnUpdateExistingOrder = new System.Windows.Forms.Button();
            this.txtOrderNumber = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgvOrderItems)).BeginInit();
            this.SuspendLayout();
            // 
            // lblOrderNumber
            // 
            this.lblOrderNumber.AutoSize = true;
            this.lblOrderNumber.Location = new System.Drawing.Point(29, 13);
            this.lblOrderNumber.Name = "lblOrderNumber";
            this.lblOrderNumber.Size = new System.Drawing.Size(76, 13);
            this.lblOrderNumber.TabIndex = 0;
            this.lblOrderNumber.Text = "Order Number:";
            // 
            // dgvOrderItems
            // 
            this.dgvOrderItems.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvOrderItems.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ProductSku,
            this.Id,
            this.ItemPrice});
            this.dgvOrderItems.Location = new System.Drawing.Point(32, 36);
            this.dgvOrderItems.Name = "dgvOrderItems";
            this.dgvOrderItems.Size = new System.Drawing.Size(484, 184);
            this.dgvOrderItems.TabIndex = 1;
            // 
            // ProductSku
            // 
            this.ProductSku.HeaderText = "Product Sku";
            this.ProductSku.Name = "ProductSku";
            this.ProductSku.Width = 200;
            // 
            // Id
            // 
            this.Id.HeaderText = "Id";
            this.Id.Name = "Id";
            this.Id.Visible = false;
            // 
            // ItemPrice
            // 
            this.ItemPrice.HeaderText = "Item Price";
            this.ItemPrice.Name = "ItemPrice";
            this.ItemPrice.Width = 200;
            // 
            // btnAddItem
            // 
            this.btnAddItem.Location = new System.Drawing.Point(522, 36);
            this.btnAddItem.Name = "btnAddItem";
            this.btnAddItem.Size = new System.Drawing.Size(100, 23);
            this.btnAddItem.TabIndex = 2;
            this.btnAddItem.Text = "Add Item";
            this.btnAddItem.UseVisualStyleBackColor = true;
            this.btnAddItem.Click += new System.EventHandler(this.btnAddItem_Click);
            // 
            // btnRemoveItem
            // 
            this.btnRemoveItem.Location = new System.Drawing.Point(522, 65);
            this.btnRemoveItem.Name = "btnRemoveItem";
            this.btnRemoveItem.Size = new System.Drawing.Size(100, 23);
            this.btnRemoveItem.TabIndex = 3;
            this.btnRemoveItem.Text = "Remove Item";
            this.btnRemoveItem.UseVisualStyleBackColor = true;
            this.btnRemoveItem.Click += new System.EventHandler(this.btnRemoveItem_Click);
            // 
            // btnCreateNewOrder
            // 
            this.btnCreateNewOrder.Location = new System.Drawing.Point(32, 226);
            this.btnCreateNewOrder.Name = "btnCreateNewOrder";
            this.btnCreateNewOrder.Size = new System.Drawing.Size(150, 23);
            this.btnCreateNewOrder.TabIndex = 4;
            this.btnCreateNewOrder.Text = "Create New Order";
            this.btnCreateNewOrder.UseVisualStyleBackColor = true;
            this.btnCreateNewOrder.Click += new System.EventHandler(this.btnCreateNewOrder_Click);
            // 
            // btnLoadExistingOrder
            // 
            this.btnLoadExistingOrder.Location = new System.Drawing.Point(188, 226);
            this.btnLoadExistingOrder.Name = "btnLoadExistingOrder";
            this.btnLoadExistingOrder.Size = new System.Drawing.Size(150, 23);
            this.btnLoadExistingOrder.TabIndex = 5;
            this.btnLoadExistingOrder.Text = "Load Existing Order";
            this.btnLoadExistingOrder.UseVisualStyleBackColor = true;
            this.btnLoadExistingOrder.Click += new System.EventHandler(this.btnLoadExistingOrder_Click);
            // 
            // btnUpdateExistingOrder
            // 
            this.btnUpdateExistingOrder.Location = new System.Drawing.Point(344, 226);
            this.btnUpdateExistingOrder.Name = "btnUpdateExistingOrder";
            this.btnUpdateExistingOrder.Size = new System.Drawing.Size(150, 23);
            this.btnUpdateExistingOrder.TabIndex = 6;
            this.btnUpdateExistingOrder.Text = "Update Existing Order";
            this.btnUpdateExistingOrder.UseVisualStyleBackColor = true;
            this.btnUpdateExistingOrder.Click += new System.EventHandler(this.btnUpdateExistingOrder_Click);
            // 
            // txtOrderNumber
            // 
            this.txtOrderNumber.Location = new System.Drawing.Point(111, 10);
            this.txtOrderNumber.Name = "txtOrderNumber";
            this.txtOrderNumber.Size = new System.Drawing.Size(100, 20);
            this.txtOrderNumber.TabIndex = 7;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(634, 261);
            this.Controls.Add(this.txtOrderNumber);
            this.Controls.Add(this.btnUpdateExistingOrder);
            this.Controls.Add(this.btnLoadExistingOrder);
            this.Controls.Add(this.btnCreateNewOrder);
            this.Controls.Add(this.btnRemoveItem);
            this.Controls.Add(this.btnAddItem);
            this.Controls.Add(this.dgvOrderItems);
            this.Controls.Add(this.lblOrderNumber);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Order Form";
            ((System.ComponentModel.ISupportInitialize)(this.dgvOrderItems)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblOrderNumber;
        private System.Windows.Forms.DataGridView dgvOrderItems;
        private System.Windows.Forms.Button btnAddItem;
        private System.Windows.Forms.Button btnRemoveItem;
        private System.Windows.Forms.Button btnCreateNewOrder;
        private System.Windows.Forms.Button btnUpdateExistingOrder;
        private System.Windows.Forms.TextBox txtOrderNumber;
        private System.Windows.Forms.Button btnLoadExistingOrder;
        private System.Windows.Forms.DataGridViewTextBoxColumn ProductSku;
        private System.Windows.Forms.DataGridViewTextBoxColumn Id;
        private System.Windows.Forms.DataGridViewTextBoxColumn ItemPrice;
    }
}


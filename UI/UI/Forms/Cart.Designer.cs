using UI.Services.PostgreSQL;

namespace UI.Forms
{
    partial class Cart
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
            this.components = new System.ComponentModel.Container();
            this.Data = new System.Windows.Forms.DataGridView();
            this.name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.isInStock = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Discount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Price = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.OldPrice = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.catalogItemBindingSource = new System.Windows.Forms.BindingSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.Data)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.catalogItemBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // Data
            // 
            this.Data.AllowUserToAddRows = false;
            this.Data.AllowUserToDeleteRows = false;
            this.Data.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.Data.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.name,
            this.isInStock,
            this.Discount,
            this.Price,
            this.OldPrice});
            this.Data.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Data.Location = new System.Drawing.Point(0, 0);
            this.Data.Name = "Data";
            this.Data.ReadOnly = true;
            this.Data.RowHeadersWidth = 51;
            this.Data.RowTemplate.Height = 29;
            this.Data.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.Data.Size = new System.Drawing.Size(800, 450);
            this.Data.TabIndex = 0;
            this.Data.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Data_KeyPress);
            // 
            // name
            // 
            this.name.HeaderText = "Название";
            this.name.MinimumWidth = 6;
            this.name.Name = "name";
            this.name.ReadOnly = true;
            this.name.Width = 125;
            // 
            // isInStock
            // 
            this.isInStock.HeaderText = "Наличие";
            this.isInStock.MinimumWidth = 6;
            this.isInStock.Name = "isInStock";
            this.isInStock.ReadOnly = true;
            this.isInStock.Width = 125;
            // 
            // Discount
            // 
            this.Discount.HeaderText = "Скидка";
            this.Discount.MinimumWidth = 6;
            this.Discount.Name = "Discount";
            this.Discount.ReadOnly = true;
            this.Discount.Width = 125;
            // 
            // Price
            // 
            this.Price.HeaderText = "Цена";
            this.Price.MinimumWidth = 6;
            this.Price.Name = "Price";
            this.Price.ReadOnly = true;
            this.Price.Width = 125;
            // 
            // OldPrice
            // 
            this.OldPrice.HeaderText = "Старая цена";
            this.OldPrice.MinimumWidth = 6;
            this.OldPrice.Name = "OldPrice";
            this.OldPrice.ReadOnly = true;
            this.OldPrice.Width = 125;
            // 
            // catalogItemBindingSource
            // 
            this.catalogItemBindingSource.DataSource = typeof(CatalogItem);
            // 
            // Cart
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.Data);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Cart";
            this.Text = "Cart";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.Cart_Load);
            ((System.ComponentModel.ISupportInitialize)(this.Data)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.catalogItemBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DataGridView Data;
        private DataGridViewTextBoxColumn idDataGridViewTextBoxColumn;
        private BindingSource catalogItemBindingSource;
        private DataGridViewTextBoxColumn name;
        private DataGridViewTextBoxColumn isInStock;
        private DataGridViewTextBoxColumn Discount;
        private DataGridViewTextBoxColumn Price;
        private DataGridViewTextBoxColumn OldPrice;
    }
}
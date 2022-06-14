namespace UI.Forms
{
    partial class Catalog
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.settingsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cartToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.prev = new System.Windows.Forms.Button();
            this.next = new System.Windows.Forms.Button();
            this.pageCounter = new System.Windows.Forms.Label();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.Products = new System.Windows.Forms.DataGridView();
            this.productName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.IsInStock = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.IsDiscount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Price = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.OldPrice = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Products)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.settingsToolStripMenuItem,
            this.cartToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(5, 2, 0, 2);
            this.menuStrip1.Size = new System.Drawing.Size(750, 24);
            this.menuStrip1.TabIndex = 5;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // settingsToolStripMenuItem
            // 
            this.settingsToolStripMenuItem.Name = "settingsToolStripMenuItem";
            this.settingsToolStripMenuItem.Size = new System.Drawing.Size(61, 20);
            this.settingsToolStripMenuItem.Text = "Settings";
            this.settingsToolStripMenuItem.Click += new System.EventHandler(this.settingsToolStripMenuItem_Click);
            // 
            // cartToolStripMenuItem
            // 
            this.cartToolStripMenuItem.Name = "cartToolStripMenuItem";
            this.cartToolStripMenuItem.Size = new System.Drawing.Size(41, 20);
            this.cartToolStripMenuItem.Text = "Cart";
            this.cartToolStripMenuItem.Click += new System.EventHandler(this.cartToolStripMenuItem_Click);
            // 
            // prev
            // 
            this.prev.Location = new System.Drawing.Point(229, 290);
            this.prev.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.prev.Name = "prev";
            this.prev.Size = new System.Drawing.Size(82, 22);
            this.prev.TabIndex = 7;
            this.prev.Text = "Previous";
            this.prev.UseVisualStyleBackColor = true;
            // 
            // next
            // 
            this.next.Location = new System.Drawing.Point(428, 290);
            this.next.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.next.Name = "next";
            this.next.Size = new System.Drawing.Size(82, 22);
            this.next.TabIndex = 8;
            this.next.Text = "Next";
            this.next.UseVisualStyleBackColor = true;
            this.next.Click += new System.EventHandler(this.next_Click);
            // 
            // pageCounter
            // 
            this.pageCounter.AutoSize = true;
            this.pageCounter.Location = new System.Drawing.Point(355, 293);
            this.pageCounter.Name = "pageCounter";
            this.pageCounter.Size = new System.Drawing.Size(24, 15);
            this.pageCounter.TabIndex = 9;
            this.pageCounter.Text = "0/0";
            // 
            // backgroundWorker1
            // 
            this.backgroundWorker1.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker1_DoWork);
            // 
            // Products
            // 
            this.Products.AllowUserToAddRows = false;
            this.Products.AllowUserToDeleteRows = false;
            this.Products.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.Products.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.productName,
            this.IsInStock,
            this.IsDiscount,
            this.Price,
            this.OldPrice});
            this.Products.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.Products.Location = new System.Drawing.Point(10, 23);
            this.Products.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Products.MultiSelect = false;
            this.Products.Name = "Products";
            this.Products.ReadOnly = true;
            this.Products.RowHeadersWidth = 51;
            this.Products.RowTemplate.Height = 29;
            this.Products.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.Products.Size = new System.Drawing.Size(729, 245);
            this.Products.TabIndex = 10;
            // 
            // productName
            // 
            this.productName.HeaderText = "Название";
            this.productName.MinimumWidth = 6;
            this.productName.Name = "productName";
            this.productName.ReadOnly = true;
            this.productName.Width = 125;
            // 
            // IsInStock
            // 
            this.IsInStock.HeaderText = "Наличие";
            this.IsInStock.MinimumWidth = 6;
            this.IsInStock.Name = "IsInStock";
            this.IsInStock.ReadOnly = true;
            this.IsInStock.Width = 125;
            // 
            // IsDiscount
            // 
            this.IsDiscount.HeaderText = "Скидка";
            this.IsDiscount.MinimumWidth = 6;
            this.IsDiscount.Name = "IsDiscount";
            this.IsDiscount.ReadOnly = true;
            this.IsDiscount.Width = 125;
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
            // Catalog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(750, 331);
            this.Controls.Add(this.Products);
            this.Controls.Add(this.pageCounter);
            this.Controls.Add(this.next);
            this.Controls.Add(this.prev);
            this.Controls.Add(this.menuStrip1);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "Catalog";
            this.Text = "Catalog";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Catalog_FormClosing);
            this.Load += new System.EventHandler(this.Catalog_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Products)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private MenuStrip menuStrip1;
        private ToolStripMenuItem settingsToolStripMenuItem;
        private ToolStripMenuItem cartToolStripMenuItem;
        private Button prev;
        private Button next;
        private Label pageCounter;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private DataGridView Products;
        private DataGridViewTextBoxColumn productName;
        private DataGridViewTextBoxColumn IsInStock;
        private DataGridViewTextBoxColumn IsDiscount;
        private DataGridViewTextBoxColumn Price;
        private DataGridViewTextBoxColumn OldPrice;
    }
}
﻿namespace UI.Forms
{
    partial class Product
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
            this.productImage = new System.Windows.Forms.PictureBox();
            this.productName = new System.Windows.Forms.Label();
            this.Price = new System.Windows.Forms.Label();
            this.oldPrice = new System.Windows.Forms.Label();
            this.itemData = new System.Windows.Forms.DataGridView();
            this.prop = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.value = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.addToCart = new System.Windows.Forms.Button();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.productImage)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.itemData)).BeginInit();
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
            this.menuStrip1.Size = new System.Drawing.Size(800, 28);
            this.menuStrip1.TabIndex = 5;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // settingsToolStripMenuItem
            // 
            this.settingsToolStripMenuItem.Name = "settingsToolStripMenuItem";
            this.settingsToolStripMenuItem.Size = new System.Drawing.Size(76, 24);
            this.settingsToolStripMenuItem.Text = "Settings";
            this.settingsToolStripMenuItem.Click += new System.EventHandler(this.settingsToolStripMenuItem_Click);
            // 
            // cartToolStripMenuItem
            // 
            this.cartToolStripMenuItem.Name = "cartToolStripMenuItem";
            this.cartToolStripMenuItem.Size = new System.Drawing.Size(50, 24);
            this.cartToolStripMenuItem.Text = "Cart";
            this.cartToolStripMenuItem.Click += new System.EventHandler(this.cartToolStripMenuItem_Click);
            // 
            // productImage
            // 
            this.productImage.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.productImage.Location = new System.Drawing.Point(31, 53);
            this.productImage.Name = "productImage";
            this.productImage.Size = new System.Drawing.Size(354, 185);
            this.productImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.productImage.TabIndex = 6;
            this.productImage.TabStop = false;
            // 
            // productName
            // 
            this.productName.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.productName.AutoSize = true;
            this.productName.Location = new System.Drawing.Point(31, 256);
            this.productName.Name = "productName";
            this.productName.Size = new System.Drawing.Size(90, 20);
            this.productName.TabIndex = 7;
            this.productName.Text = "Sample Text";
            // 
            // Price
            // 
            this.Price.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Price.AutoSize = true;
            this.Price.Location = new System.Drawing.Point(31, 288);
            this.Price.Name = "Price";
            this.Price.Size = new System.Drawing.Size(33, 20);
            this.Price.TabIndex = 8;
            this.Price.Text = "0 р.";
            // 
            // oldPrice
            // 
            this.oldPrice.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.oldPrice.AutoSize = true;
            this.oldPrice.Enabled = false;
            this.oldPrice.Location = new System.Drawing.Point(31, 317);
            this.oldPrice.Name = "oldPrice";
            this.oldPrice.Size = new System.Drawing.Size(33, 20);
            this.oldPrice.TabIndex = 9;
            this.oldPrice.Text = "0 р.";
            // 
            // itemData
            // 
            this.itemData.AllowUserToAddRows = false;
            this.itemData.AllowUserToDeleteRows = false;
            this.itemData.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.itemData.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.itemData.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.itemData.ColumnHeadersVisible = false;
            this.itemData.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.prop,
            this.value});
            this.itemData.Location = new System.Drawing.Point(391, 53);
            this.itemData.Name = "itemData";
            this.itemData.ReadOnly = true;
            this.itemData.RowHeadersWidth = 51;
            this.itemData.RowTemplate.Height = 29;
            this.itemData.Size = new System.Drawing.Size(397, 385);
            this.itemData.TabIndex = 10;
            // 
            // prop
            // 
            this.prop.HeaderText = "Prop";
            this.prop.MinimumWidth = 6;
            this.prop.Name = "prop";
            this.prop.ReadOnly = true;
            // 
            // value
            // 
            this.value.HeaderText = "Value";
            this.value.MinimumWidth = 6;
            this.value.Name = "value";
            this.value.ReadOnly = true;
            // 
            // addToCart
            // 
            this.addToCart.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.addToCart.Location = new System.Drawing.Point(31, 409);
            this.addToCart.Name = "addToCart";
            this.addToCart.Size = new System.Drawing.Size(94, 29);
            this.addToCart.TabIndex = 11;
            this.addToCart.Text = "Add to cart";
            this.addToCart.UseVisualStyleBackColor = true;
            this.addToCart.Click += new System.EventHandler(this.addToCart_Click);
            // 
            // Product
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.addToCart);
            this.Controls.Add(this.itemData);
            this.Controls.Add(this.oldPrice);
            this.Controls.Add(this.Price);
            this.Controls.Add(this.productName);
            this.Controls.Add(this.productImage);
            this.Controls.Add(this.menuStrip1);
            this.Name = "Product";
            this.Text = "Product";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Product_FormClosing);
            this.Load += new System.EventHandler(this.Product_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.productImage)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.itemData)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private MenuStrip menuStrip1;
        private ToolStripMenuItem settingsToolStripMenuItem;
        private ToolStripMenuItem cartToolStripMenuItem;
        private PictureBox productImage;
        private Label productName;
        private Label Price;
        private Label oldPrice;
        private DataGridView itemData;
        private Button addToCart;
        private DataGridViewTextBoxColumn prop;
        private DataGridViewTextBoxColumn value;
    }
}
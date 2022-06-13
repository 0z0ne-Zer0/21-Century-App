namespace UI.Forms
{
    partial class MainPage
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.id = new System.Windows.Forms.TextBox();
            this.name = new System.Windows.Forms.TextBox();
            this.link = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // id
            // 
            this.id.Location = new System.Drawing.Point(23, 27);
            this.id.Name = "id";
            this.id.Size = new System.Drawing.Size(125, 27);
            this.id.TabIndex = 0;
            // 
            // name
            // 
            this.name.Location = new System.Drawing.Point(23, 92);
            this.name.Name = "name";
            this.name.Size = new System.Drawing.Size(125, 27);
            this.name.TabIndex = 1;
            // 
            // link
            // 
            this.link.Location = new System.Drawing.Point(23, 162);
            this.link.Name = "link";
            this.link.Size = new System.Drawing.Size(125, 27);
            this.link.TabIndex = 2;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(23, 220);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(94, 29);
            this.button1.TabIndex = 3;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // MainPage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.link);
            this.Controls.Add(this.name);
            this.Controls.Add(this.id);
            this.Name = "MainPage";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private TextBox id;
        private TextBox name;
        private TextBox link;
        private Button button1;
    }
}
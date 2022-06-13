namespace UI.Forms
{
    partial class Settings
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
            this.IP = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.remoteSave = new System.Windows.Forms.Button();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.openLocal = new System.Windows.Forms.Button();
            this.createLocal = new System.Windows.Forms.Button();
            this.fileLocation = new System.Windows.Forms.TextBox();
            this.remoteDB = new System.Windows.Forms.RadioButton();
            this.localDB = new System.Windows.Forms.RadioButton();
            this.label2 = new System.Windows.Forms.Label();
            this.Cancel = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // IP
            // 
            this.IP.Location = new System.Drawing.Point(12, 57);
            this.IP.Name = "IP";
            this.IP.Size = new System.Drawing.Size(125, 27);
            this.IP.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 27);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(56, 20);
            this.label1.TabIndex = 1;
            this.label1.Text = "Host IP";
            // 
            // remoteSave
            // 
            this.remoteSave.Location = new System.Drawing.Point(12, 90);
            this.remoteSave.Name = "remoteSave";
            this.remoteSave.Size = new System.Drawing.Size(125, 29);
            this.remoteSave.TabIndex = 2;
            this.remoteSave.Text = "Save";
            this.remoteSave.UseVisualStyleBackColor = true;
            this.remoteSave.Click += new System.EventHandler(this.button1_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // openLocal
            // 
            this.openLocal.Location = new System.Drawing.Point(162, 81);
            this.openLocal.Name = "openLocal";
            this.openLocal.Size = new System.Drawing.Size(155, 29);
            this.openLocal.TabIndex = 3;
            this.openLocal.Text = "Open local DB";
            this.openLocal.UseVisualStyleBackColor = true;
            // 
            // createLocal
            // 
            this.createLocal.Location = new System.Drawing.Point(162, 116);
            this.createLocal.Name = "createLocal";
            this.createLocal.Size = new System.Drawing.Size(155, 29);
            this.createLocal.TabIndex = 4;
            this.createLocal.Text = "Create local DB";
            this.createLocal.UseVisualStyleBackColor = true;
            // 
            // fileLocation
            // 
            this.fileLocation.Location = new System.Drawing.Point(162, 48);
            this.fileLocation.Name = "fileLocation";
            this.fileLocation.Size = new System.Drawing.Size(155, 27);
            this.fileLocation.TabIndex = 5;
            // 
            // remoteDB
            // 
            this.remoteDB.AutoSize = true;
            this.remoteDB.Checked = true;
            this.remoteDB.Location = new System.Drawing.Point(12, 0);
            this.remoteDB.Name = "remoteDB";
            this.remoteDB.Size = new System.Drawing.Size(106, 24);
            this.remoteDB.TabIndex = 6;
            this.remoteDB.TabStop = true;
            this.remoteDB.Text = "Remote DB";
            this.remoteDB.UseVisualStyleBackColor = true;
            this.remoteDB.CheckedChanged += new System.EventHandler(this.DB_CheckedChanged);
            // 
            // localDB
            // 
            this.localDB.AutoSize = true;
            this.localDB.Location = new System.Drawing.Point(162, 0);
            this.localDB.Name = "localDB";
            this.localDB.Size = new System.Drawing.Size(89, 24);
            this.localDB.TabIndex = 7;
            this.localDB.Text = "Local DB";
            this.localDB.UseVisualStyleBackColor = true;
            this.localDB.CheckedChanged += new System.EventHandler(this.DB_CheckedChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(162, 25);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(90, 20);
            this.label2.TabIndex = 8;
            this.label2.Text = "File location";
            // 
            // Cancel
            // 
            this.Cancel.Location = new System.Drawing.Point(113, 153);
            this.Cancel.Name = "Cancel";
            this.Cancel.Size = new System.Drawing.Size(94, 29);
            this.Cancel.TabIndex = 9;
            this.Cancel.Text = "Cancel";
            this.Cancel.UseVisualStyleBackColor = true;
            this.Cancel.Click += new System.EventHandler(this.Cancel_Click);
            // 
            // Settings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(330, 194);
            this.ControlBox = false;
            this.Controls.Add(this.Cancel);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.localDB);
            this.Controls.Add(this.remoteDB);
            this.Controls.Add(this.fileLocation);
            this.Controls.Add(this.createLocal);
            this.Controls.Add(this.openLocal);
            this.Controls.Add(this.remoteSave);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.IP);
            this.Name = "Settings";
            this.Text = "Settings";
            this.TopMost = true;
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private TextBox IP;
        private Label label1;
        private Button remoteSave;
        private OpenFileDialog openFileDialog1;
        private SaveFileDialog saveFileDialog1;
        private Button openLocal;
        private Button createLocal;
        private TextBox fileLocation;
        private RadioButton remoteDB;
        private RadioButton localDB;
        private Label label2;
        private Button Cancel;
    }
}
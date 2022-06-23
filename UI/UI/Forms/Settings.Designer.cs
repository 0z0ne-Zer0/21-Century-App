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
            this.localSync = new System.Windows.Forms.CheckBox();
            this.serverSync = new System.Windows.Forms.CheckBox();
            this.syncDB = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.SuspendLayout();
            // 
            // IP
            // 
            this.IP.Location = new System.Drawing.Point(12, 48);
            this.IP.Name = "IP";
            this.IP.Size = new System.Drawing.Size(125, 27);
            this.IP.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 27);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(82, 20);
            this.label1.TabIndex = 1;
            this.label1.Text = "IP сервера";
            // 
            // remoteSave
            // 
            this.remoteSave.Location = new System.Drawing.Point(12, 81);
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
            this.openFileDialog1.Filter = "SQlite Database| *.sqlite";
            // 
            // saveFileDialog1
            // 
            this.saveFileDialog1.Filter = "SQlite Database| *.sqlite";
            // 
            // openLocal
            // 
            this.openLocal.Location = new System.Drawing.Point(162, 81);
            this.openLocal.Name = "openLocal";
            this.openLocal.Size = new System.Drawing.Size(155, 29);
            this.openLocal.TabIndex = 3;
            this.openLocal.Text = "Open local DB";
            this.openLocal.UseVisualStyleBackColor = true;
            this.openLocal.Click += new System.EventHandler(this.openLocal_Click);
            // 
            // createLocal
            // 
            this.createLocal.Location = new System.Drawing.Point(162, 116);
            this.createLocal.Name = "createLocal";
            this.createLocal.Size = new System.Drawing.Size(155, 29);
            this.createLocal.TabIndex = 4;
            this.createLocal.Text = "Create local DB";
            this.createLocal.UseVisualStyleBackColor = true;
            this.createLocal.Click += new System.EventHandler(this.createLocal_Click);
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
            this.label2.Size = new System.Drawing.Size(159, 20);
            this.label2.TabIndex = 8;
            this.label2.Text = "Расположения файла";
            // 
            // Cancel
            // 
            this.Cancel.Location = new System.Drawing.Point(12, 281);
            this.Cancel.Name = "Cancel";
            this.Cancel.Size = new System.Drawing.Size(94, 29);
            this.Cancel.TabIndex = 9;
            this.Cancel.Text = "Закрыть";
            this.Cancel.UseVisualStyleBackColor = true;
            this.Cancel.Click += new System.EventHandler(this.Cancel_Click);
            // 
            // localSync
            // 
            this.localSync.AutoSize = true;
            this.localSync.Location = new System.Drawing.Point(12, 180);
            this.localSync.Name = "localSync";
            this.localSync.Size = new System.Drawing.Size(315, 24);
            this.localSync.TabIndex = 10;
            this.localSync.Text = "Синхронизация с сервера на локальную";
            this.localSync.UseVisualStyleBackColor = true;
            this.localSync.CheckedChanged += new System.EventHandler(this.CheckedChanged);
            // 
            // serverSync
            // 
            this.serverSync.AutoSize = true;
            this.serverSync.Location = new System.Drawing.Point(12, 216);
            this.serverSync.Name = "serverSync";
            this.serverSync.Size = new System.Drawing.Size(306, 24);
            this.serverSync.TabIndex = 11;
            this.serverSync.Text = "Синхронизация с локальной на сервер";
            this.serverSync.UseVisualStyleBackColor = true;
            this.serverSync.CheckedChanged += new System.EventHandler(this.CheckedChanged);
            // 
            // syncDB
            // 
            this.syncDB.Enabled = false;
            this.syncDB.Location = new System.Drawing.Point(12, 246);
            this.syncDB.Name = "syncDB";
            this.syncDB.Size = new System.Drawing.Size(154, 29);
            this.syncDB.TabIndex = 12;
            this.syncDB.Text = "Синхронизировать";
            this.syncDB.UseVisualStyleBackColor = true;
            this.syncDB.Click += new System.EventHandler(this.syncDB_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 155);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(204, 20);
            this.label3.TabIndex = 15;
            this.label3.Text = "Синхронизация баз данных";
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(172, 246);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(145, 29);
            this.progressBar1.TabIndex = 16;
            // 
            // backgroundWorker1
            // 
            this.backgroundWorker1.WorkerReportsProgress = true;
            this.backgroundWorker1.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker1_DoWork);
            this.backgroundWorker1.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.backgroundWorker1_ProgressChanged);
            this.backgroundWorker1.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorker1_RunWorkerCompleted);
            // 
            // Settings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(120F, 120F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(335, 325);
            this.ControlBox = false;
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.syncDB);
            this.Controls.Add(this.serverSync);
            this.Controls.Add(this.localSync);
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
        private CheckBox localSync;
        private CheckBox serverSync;
        private Button syncDB;
        private Label label3;
        private ProgressBar progressBar1;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
    }
}
namespace Shortcut_Manager
{
    partial class InternetTestWin
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(InternetTestWin));
            this.cancelButton = new System.Windows.Forms.Button();
            this.descLabel = new System.Windows.Forms.Label();
            this.testTimer = new System.Windows.Forms.Timer(this.components);
            this.buttonPanel = new System.Windows.Forms.Panel();
            this.movingDotsTimer = new System.Windows.Forms.Timer(this.components);
            this.testBackgroundWorker = new System.ComponentModel.BackgroundWorker();
            this.testProgressBar = new Shortcut_Manager.OldProgressBar(this.components);
            this.buttonPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // cancelButton
            // 
            this.cancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cancelButton.Location = new System.Drawing.Point(193, 8);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(77, 23);
            this.cancelButton.TabIndex = 1;
            this.cancelButton.Text = "Cancel";
            this.cancelButton.UseVisualStyleBackColor = true;
            this.cancelButton.Click += new System.EventHandler(this.cancelButton_Click);
            // 
            // descLabel
            // 
            this.descLabel.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.descLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(51)))), ((int)(((byte)(153)))));
            this.descLabel.Location = new System.Drawing.Point(31, 11);
            this.descLabel.Name = "descLabel";
            this.descLabel.Size = new System.Drawing.Size(415, 38);
            this.descLabel.TabIndex = 2;
            this.descLabel.Text = "Testing for internet connection...";
            this.descLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // testTimer
            // 
            this.testTimer.Enabled = true;
            this.testTimer.Interval = 500;
            this.testTimer.Tick += new System.EventHandler(this.testTimer_Tick);
            // 
            // buttonPanel
            // 
            this.buttonPanel.BackColor = System.Drawing.SystemColors.Control;
            this.buttonPanel.Controls.Add(this.cancelButton);
            this.buttonPanel.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.buttonPanel.Location = new System.Drawing.Point(0, 81);
            this.buttonPanel.Name = "buttonPanel";
            this.buttonPanel.Size = new System.Drawing.Size(479, 41);
            this.buttonPanel.TabIndex = 3;
            // 
            // movingDotsTimer
            // 
            this.movingDotsTimer.Enabled = true;
            this.movingDotsTimer.Interval = 500;
            this.movingDotsTimer.Tick += new System.EventHandler(this.movingDotsTimer_Tick);
            // 
            // testBackgroundWorker
            // 
            this.testBackgroundWorker.WorkerSupportsCancellation = true;
            this.testBackgroundWorker.DoWork += new System.ComponentModel.DoWorkEventHandler(this.testBackgroundWorker_DoWork);
            this.testBackgroundWorker.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.testBackgroundWorker_RunWorkerCompleted);
            // 
            // testProgressBar
            // 
            this.testProgressBar.BackColor = System.Drawing.SystemColors.Control;
            this.testProgressBar.ForeColor = System.Drawing.Color.LimeGreen;
            this.testProgressBar.Location = new System.Drawing.Point(35, 52);
            this.testProgressBar.MarqueeAnimationSpeed = 30;
            this.testProgressBar.Name = "testProgressBar";
            this.testProgressBar.Size = new System.Drawing.Size(411, 23);
            this.testProgressBar.TabIndex = 4;
            // 
            // InternetTestWin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.CancelButton = this.cancelButton;
            this.ClientSize = new System.Drawing.Size(479, 122);
            this.ControlBox = false;
            this.Controls.Add(this.testProgressBar);
            this.Controls.Add(this.buttonPanel);
            this.Controls.Add(this.descLabel);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(495, 161);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(495, 161);
            this.Name = "InternetTestWin";
            this.Text = "Internet Test";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.InternetTestWin_FormClosing);
            this.Load += new System.EventHandler(this.InternetTest_Load);
            this.buttonPanel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button cancelButton;
        private System.Windows.Forms.Label descLabel;
        private System.Windows.Forms.Timer testTimer;
        private System.Windows.Forms.Panel buttonPanel;
        private System.Windows.Forms.Timer movingDotsTimer;
        private System.ComponentModel.BackgroundWorker testBackgroundWorker;
        private OldProgressBar testProgressBar;
    }
}
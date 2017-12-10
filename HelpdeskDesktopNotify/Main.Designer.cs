namespace HelpdeskDesktopNotify
{
    partial class Main
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Main));
            this.nIcon = new System.Windows.Forms.NotifyIcon(this.components);
            this.lblMaxValue = new System.Windows.Forms.Label();
            this.btnOpenHelpdesk = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // nIcon
            // 
            this.nIcon.BalloonTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            this.nIcon.BalloonTipText = "Notifier has been minimized to System Tray";
            this.nIcon.BalloonTipTitle = "Helpdesk Notifier";
            this.nIcon.Icon = ((System.Drawing.Icon)(resources.GetObject("nIcon.Icon")));
            this.nIcon.Text = "Raubex Helpdesk";
            this.nIcon.BalloonTipClicked += new System.EventHandler(this.nIcon_BalloonTipClicked);
            this.nIcon.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.nIcon_MouseDoubleClick);
            // 
            // lblMaxValue
            // 
            this.lblMaxValue.AutoSize = true;
            this.lblMaxValue.Location = new System.Drawing.Point(12, 9);
            this.lblMaxValue.Name = "lblMaxValue";
            this.lblMaxValue.Size = new System.Drawing.Size(35, 13);
            this.lblMaxValue.TabIndex = 0;
            this.lblMaxValue.Text = "label1";
            // 
            // btnOpenHelpdesk
            // 
            this.btnOpenHelpdesk.Location = new System.Drawing.Point(15, 25);
            this.btnOpenHelpdesk.Name = "btnOpenHelpdesk";
            this.btnOpenHelpdesk.Size = new System.Drawing.Size(100, 23);
            this.btnOpenHelpdesk.TabIndex = 1;
            this.btnOpenHelpdesk.Text = "Open Helpdesk";
            this.btnOpenHelpdesk.UseVisualStyleBackColor = true;
            this.btnOpenHelpdesk.Click += new System.EventHandler(this.btnOpenHelpdesk_Click);
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.Controls.Add(this.btnOpenHelpdesk);
            this.Controls.Add(this.lblMaxValue);
            this.Name = "Main";
            this.Text = "Helpdesk Notifier";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.Resize += new System.EventHandler(this.Form1_Resize);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.NotifyIcon nIcon;
        private System.Windows.Forms.Label lblMaxValue;
        private System.Windows.Forms.Button btnOpenHelpdesk;
    }
}


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
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openHelpdeskToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.lblMaxValue = new System.Windows.Forms.Label();
            this.btnOpenHelpdesk = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.enableDisableProxyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.contextMenuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // nIcon
            // 
            this.nIcon.BalloonTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            this.nIcon.BalloonTipText = "Notifier has been minimized to System Tray";
            this.nIcon.BalloonTipTitle = "Helpdesk Notifier";
            this.nIcon.ContextMenuStrip = this.contextMenuStrip1;
            this.nIcon.Icon = ((System.Drawing.Icon)(resources.GetObject("nIcon.Icon")));
            this.nIcon.Text = "Raubex Helpdesk";
            this.nIcon.BalloonTipClicked += new System.EventHandler(this.nIcon_BalloonTipClicked);
            this.nIcon.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.nIcon_MouseDoubleClick);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.exitToolStripMenuItem,
            this.openHelpdeskToolStripMenuItem,
            this.enableDisableProxyToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(185, 70);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(184, 22);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // openHelpdeskToolStripMenuItem
            // 
            this.openHelpdeskToolStripMenuItem.Name = "openHelpdeskToolStripMenuItem";
            this.openHelpdeskToolStripMenuItem.Size = new System.Drawing.Size(184, 22);
            this.openHelpdeskToolStripMenuItem.Text = "Open Helpdesk";
            this.openHelpdeskToolStripMenuItem.Click += new System.EventHandler(this.btnOpenHelpdesk_Click);
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
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(15, 54);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(645, 496);
            this.dataGridView1.TabIndex = 2;
            // 
            // enableDisableProxyToolStripMenuItem
            // 
            this.enableDisableProxyToolStripMenuItem.Name = "enableDisableProxyToolStripMenuItem";
            this.enableDisableProxyToolStripMenuItem.Size = new System.Drawing.Size(184, 22);
            this.enableDisableProxyToolStripMenuItem.Text = "Enable\\Disable Proxy";
            this.enableDisableProxyToolStripMenuItem.Click += new System.EventHandler(this.enableProxyToolStripMenuItem_Click);
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(672, 562);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.btnOpenHelpdesk);
            this.Controls.Add(this.lblMaxValue);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Main";
            this.Text = "Helpdesk Notifier";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.Resize += new System.EventHandler(this.Form1_Resize);
            this.contextMenuStrip1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.NotifyIcon nIcon;
        private System.Windows.Forms.Label lblMaxValue;
        private System.Windows.Forms.Button btnOpenHelpdesk;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openHelpdeskToolStripMenuItem;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.ToolStripMenuItem enableDisableProxyToolStripMenuItem;
    }
}


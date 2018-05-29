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
            this.lblMaxValue = new System.Windows.Forms.Label();
            this.btnOpenHelpdesk = new System.Windows.Forms.Button();
            this.lbCalls = new System.Windows.Forms.ListBox();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openHelpdeskToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.enableDisableProxyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.nIcon = new System.Windows.Forms.NotifyIcon(this.components);
            this.lblCallNr = new System.Windows.Forms.Label();
            this.txtCallNr = new System.Windows.Forms.TextBox();
            this.btnSearchCall = new System.Windows.Forms.Button();
            this.dtpREQ = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.autoChangeProxyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
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
            this.btnOpenHelpdesk.Click += new System.EventHandler(this.BtnOpenHelpdesk_Click);
            // 
            // lbCalls
            // 
            this.lbCalls.FormattingEnabled = true;
            this.lbCalls.Location = new System.Drawing.Point(15, 54);
            this.lbCalls.Name = "lbCalls";
            this.lbCalls.Size = new System.Drawing.Size(100, 381);
            this.lbCalls.TabIndex = 2;
            this.lbCalls.SelectedIndexChanged += new System.EventHandler(this.LbCalls_SelectedIndexChanged);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(184, 22);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.ExitToolStripMenuItem_Click);
            // 
            // openHelpdeskToolStripMenuItem
            // 
            this.openHelpdeskToolStripMenuItem.Name = "openHelpdeskToolStripMenuItem";
            this.openHelpdeskToolStripMenuItem.Size = new System.Drawing.Size(184, 22);
            this.openHelpdeskToolStripMenuItem.Text = "Open Helpdesk";
            this.openHelpdeskToolStripMenuItem.Click += new System.EventHandler(this.BtnOpenHelpdesk_Click);
            // 
            // enableDisableProxyToolStripMenuItem
            // 
            this.enableDisableProxyToolStripMenuItem.Name = "enableDisableProxyToolStripMenuItem";
            this.enableDisableProxyToolStripMenuItem.Size = new System.Drawing.Size(184, 22);
            this.enableDisableProxyToolStripMenuItem.Text = "Enable\\Disable Proxy";
            this.enableDisableProxyToolStripMenuItem.Click += new System.EventHandler(this.EnableProxyToolStripMenuItem_Click);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openHelpdeskToolStripMenuItem,
            this.enableDisableProxyToolStripMenuItem,
            this.autoChangeProxyToolStripMenuItem,
            this.exitToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(185, 92);
            // 
            // nIcon
            // 
            this.nIcon.BalloonTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            this.nIcon.BalloonTipText = "Notifier has been minimized to System Tray";
            this.nIcon.BalloonTipTitle = "Helpdesk Notifier";
            this.nIcon.ContextMenuStrip = this.contextMenuStrip1;
            this.nIcon.Icon = ((System.Drawing.Icon)(resources.GetObject("nIcon.Icon")));
            this.nIcon.Text = "Raubex Helpdesk";
            this.nIcon.BalloonTipClicked += new System.EventHandler(this.NIcon_BalloonTipClicked);
            this.nIcon.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.NIcon_MouseDoubleClick);
            // 
            // lblCallNr
            // 
            this.lblCallNr.AutoSize = true;
            this.lblCallNr.Location = new System.Drawing.Point(121, 54);
            this.lblCallNr.Name = "lblCallNr";
            this.lblCallNr.Size = new System.Drawing.Size(34, 13);
            this.lblCallNr.TabIndex = 4;
            this.lblCallNr.Text = "Call# ";
            // 
            // txtCallNr
            // 
            this.txtCallNr.Location = new System.Drawing.Point(209, 51);
            this.txtCallNr.Name = "txtCallNr";
            this.txtCallNr.Size = new System.Drawing.Size(100, 20);
            this.txtCallNr.TabIndex = 5;
            // 
            // btnSearchCall
            // 
            this.btnSearchCall.Location = new System.Drawing.Point(315, 49);
            this.btnSearchCall.Name = "btnSearchCall";
            this.btnSearchCall.Size = new System.Drawing.Size(75, 23);
            this.btnSearchCall.TabIndex = 6;
            this.btnSearchCall.Text = "Search";
            this.btnSearchCall.UseVisualStyleBackColor = true;
            // 
            // dtpREQ
            // 
            this.dtpREQ.Enabled = false;
            this.dtpREQ.Location = new System.Drawing.Point(211, 89);
            this.dtpREQ.Name = "dtpREQ";
            this.dtpREQ.Size = new System.Drawing.Size(200, 20);
            this.dtpREQ.TabIndex = 7;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(120, 95);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(85, 13);
            this.label1.TabIndex = 8;
            this.label1.Text = "Requested Date";
            // 
            // autoChangeProxyToolStripMenuItem
            // 
            this.autoChangeProxyToolStripMenuItem.Name = "autoChangeProxyToolStripMenuItem";
            this.autoChangeProxyToolStripMenuItem.Size = new System.Drawing.Size(184, 22);
            this.autoChangeProxyToolStripMenuItem.Text = "Auto Change Proxy";
            this.autoChangeProxyToolStripMenuItem.Click += new System.EventHandler(this.autoChangeProxyToolStripMenuItem_Click);
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(424, 450);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dtpREQ);
            this.Controls.Add(this.btnSearchCall);
            this.Controls.Add(this.txtCallNr);
            this.Controls.Add(this.lblCallNr);
            this.Controls.Add(this.lbCalls);
            this.Controls.Add(this.btnOpenHelpdesk);
            this.Controls.Add(this.lblMaxValue);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Main";
            this.Text = "Helpdesk Notifier";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.Resize += new System.EventHandler(this.Form1_Resize);
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label lblMaxValue;
        private System.Windows.Forms.Button btnOpenHelpdesk;
        private System.Windows.Forms.ListBox lbCalls;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openHelpdeskToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem enableDisableProxyToolStripMenuItem;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.NotifyIcon nIcon;
        private System.Windows.Forms.Label lblCallNr;
        private System.Windows.Forms.TextBox txtCallNr;
        private System.Windows.Forms.Button btnSearchCall;
        private System.Windows.Forms.DateTimePicker dtpREQ;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ToolStripMenuItem autoChangeProxyToolStripMenuItem;
    }
}


using System;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Net.NetworkInformation;
using System.Security.Principal;
using System.Timers;
using System.Windows.Forms;
using HelpdeskDesktopNotify.Properties;
using Timer = System.Timers.Timer;

namespace HelpdeskDesktopNotify
{
    public partial class Main : Form
    {
        private const string V = "Notifier has been minimized to System Tray";

        public string UserName { get; set; } = "";
        public int MaxValue { get; set; }
        public bool IsNetworkAvailable { get; set; } = true;

        public Main()
        {
            InitializeComponent();

            NetworkChange.NetworkAvailabilityChanged += NetworkChange_NetworkAvailabilityChanged;
            NetworkChange.NetworkAddressChanged += NetworkChange_NetworkAddressChanged;
        }

        private void Form1_Resize(object sender, EventArgs e)
        {
            if (WindowState != FormWindowState.Minimized) return;
            ShowInTaskbar = false;
            nIcon.Visible = true;
            if (Settings.Default.ShowMinimize != true) return;
            nIcon.BalloonTipText = V;
            nIcon.ShowBalloonTip(1000);
            Settings.Default.ShowMinimize = false;
            Settings.Default.Save();
        }

        private void NIcon_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            ShowInTaskbar = true;
            nIcon.Visible = false;
            WindowState = FormWindowState.Normal;
        }

        private void Form1_Load(object sender, EventArgs e)
        {

            WindowState = FormWindowState.Minimized;
            UserName = WindowsIdentity.GetCurrent().Name;
            MaxValue = GetLastRequestId();
            lbCalls.DisplayMember = "id";
            lbCalls.ValueMember = "id";
            lbCalls.DataSource = GetRequests();
            if (Settings.Default.ProxyEnabled == 0)
                enableDisableProxyToolStripMenuItem.Text = "Enable Proxy";
            else
                enableDisableProxyToolStripMenuItem.Text = "Disable Proxy";

            if (Settings.Default.AutoChangeProxyEnabled)
                autoChangeProxyToolStripMenuItem.Text = "Disable Auto Proxy";
            else
                autoChangeProxyToolStripMenuItem.Text = "Enable Auto Proxy";

            lblMaxValue.Text = "Your latest Helpdesk Call is: " + MaxValue;
            var timer = new Timer(60000);

            // Hook up the Elapsed event for the timer.
            timer.Elapsed += Timer_Elapsed;

            timer.Enabled = true;
        }

        private void NetworkChange_NetworkAvailabilityChanged(object sender, NetworkAvailabilityEventArgs e)
        {
            IsNetworkAvailable = e.IsAvailable;
        }

        private void NetworkChange_NetworkAddressChanged(object sender, EventArgs e)
        {
            if (IsNetworkAvailable && Settings.Default.AutoChangeProxyEnabled)
            {
                Proxy.SetProxy();
            }
        }

        private void Timer_Elapsed(object sender, ElapsedEventArgs e)
        {
            var value = GetLastRequestId();
            lbCalls.DisplayMember = "id";
            lbCalls.ValueMember = "id";
            lbCalls.DataSource = GetRequests();
            if (MaxValue >= value || value <= 0) return;
            nIcon.BalloonTipText = "Call " + value + " has been assign to you. " + UserName;
            nIcon.ShowBalloonTip(5000);
            lblMaxValue.BeginInvoke((MethodInvoker)delegate
                { lblMaxValue.Text = "Your latest Helpdesk Call is: " + MaxValue; ; });
            MaxValue = value;
        }

        private int GetLastRequestId()
        {
            try
            {
                if (!IsNetworkAvailable || !Proxy.PingHost("10.1.1.7")) return 0;
                using (var connection = new SqlConnection(Settings.Default.ConnectionString))
                {
                    connection.Open();
                    var query = "SELECT Max([id]) as Latest FROM [RAUBEX_HELPDESK].[dbo].[REQUESTS_TBL] where responsibility = '" + UserName.Remove(0, 4) + "'";
                    using (var command = new SqlCommand(query, connection))
                    {
                        return (int)command.ExecuteScalar();
                    }
                }
            }
            catch
            {
                return 0;
            }
        }

        private DataTable GetRequests()
        {
            try
            {
                if (!IsNetworkAvailable || !Proxy.PingHost("10.1.1.7")) return null;
                using (var connection = new SqlConnection(Settings.Default.ConnectionString))
                {
                    connection.Open();
                    var query = "SELECT * FROM [RAUBEX_HELPDESK].[dbo].[REQUESTS_TBL] where responsibility = '" + UserName.Remove(0, 4) + "' and Status <> 3 and deleted = 0 order by id";
                    using (var command = new SqlCommand(query, connection))
                    {
                        var data = new DataTable();
                        data.Load(command.ExecuteReader());
                        return data;
                    }
                }
            }
            catch
            {
                return null;
            }
        }

        private void NIcon_BalloonTipClicked(object sender, EventArgs e)
        {
            var sInfo = new ProcessStartInfo("https://helpdesk.raubex.com/LoginB.aspx?iREQNUMB=" + MaxValue);
            Process.Start(sInfo);
        }

        private void BtnOpenHelpdesk_Click(object sender, EventArgs e)
        {
            var sInfo = new ProcessStartInfo("https://helpdesk.raubex.com");
            Process.Start(sInfo);
        }

        private void ExitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void EnableProxyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (IsNetworkAvailable)
                Proxy.SetProxy();
        }

        private void LbCalls_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtCallNr.Text = ((DataRowView)lbCalls.Items[lbCalls.SelectedIndex])["id"].ToString();
            dtpREQ.Value = (DateTime)((DataRowView)lbCalls.Items[lbCalls.SelectedIndex])["insert_time"];
        }

        private void autoChangeProxyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Settings.Default.AutoChangeProxyEnabled)
                Settings.Default.AutoChangeProxyEnabled = false;
            else
                Settings.Default.AutoChangeProxyEnabled = true;

            Settings.Default.Save();
        }
    }


}

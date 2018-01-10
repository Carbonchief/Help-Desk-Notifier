using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using System.Windows.Forms;


namespace HelpdeskDesktopNotify
{
    public partial class Main : Form
    {
        string userName = "";
        int MaxValue = 0;
        bool MinimizedShown = false;
        public Main()
        {
            InitializeComponent();
        }

        private void Form1_Resize(object sender, EventArgs e)
        {
            if (WindowState == FormWindowState.Minimized)
            {
                ShowInTaskbar = false;
                nIcon.Visible = true;
                if (MinimizedShown == false)
                {
                    nIcon.BalloonTipText = "Notifier has been minimized to System Tray";
                    nIcon.ShowBalloonTip(1000);
                    MinimizedShown = true;
                }

            }
        }

        private void nIcon_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            ShowInTaskbar = true;
            nIcon.Visible = false;
            WindowState = FormWindowState.Normal;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
            userName = System.Security.Principal.WindowsIdentity.GetCurrent().Name;
            MaxValue = GetData();
            lblMaxValue.Text = "Your latest Helpdesk Call is: " + MaxValue.ToString();
            var timer = new System.Timers.Timer(60000);

            // Hook up the Elapsed event for the timer.
            timer.Elapsed += Timer_Elapsed;

            timer.Enabled = true;
        }

        private void Timer_Elapsed(object sender, ElapsedEventArgs e)
        {
            var value = GetData();
            if (MaxValue < value && value > 0)
            {
                nIcon.BalloonTipText = "Call " + value + " has been assign to you. " + userName;
                nIcon.ShowBalloonTip(5000);
                lblMaxValue.BeginInvoke((MethodInvoker)delegate () { lblMaxValue.Text = "Your latest Helpdesk Call is: " + MaxValue.ToString(); ; });
            }
        }

        private int GetData()
        {
            try
            {
                using (SqlConnection connection = new SqlConnection("Server=10.1.1.7;Database=RAUBEX_HELPDESK;Trusted_Connection=True;"))
                {
                    connection.Open();
                    string query = "SELECT Max([id]) as Latest FROM [RAUBEX_HELPDESK].[dbo].[REQUESTS_TBL] where responsibility = '" + userName.Remove(0, 4) + "'";
                    using (SqlCommand command = new SqlCommand(query, connection))
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

        private DataTable GetDataTable(string SQL)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection("Server=10.1.1.7;Database=RAUBEX_HELPDESK;Trusted_Connection=True;"))
                {
                    connection.Open();
                    string query = SQL;
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {

                        DataTable t1 = new DataTable();
                        using (SqlDataAdapter a = new SqlDataAdapter(command))
                        {
                            a.Fill(t1);
                            return t1;
                        }

                    }
                }
            }
            catch
            {
                return null;
            }
        }

        private void nIcon_BalloonTipClicked(object sender, EventArgs e)
        {
            ProcessStartInfo sInfo = new ProcessStartInfo("https://helpdesk.raubex.com/Submitrequest.aspx?iREQNUMB=" + MaxValue);
            Process.Start(sInfo);
        }

        private void btnOpenHelpdesk_Click(object sender, EventArgs e)
        {
            ProcessStartInfo sInfo = new ProcessStartInfo("https://helpdesk.raubex.com");
            Process.Start(sInfo);
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void enableProxyToolStripMenuItem_Click(object sender, EventArgs e)
        {           

            RegistryKey ProxyServer = Registry.CurrentUser.OpenSubKey(@"Software\Microsoft\Windows\CurrentVersion\Internet Settings", true);
            if (ProxyServer != null)
            {
                ProxyServer.SetValue("ProxyServer", GetProxyServer(), RegistryValueKind.String);
                ProxyServer.Close();
            }
           
            RegistryKey ProxyOverride = Registry.CurrentUser.OpenSubKey(@"Software\Microsoft\Windows\CurrentVersion\Internet Settings", true);
            if (ProxyOverride != null)
            {
                ProxyOverride.SetValue("ProxyOverride", GetProxyOverride(), RegistryValueKind.String);
                ProxyOverride.Close();
            }

            RegistryKey AutoDetect = Registry.CurrentUser.OpenSubKey(@"Software\Microsoft\Windows\CurrentVersion\Internet Settings", true);
            if (AutoDetect != null)
            {
                AutoDetect.SetValue("AutoDetect", "0", RegistryValueKind.DWord);
                AutoDetect.Close();
            }

            RegistryKey ProxyEnable = Registry.CurrentUser.OpenSubKey(@"Software\Microsoft\Windows\CurrentVersion\Internet Settings", true);
            if (ProxyEnable != null)
            {
                var Enabled = ProxyEnable.GetValue("ProxyEnable").ToString();
                if(Enabled== "0")
                {
                    ProxyEnable.SetValue("ProxyEnable", "1", RegistryValueKind.DWord);
                    MessageBox.Show("Enabled");
                }
                else
                {
                    ProxyEnable.SetValue("ProxyEnable", "0", RegistryValueKind.DWord);
                    MessageBox.Show("Disabled");
                }                
                ProxyEnable.Close();
            }

        }

        public string GetProxyServer()
        {
            return "02RX - Proxy01.rbx.raubex.com:8080";
        }

        public string GetProxyOverride()
        {
            return " * rx *; *.raubex.*; 10.*.*.* ";
        }


    }


}

using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Net.Sockets;
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
            MaxValue = GetLastRequestId();
            lbCalls.DisplayMember = "id";
            lbCalls.ValueMember = "id";
            lbCalls.DataSource = GetRequests();

           
            lblMaxValue.Text = "Your latest Helpdesk Call is: " + MaxValue.ToString();
            var timer = new System.Timers.Timer(60000);

            // Hook up the Elapsed event for the timer.
            timer.Elapsed += Timer_Elapsed;

            timer.Enabled = true;
        }

        private void Timer_Elapsed(object sender, ElapsedEventArgs e)
        {
            var value = GetLastRequestId();
            lbCalls.DisplayMember = "id";
            lbCalls.ValueMember = "id";
            lbCalls.DataSource = GetRequests();
            if (MaxValue < value && value > 0)
            {
                nIcon.BalloonTipText = "Call " + value + " has been assign to you. " + userName;
                nIcon.ShowBalloonTip(5000);
                lblMaxValue.BeginInvoke((MethodInvoker)delegate () { lblMaxValue.Text = "Your latest Helpdesk Call is: " + MaxValue.ToString(); ; });
                MaxValue = value;
            }
        }

        private int GetLastRequestId()
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
                return 0;            }
        }

        private DataTable GetRequests()
        {
            try
            {
                using (SqlConnection connection = new SqlConnection("Server=10.1.1.7;Database=RAUBEX_HELPDESK;Trusted_Connection=True;"))
                {
                    connection.Open();
                    string query = "SELECT * FROM [RAUBEX_HELPDESK].[dbo].[REQUESTS_TBL] where responsibility = '" + userName.Remove(0, 4) + "' and Status <> 3 and deleted = 0 order by id";
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        var Data = new DataTable();
                        Data.Load(command.ExecuteReader());
                        return Data;                              
                    }
                }
            }
            catch
            {
                return null;
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
            Proxy.SetProxy();          

        }

        private void lbCalls_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtCallNr.Text = ((DataRowView)lbCalls.Items[lbCalls.SelectedIndex])["id"].ToString();
            dtpREQ.Value = (DateTime)((DataRowView)lbCalls.Items[lbCalls.SelectedIndex])["insert_time"];

            //MessageBox.Show(((DataRowView)lbCalls.Items[lbCalls.SelectedIndex])["description"].ToString());
        }
    }


}

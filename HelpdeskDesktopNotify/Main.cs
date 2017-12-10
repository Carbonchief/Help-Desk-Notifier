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
                nIcon.BalloonTipText = "Notifier has been minimized to System Tray";
                nIcon.ShowBalloonTip(1000);
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
            if (MaxValue < value)
            {
                nIcon.BalloonTipText = "Call " + value + " has been assign to you. " + userName;
                nIcon.ShowBalloonTip(1000);
                MaxValue = value;
                lblMaxValue.BeginInvoke((MethodInvoker)delegate () { lblMaxValue.Text = "Your latest Helpdesk Call is: " + MaxValue.ToString(); ; });
            }
        }

        private int GetData()
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
    }


}

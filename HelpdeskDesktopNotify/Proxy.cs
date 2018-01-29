using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace HelpdeskDesktopNotify
{
   public static class Proxy
    {



        public static void SetProxy()
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
                if (Enabled == "0")
                {
                    ProxyEnable.SetValue("ProxyEnable", "1", RegistryValueKind.DWord);                 
                }
                else
                {
                    ProxyEnable.SetValue("ProxyEnable", "0", RegistryValueKind.DWord);                   
                }
                ProxyEnable.Close();
            }

        }




        private static string GetProxyServer()
        {
            try
            {
                using (SqlConnection connection = new SqlConnection("Server=10.1.1.60;Database=RAUBEX_HELPDESK;Trusted_Connection=True;"))
                {
                    connection.Open();
                    string query = "SELECT [pProxyAddress] FROM [RAUBEX_HELPDESK].[dbo].[ProxyList] where pip =  '" + GetIP() + "'";
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        var ProxyServer = (string)command.ExecuteScalar();
                        return ProxyServer;
                    }
                }
            }
            catch
            {
                return null;
            }


            //return @"02RX-Proxy01.rbx.raubex.com:8080";
        }

        private static string GetIP()
        {
            string LocalIP = "";
            using (Socket socket = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, 0))
            {
                socket.Connect("8.8.8.8", 65530);
                IPEndPoint endPoint = socket.LocalEndPoint as IPEndPoint;
                LocalIP = endPoint.Address.ToString();
            }

            var IpOctets = LocalIP.Split('.');
            return IpOctets[0] + "." + IpOctets[1];
        }

        private static string GetProxyOverride()
        {
            try
            {
                using (SqlConnection connection = new SqlConnection("Server=10.1.1.60;Database=RAUBEX_HELPDESK;Trusted_Connection=True;"))
                {
                    connection.Open();
                    string query = "SELECT [pProxyOveride] FROM [RAUBEX_HELPDESK].[dbo].[ProxyList] where pip =  '" + GetIP() + "'";
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        var ProxyOveride = (string)command.ExecuteScalar();
                        return ProxyOveride;
                    }
                }
            }
            catch
            {
                return null;
            }
        }

    }
}

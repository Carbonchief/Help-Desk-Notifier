using HelpdeskDesktopNotify.Properties;
using Microsoft.Win32;
using System;
using System.Data.SqlClient;
using System.Net;
using System.Net.NetworkInformation;
using System.Net.Sockets;
using System.Runtime.InteropServices;
namespace HelpdeskDesktopNotify
{
    public static class Proxy
    {
        [DllImport("wininet.dll")]
        public static extern bool InternetSetOption(IntPtr hInternet, int dwOption, IntPtr lpBuffer, int dwBufferLength);
        public const int InternetOptionSettingsChanged = 39;
        public const int InternetOptionRefresh = 37;
        private const string RegisteryLocation = @"Software\Microsoft\Windows\CurrentVersion\Internet Settings";


        public static void SetProxy()
        {
            var proxyServer = Registry.CurrentUser.OpenSubKey(RegisteryLocation, true);
            if (proxyServer != null)
            {
                proxyServer.SetValue("ProxyServer", GetProxyServer(), RegistryValueKind.String);
                proxyServer.Close();
            }

            var proxyOverride = Registry.CurrentUser.OpenSubKey(RegisteryLocation, true);
            if (proxyOverride != null)
            {
                proxyOverride.SetValue("ProxyOverride", GetProxyOverride(), RegistryValueKind.String);
                proxyOverride.Close();
            }

            var autoDetect = Registry.CurrentUser.OpenSubKey(RegisteryLocation, true);
            if (autoDetect != null)
            {
                autoDetect.SetValue("AutoDetect", "0", RegistryValueKind.DWord);
                autoDetect.Close();
            }

            //Check Which setting needs to be set
            if (Settings.Default.ProxyEnabled == 0)
            {
                Settings.Default.ProxyEnabled = 1;
            }
            else
                Settings.Default.ProxyEnabled = 0;
            Settings.Default.Save();


            var proxyEnable = Registry.CurrentUser.OpenSubKey(RegisteryLocation, true);
            if (proxyEnable != null)
            {
                var enabled = proxyEnable.GetValue("ProxyEnable").ToString();
                proxyEnable.SetValue("ProxyEnable", Settings.Default.ProxyEnabled, RegistryValueKind.DWord);
                proxyEnable.Close();
            }



            InternetSetOption(IntPtr.Zero, InternetOptionSettingsChanged, IntPtr.Zero, 0);
            InternetSetOption(IntPtr.Zero, InternetOptionRefresh, IntPtr.Zero, 0);

        }




        private static string GetProxyServer()
        {
            try
            {
                if (PingHost("10.1.1.7"))
                {
                    using (var connection = new SqlConnection(Settings.Default.ConnectionString))
                    {
                        connection.Open();
                        var query = "SELECT [pProxyAddress] FROM [RAUBEX_HELPDESK].[dbo].[ProxyList] where pip =  '" + GetIp() + "'";
                        using (var command = new SqlCommand(query, connection))
                        {
                            var proxyServer = (string)command.ExecuteScalar();
                            return proxyServer;
                        }
                    }
                }
                else
                {
                    return @"02RX-Proxy01.rbx.raubex.com:8080";
                }
            }
            catch
            {
                return @"02RX-Proxy01.rbx.raubex.com:8080";
            }
        }

        private static string GetIp()
        {
            string localIp;
            using (var socket = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, 0))
            {
                socket.Connect("8.8.8.8", 65530);
                var endPoint = socket.LocalEndPoint as IPEndPoint;
                localIp = endPoint.Address.ToString();
            }

            var ipOctets = localIp.Split('.');
            return ipOctets[0] + "." + ipOctets[1];
        }

        private static string GetProxyOverride()
        {
            try
            {
                if (PingHost("10.1.1.7"))
                {
                    using (var connection = new SqlConnection(Settings.Default.ConnectionString))
                    {
                        connection.Open();
                        var query = "SELECT [pProxyOveride] FROM [RAUBEX_HELPDESK].[dbo].[ProxyList] where pip =  '" + GetIp() + "'";
                        using (var command = new SqlCommand(query, connection))
                        {
                            var proxyOveride = (string)command.ExecuteScalar();
                            if (Settings.Default.BypassLocal == true)
                                return proxyOveride + ";<value>";
                            else
                                return proxyOveride;
                        }
                    }
                }
                else
                {
                    return "*rx*;*.raubex.*;10.*.*.*";
                }
            }
            catch (Exception)
            {
                return "*rx*;*.raubex.*;10.*.*.*";
            }
        }

        public static bool PingHost(string nameOrAddress)
        {
            bool pingable = false;
            Ping pinger = new Ping();
            try
            {
                PingReply reply = pinger.Send(nameOrAddress);
                pingable = reply.Status == IPStatus.Success;
            }
            catch (PingException)
            {
                // Discard PingExceptions and return false;
            }
            return pingable;
        }

    }
}

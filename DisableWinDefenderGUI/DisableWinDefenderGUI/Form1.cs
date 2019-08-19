using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DisableWinDefenderGUI
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Github: praguez \nDiscord: xkm#0979", "Credits", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            RegistryKey key1 = Registry.LocalMachine.OpenSubKey(@"SOFTWARE\\Policies\\Microsoft\\Windows Defender\\", RegistryKeyPermissionCheck.ReadWriteSubTree);
            RegistryKey key2 = Registry.LocalMachine.OpenSubKey(@"SOFTWARE\\Policies\\Microsoft\\Windows Defender\\Signature Updates\\", RegistryKeyPermissionCheck.ReadWriteSubTree);
            RegistryKey key3 = Registry.LocalMachine.OpenSubKey(@"SOFTWARE\\Policies\\Microsoft\\Windows Defender\\Real-Time Protection\\", RegistryKeyPermissionCheck.ReadWriteSubTree);


            if (key1 != null || key2 != null || key3 != null)
            {

                try
                {
                    key1.SetValue("DisableAntiSpyware", 00000001);
                    key1.SetValue("ServiceKeepAlive", 00000000);
                }
                catch
                {
                    MessageBox.Show("Can't find DisableAntiSpyware or ServiceKeepAlive", "Error 1", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                try
                {
                    key2.SetValue("ForceUpdateFromMU", 00000000);
                    key2.SetValue("UpdateOnStartUp", 00000000);
                    key2.Close();
                }
                catch
                {
                    MessageBox.Show("Can't find ForceUpdate or UpdateOnStartUp", "Error 2", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }

                try
                {
                    key3.SetValue("DisableBehaviorMonitoring", 00000001);
                    key3.SetValue("DisableOnAccessProtection", 00000001);
                    key3.SetValue("DisableScanOnRealtimeEnable", 00000001);
                }
                catch
                {
                    MessageBox.Show("Can't find DisableBehaviorMonitoring or DisableOnAccessProtection or DisableScanOnRealtimeEnable", "Error 3", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }


                









            }
            else
            {
                Console.WriteLine("Não existe");
                MessageBox.Show("Can't find any registry key.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Console.ReadLine();
            }












        }

        private void Button3_Click(object sender, EventArgs e)
        {
            MessageBox.Show("If you tried to desactivate Windows Defender and Error 2 or Error 3 appeared on Screen you just desactivated Real Time Protection!", "Errors?", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void NotifyIcon1_MouseDoubleClick(object sender, MouseEventArgs e)
        {

        }
    }
}

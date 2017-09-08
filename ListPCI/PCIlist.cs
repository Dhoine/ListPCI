using System;
using System.Management;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace ListPCI
{
    public partial class Pcilist : Form
    {
        public Pcilist()
        {
            InitializeComponent();
        }

        /// <summary>
        ///     Event handler that gets list of PCI devices and adds them as items of list box after loading form.
        /// </summary>
        /// <param name="sender" />
        /// <param name="e" />
        private void Pcilist_Load(object sender, EventArgs e)
        {
            var connectionScope = new ManagementScope();
            var serialQuery = new SelectQuery("SELECT * FROM Win32_PnPEntity");
            var searcher = new ManagementObjectSearcher(connectionScope, serialQuery);
            var dev = new Regex("DEV_.{4}");
            var ven = new Regex("VEN_.{4}");
            try
            {
                foreach (var item in searcher.Get())
                {
                    var deviceId = item["DeviceID"].ToString();
                    if (deviceId.Contains("PCI"))
                        ID_List.Items.Add("Device ID: " + dev.Match(deviceId).Value.Substring(4)
                                          + ", Vendor ID: " + ven.Match(deviceId).Value.Substring(4) + "\t"
                                          + item["Description"]);
                }
            }
            catch (ManagementException)
            {
                ID_List.Items.Add("Failed to get information from WMI");
            }
        }
    }
}
using System;
using System.IO;
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
            var provider = new PciProvider();
            try
            {
                foreach (var dev in provider.GetDevices())
                    ID_List.Items.Add(dev[0].PadRight(100 - dev[0].Length) + "\t\t\t" + dev[1]);
            }
            catch (FileNotFoundException ex)
            {
                ID_List.Items.Add(ex.Message);
            }
        }
    }
}
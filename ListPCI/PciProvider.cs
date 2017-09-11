using System;
using System.Collections.Generic;
using System.IO;
using System.Management;
using System.Text.RegularExpressions;

namespace ListPCI
{
    public class PciProvider
    {
        /// <summary>
        /// Method for listing all pci devices
        /// </summary>
        /// <returns>List of Lists with device/vendor id pair</returns>
        public List<List<string>> GetDevices()
        {
            var connectionScope = new ManagementScope();
            var serialQuery = new SelectQuery("SELECT * FROM Win32_PnPEntity");
            var searcher = new ManagementObjectSearcher(connectionScope, serialQuery);
            var dev = new Regex("DEV_.{4}");
            var ven = new Regex("VEN_.{4}");
            var buffer = new List<List<string>>();
            try
            {
                foreach (var item in searcher.Get())
                {
                    var deviceId = item["DeviceID"].ToString();
                    if (deviceId.Contains("PCI"))
                        try
                        {
                            buffer.Add(SearchInFile(dev.Match(deviceId).Value.Substring(4).ToLower(),
                                ven.Match(deviceId).Value.Substring(4).ToLower()));
                        }
                        catch (FileNotFoundException e)
                        {
                            Console.WriteLine(e);
                            throw;
                        }
                }
            }
            catch (ManagementException)
            {
                return null;
            }
            return buffer;
        }

        /// <summary>
        /// Search for given vendor and device id
        /// </summary>
        /// <param name="dev">DeviceID</param>
        /// <param name="ven">VendorID</param>
        /// <returns>List with 2 strings: vendor and device name</returns>
        private static List<string> SearchInFile(string dev, string ven)
        {
            var result = new List<string>();
            var vendorFound = false;
            var deviceFound = false;
            if (!File.Exists("pci.ids"))
                throw new FileNotFoundException("pci.ids should be in same dir as executable");

            var file = new StreamReader("pci.ids");
            var vendor = new Regex("^" + ven + "  ");
            var device = new Regex("^\\t" + dev + "  ");
            while (!file.EndOfStream)
            {
                var bufferVendor = file.ReadLine();
                if (bufferVendor != null && vendor.Match(bufferVendor).Success)
                {
                    result.Add("VendorID: " + ven + " (" + bufferVendor.Substring(6) + ")");
                    vendorFound = true;
                    while (!file.EndOfStream)
                    {
                        var bufferDevice = file.ReadLine();
                        if (bufferDevice == null || !device.Match(bufferDevice).Success)
                            continue;

                        result.Add("DeviceID: " + dev + " (" + bufferDevice.Substring(7) + ")");
                        deviceFound = true;
                        break;
                    }
                }
            }
            if (!vendorFound)
            {
                result.Add("Device with VendorID " + ven + " and DeviceID " + dev + "wasn't found in base");
                result.Add("");
            }

            if (!deviceFound)
                result.Add("DeviceID: " + dev + " (name can't be found in base");

            return result;
        }
    }
}
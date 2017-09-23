using System.Collections;
using System.Management;
using System.Security.Permissions;

namespace BaseLibrary.Network
{
    /// <summary>
    ///     A Helper class which provides convenient methods to set/get network
    ///     configuration
    /// </summary>
    public class WMIHelper
    {
        /// <summary>
        ///     Enable DHCP on the NIC
        /// </summary>
        /// <param name="nicName">Name of the NIC</param>
        public static void SetDHCP(string nicName)
        {
            var mc = new ManagementClass("Win32_NetworkAdapterConfiguration");
            var moc = mc.GetInstances();

            foreach (ManagementObject mo in moc)
            {
                // Make sure this is a IP enabled device. Not something like memory card or VM Ware
                if ((bool) mo["IPEnabled"])
                {
                    if (mo["Caption"].Equals(nicName))
                    {
                        var newDNS = mo.GetMethodParameters("SetDNSServerSearchOrder");
                        newDNS["DNSServerSearchOrder"] = null;
                        var enableDHCP = mo.InvokeMethod("EnableDHCP", null, null);
                        var setDNS = mo.InvokeMethod("SetDNSServerSearchOrder", newDNS, null);
                    }
                }
            }
        }

        /// <summary>
        ///     Set IP for the specified network card name
        /// </summary>
        /// <param name="nicName">Caption of the network card</param>
        /// <param name="IpAddresses">Comma delimited string containing one or more IP</param>
        /// <param name="SubnetMask">Subnet mask</param>
        /// <param name="Gateway">Gateway IP</param>
        /// <param name="DnsSearchOrder">Comma delimited DNS IP</param>
        public static void SetIP(string nicName, string IpAddresses, string SubnetMask, string Gateway = null,
            string DnsSearchOrder = null)
        {
            var mc = new ManagementClass("Win32_NetworkAdapterConfiguration");
            var moc = mc.GetInstances();

            foreach (ManagementObject mo in moc)
            {
                // Make sure this is a IP enabled device. Not something like memory card or VM Ware
                if ((bool) mo["IPEnabled"])
                {
                    if (mo["Caption"].Equals(nicName))
                    {
                        var newIP = mo.GetMethodParameters("EnableStatic");
                        newIP["IPAddress"] = IpAddresses.Split(',');
                        newIP["SubnetMask"] = new[] {SubnetMask};
                        var setIP = mo.InvokeMethod("EnableStatic", newIP, null);

                        if (Gateway != null)
                        {
                            var newGate = mo.GetMethodParameters("SetGateways");
                            newGate["DefaultIPGateway"] = new[] {Gateway};
                            newGate["GatewayCostMetric"] = new[] {1};
                            var setGateways = mo.InvokeMethod("SetGateways", newGate, null);
                        }

                        if (DnsSearchOrder != null)
                        {
                            var newDNS = mo.GetMethodParameters("SetDNSServerSearchOrder");
                            newDNS["DNSServerSearchOrder"] = DnsSearchOrder.Split(',');
                            var setDNS = mo.InvokeMethod("SetDNSServerSearchOrder", newDNS, null);
                        }
                        break;
                    }
                }
            }
        }

        /// <summary>
        ///     Returns the network card configuration of the specified NIC
        /// </summary>
        /// <param name="nicName">Name of the NIC</param>
        /// <param name="ipAdresses">Array of IP</param>
        /// <param name="subnets">Array of subnet masks</param>
        /// <param name="gateways">Array of gateways</param>
        /// <param name="dnses">Array of DNS IP</param>
        public static void GetIP(string nicName, out string[] ipAdresses, out string[] subnets, out string[] gateways,
            out string[] dnses)
        {
            ipAdresses = null;
            subnets = null;
            gateways = null;
            dnses = null;

            var mc = new ManagementClass("Win32_NetworkAdapterConfiguration");
            var moc = mc.GetInstances();

            foreach (ManagementObject mo in moc)
            {
                // Make sure this is a IP enabled device. Not something like memory card or VM Ware
                if ((bool) mo["ipEnabled"])
                {
                    if (mo["Caption"].Equals(nicName))
                    {
                        ipAdresses = (string[]) mo["IPAddress"];
                        subnets = (string[]) mo["IPSubnet"];
                        gateways = (string[]) mo["DefaultIPGateway"];
                        dnses = (string[]) mo["DNSServerSearchOrder"];

                        break;
                    }
                }
            }
        }

        /// <summary>
        ///     Returns the list of Network Interfaces installed
        /// </summary>
        /// <returns>Array list of string</returns>
        public static ArrayList GetNICNames()
        {
            var nicNames = new ArrayList();

            var mc = new ManagementClass("Win32_NetworkAdapterConfiguration");
            var moc = mc.GetInstances();

            foreach (ManagementObject mo in moc)
            {
                if ((bool) mo["ipEnabled"])
                {
                    nicNames.Add(mo["Caption"]);
                }
            }

            return nicNames;
        }
    }
}
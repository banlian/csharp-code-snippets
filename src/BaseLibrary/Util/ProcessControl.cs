using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Management;
using System.Security.Authentication;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace BaseLibrary.Util
{
    public class ProcessControl
    {
        ///<summary>
        /// Kill the processes specified by the name (“notepad.exe”)
        ///</summary>
        ///<param name="processName">Name of the process, case-insensitive.</param>
        ///<param name="currentUserOnly">If true, kill only processes by current user</param>
        public static int KillProcessByName(string processName, bool currentUserOnly = true)
        {
            try
            {
                string userName = null;
                if (currentUserOnly)
                {
                    userName = WindowsIdentity.GetCurrent().Name;
                }

                var processFinder = new ManagementObjectSearcher(
                    $"Select * from Win32_Process where Name = '{processName}'");

                var processes = processFinder.Get();
                if (processes.Count == 0)
                    return 0;
                foreach (var p in processes)
                {
                    var managementObject = (ManagementObject) p;
                    var pId = Convert.ToInt32(managementObject["ProcessId"]);
                    var process = Process.GetProcessById(pId);
                    if (currentUserOnly) //current user
                    {
                        var processOwnerInfo = new object[2];
                        managementObject.InvokeMethod("GetOwner", processOwnerInfo);
                        var processOwner = (string) processOwnerInfo[0];
                        var net = (string) processOwnerInfo[1];
                        if (!string.IsNullOrEmpty(net))
                            processOwner = $"{net}\\{processOwner}";
                        if (string.CompareOrdinal(processOwner, userName) == 0)
                            process.Kill();
                    }
                    else //any user                    
                    {
                        process.Kill();
                    }
                }

                return processes.Count;
            }
            catch (Exception)
            {
                //There is a good chance for UnauthorizedAccessException here, so
                //log the error or handle otherwise
                return 0;
            }
        }


        ///<summary>
        /// Kill the processes specified by the name (“notepad.exe”)
        ///</summary>
        ///<param name="processName">Name of the process, case-insensitive.</param>
        ///<param name="currentUserOnly">If true, kill only processes by current user</param>
        public static int KillProcessLikeName(string processName, bool currentUserOnly = true)
        {
            try
            {
                string userName = null;
                if (currentUserOnly)
                {
                    userName = WindowsIdentity.GetCurrent().Name;
                }

                var processFinder = new ManagementObjectSearcher(
                    $"Select * from Win32_Process where Name like '{processName}'");

                var processes = processFinder.Get();
                if (processes.Count == 0)
                    return 0;
                foreach (var p in processes)
                {
                    var managementObject = (ManagementObject)p;
                    var pId = Convert.ToInt32(managementObject["ProcessId"]);
                    var process = Process.GetProcessById(pId);
                    if (currentUserOnly) //current user
                    {
                        var processOwnerInfo = new object[2];
                        managementObject.InvokeMethod("GetOwner", processOwnerInfo);
                        var processOwner = (string)processOwnerInfo[0];
                        var net = (string)processOwnerInfo[1];
                        if (!string.IsNullOrEmpty(net))
                            processOwner = $"{net}\\{processOwner}";
                        if (string.CompareOrdinal(processOwner, userName) == 0)
                            process.Kill();
                    }
                    else //any user                    
                    {
                        process.Kill();
                    }
                }

                return processes.Count;
            }
            catch (Exception)
            {
                //There is a good chance for UnauthorizedAccessException here, so
                //log the error or handle otherwise
                return 0;
            }
        }
    }
}
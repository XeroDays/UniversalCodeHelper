using Microsoft.Win32;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing.Text;
using System.Linq;
using System.Management;
using System.Net;
using System.Net.Http;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Softasium.Licenser
{


    public static class DeviceInformationRegisterar
    {

    }

    public class SoftwareLicenceController
    {
        static string CurrentVersion = "1.0.0"; // this could be anything, no operations  are applied on this
        static int CurrentBuildVersion = 1;
        private const string appID = "TireManager";
        private const string bearerAuthKey = "iamsyedidreesfrompakistan";


        private SoftwareLicenseRequestReponse SoftwareLicenseRequestReponse { get; set; }

        public SoftwareLicenceController()
        {
            init();
        }

        private void init()
        {
            //populate software license request model
            SoftwareLicenseRequestReponse = new SoftwareLicenseRequestReponse
            {
                DeviceUUID =  GetDeviceID(),
                DeviceInfo = GetDeviceInfo(),
                AppID = appID,
                BuildVersion = CurrentBuildVersion,
                VersionName = CurrentVersion
            };
            //register the user license

            RegisterLicense();
        }


        private string GetDeviceID()
        { 
            String PCID = String.Empty;
            RegistryKey localKey;
            if (Environment.Is64BitOperatingSystem)
                localKey = RegistryKey.OpenBaseKey(RegistryHive.LocalMachine, RegistryView.Registry64);
            else
                localKey = RegistryKey.OpenBaseKey(RegistryHive.LocalMachine, RegistryView.Registry32);
            var RegKEY = localKey.OpenSubKey(@"SOFTWARE\Microsoft\SQMClient");
            if (RegKEY != null)
            {
                PCID = RegKEY.GetValue("MachineId").ToString().Trim();
            }
             
            if (PCID.StartsWith("{")  )
            {
                PCID = PCID.Substring(1, PCID.Length - 1); 
            }

            if ( PCID.EndsWith("}"))
            {
                PCID = PCID.Substring(0, PCID.Length - 1);
            } 
            return PCID;
        }

        private string GetDeviceInfo()
        {
            string deviceId = string.Empty;
            try
            {
                using (ManagementObjectSearcher searcher = new ManagementObjectSearcher("SELECT * FROM Win32_ComputerSystemProduct"))
                {
                    foreach (ManagementObject obj in searcher.Get())
                    {
                        deviceId = obj["UUID"]?.ToString();
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error retrieving CPU ID: " + ex.Message);
            }

            string processorInfo = "";
            using (ManagementObjectSearcher searcher = new ManagementObjectSearcher("SELECT * FROM Win32_Processor"))
            {
                foreach (ManagementObject obj in searcher.Get())
                {
                    processorInfo = obj["Name"]?.ToString();
                }
            }

            StringBuilder details = new StringBuilder();
            details.AppendLine("Name: " + Environment.MachineName);
            details.AppendLine("Device ID: " + deviceId);
            details.AppendLine("Processor: " + processorInfo);
            details.AppendLine("Device Info: ");
            try
            {
                using (ManagementObjectSearcher searcher = new ManagementObjectSearcher("SELECT * FROM Win32_OperatingSystem"))
                {
                    foreach (ManagementObject obj in searcher.Get())
                    {
                        details.AppendLine("Operating System Name: " + obj["Caption"]);
                        details.AppendLine("Version: " + obj["Version"]);
                        string lastBootUpTime = obj["LastBootUpTime"].ToString();
                        DateTime lastBootUpDateTime = ManagementDateTimeConverter.ToDateTime(lastBootUpTime);
                        TimeSpan timeAgo = DateTime.Now - lastBootUpDateTime;
                        string timeAgoString = timeAgo.Hours + " hours " + timeAgo.Minutes + " minutes ago";

                        details.AppendLine("Last Boot Up Time: " + timeAgoString);
                    }
                }

                details.AppendLine($"Screen Resolution: {Screen.PrimaryScreen.Bounds.Width} x {Screen.PrimaryScreen.Bounds.Height}");
                details.AppendLine("OS Architecture: " + RuntimeInformation.OSArchitecture.ToString());

            }
            catch (Exception ex)
            {
                details.AppendLine("Error retrieving OS details: " + ex.Message);
            }

            return details.ToString();
        }


        private async Task RegisterLicense()
        {

            string jsonResponse = await GenerateTaskStringAsync();
        }


        private async Task<string> GenerateTaskStringAsync()
        {
            try
            {
                using (WebClient client = new WebClient())
                {
                    client.Headers[HttpRequestHeader.ContentType] = "application/json";
                    client.Headers[HttpRequestHeader.Authorization] = "Bearer " + bearerAuthKey;
                    string jsonContent = JsonConvert.SerializeObject(SoftwareLicenseRequestReponse);
                    string response = client.UploadString("https://api.softasium.com/api/SoftwareLicencing/Register", jsonContent);
                    return response;
                }
            }
            catch (HttpRequestException ex)
            { 
                return $"Request error: {ex.Message}";
            }
        }
    }


    public class SoftwareLicenseRequestReponse
    {
        public string DeviceUUID { get; set; }
        public string DeviceInfo { get; set; }
        public string AppID { get; set; }
        public int BuildVersion { get; set; }
        public string VersionName { get; set; }
        public bool Status { get; set; }
        public bool ForceUpdate { get; set; }
        public string DownloadUrl { get; set; }
        public string LatestVersion { get; set; }
        public string Logs { get; set; }
    }

}

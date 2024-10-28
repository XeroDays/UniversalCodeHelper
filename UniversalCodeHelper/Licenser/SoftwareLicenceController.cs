using System;
using System.Collections.Generic;
using System.Drawing.Text;
using System.Linq;
using System.Management;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Softasium.Licenser
{
 
     
    public class SoftwareLicenceController
    {
        static string CurrentVersion = "1.0.0"; // this could be anything, no operations  are applied on this
        static int CurrentBuildVersion = 1; 

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
                DeviceUUID = GetCPUID(),
                DeviceInfo = GetDeviceInfo(),
                AppID = "1",
                BuildVersion = CurrentBuildVersion,
                VersionName = CurrentVersion
            };
            //register the user license
        }


        private string GetCPUID()
        {
            string cpuId = string.Empty;
            try
            {
                using (ManagementObjectSearcher searcher = new ManagementObjectSearcher("select ProcessorId from Win32_Processor"))
                {
                    foreach (ManagementObject obj in searcher.Get())
                    {
                        cpuId = obj["ProcessorId"]?.ToString(); 
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error retrieving CPU ID: " + ex.Message);
            } 
            return cpuId;

        }
        
        private string GetDeviceInfo()
        {
            StringBuilder info = new StringBuilder();

            try
            { 
                info.AppendLine("OS Version: " + RuntimeInformation.OSDescription);
                info.AppendLine("OS Architecture (Bit Rate): " + RuntimeInformation.OSArchitecture.ToString()); 
                info.AppendLine($"Screen Resolution: {Screen.PrimaryScreen.Bounds.Width} x {Screen.PrimaryScreen.Bounds.Height}");
            }
            catch (Exception ee)
            {  
                info.AppendLine("Error retrieving device info: " + ee.Message);
            }
            StringBuilder details = new StringBuilder();
            try
            {
               
                using (ManagementObjectSearcher searcher = new ManagementObjectSearcher("SELECT * FROM Win32_OperatingSystem"))
                {
                    foreach (ManagementObject obj in searcher.Get())
                    {
                        details.AppendLine("Operating System Name: " + obj["Caption"]);
                        details.AppendLine("Version: " + obj["Version"]);
                        details.AppendLine("Manufacturer: " + obj["Manufacturer"]);
                        details.AppendLine("Last Boot Up Time: " + obj["LastBootUpTime"]);
                    }
                }
            }
            catch (Exception ex)
            {
                details.AppendLine("Error retrieving OS details: " + ex.Message);
            }

            info.AppendLine("\nAdditional OS Details:"); 
            info.AppendLine(details.ToString());

            return info.ToString();
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
    }

}

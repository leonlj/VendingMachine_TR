using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConnectLayer
{
    public static class localSettingsHelper
    {
        public static string DeviceToken = "Token1";

        //public static string IotHubUri = "OWVendorMachineBak.azure-devices.net";
        //public static string DeviceId = "myDevice1";
        //public static string DeviceKey = "8OVTszWFA5o6rEUyXFgBTuWqgSTtiHtD6kvwCuY9tWU=";

        public static string DeviceId = "1122345";
        public static string IotHubUri = "IoTHubnewtest.azure-devices.net";
        public static string DeviceKey = "u79wun9ta00Dox2akywUOMqHXyrf6vuIv87zTzAgHb4=";
        
        public static void SaveValueByKey(string Key, string Str)
        {
            var localSettings = Windows.Storage.ApplicationData.Current.LocalSettings;
            localSettings.Values[Key] = Str;
        }

        public static string GetValueByKey(string Key, string Str)
        {
            var localSettings = Windows.Storage.ApplicationData.Current.LocalSettings;
            if (localSettings.Values.ContainsKey(Key))
            {
                return localSettings.Values[Key].ToString();
            }
            else
            {
                return null;
            }
        }
    }
}

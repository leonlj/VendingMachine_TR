using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace ConnectLayer
{
    public sealed class Register
    {
        string _deviceID = "0";

        //string RegisterURL = "http://owvm.azurewebsites.net/device/activate?deviceId=";
        string RegisterURL = "http://owliusjtest1.azurewebsites.net/device/activate?deviceId=";

        public Register()
        {
        }

        public Register(string deviceID)
        {
            _deviceID = deviceID;
        }

        public async Task<string> Enroll(string deviceID = "0")
        {
            if (deviceID != null)
            {
                _deviceID = deviceID;
            }

            try
            {
                HttpClient client = new HttpClient();
                Uri requestUri = new Uri(RegisterURL + _deviceID);
                HttpResponseMessage response = await client.GetAsync(requestUri);
                string responseAsString = await response.Content.ReadAsStringAsync();

                RegistResult result = JsonHelper.Deserialize<RegistResult>(responseAsString);

                if (result.Message.ToLower() == "ok")
                {
                    localSettingsHelper.SaveValueByKey(localSettingsHelper.DeviceToken, result.Data.DeviceKey);
                    return result.Data.DeviceKey;
                }
                else
                {
                    return result.Message;
                }
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
    }
}

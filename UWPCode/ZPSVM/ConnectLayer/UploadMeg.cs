using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Azure.Devices.Client;
using System.Runtime.Serialization.Json;
using System.IO;
using System.Diagnostics;
using ConnectLayer.DataEntity;

namespace ConnectLayer
{
    public class UploadMeg
    {
        public string iotHubUri { get; set; }
        public string deviceId { get; set; }
        public string deviceKey { get; set; }

        private DeviceClient deviceClient;

        //public event EventHandler MegReceived;


        public event EventHandler ADinfoReceived;
        public event EventHandler ChannelinfoReceived;

        public UploadMeg()
        {
            iotHubUri = localSettingsHelper.IotHubUri;
            deviceId = localSettingsHelper.DeviceId;
            deviceKey = localSettingsHelper.DeviceKey;

            //iotHubUri = "OWvm1.azure-devices.net";
            //deviceId = "myDevice1";
            //deviceKey = "34J8wLXHHwnpAoIEw2ZIzP8R5TzxjhiS4MP0h2dRtHE=";

            deviceClient = DeviceClient.Create(iotHubUri,
                 AuthenticationMethodFactory.
                     CreateAuthenticationWithRegistrySymmetricKey(deviceId, deviceKey),
                 TransportType.Http1);

            Task.Run(() => { ReceiveC2dAsync(); });
        }

        public async void SendDeviceToCloudMessagesAsync(object obj)
        {
            if (obj == null) return;

            string jsonMeg = JsonHelper.Serialize(obj);

            var message = new Message(Encoding.ASCII.GetBytes(jsonMeg));
            try
            {
                await deviceClient.SendEventAsync(message);
            }
            catch (Exception ex)
            {
                throw (new Exception(ex.Message));
            }
        }


        private void EventHelper(string JsonMeg)
        {
            if (JsonMeg.Contains("advId"))
            {
                //string responseAsString = "[{\"deviceId\":\"1122345\",\"advId\":\"1\",\"contentUrl\":\"www.baidu.com\",\"endDate\":\"2016 - 03 - 11T22: 00:00\"}]";
                ADinfo result = JsonHelper.Deserialize<ADinfo>(JsonMeg.Trim('[', ']'));
                ADinfoReceived?.Invoke(result, EventArgs.Empty);
            }
            else
            {
                //string testj = "[{\"deviceId\":\"1122345\",\"channelId\":\"01\",\"skuName\":\"COKE\",\"productImageUrl\":\"www.baidu.com\",\"listPrice\":3.00,\"discountPrice\":0.00},{\"deviceId\":\"1122345\",\"channelId\":\"02\",\"skuName\":\" ??? \",\"productImageUrl\":\"www.sina.com\",\"listPrice\":1.00,\"discountPrice\":0.00}]";
                Channelinfo[] result = JsonHelper.Deserialize<Channelinfo[]>(JsonMeg);
                ChannelinfoReceived?.Invoke(result, EventArgs.Empty);
            }
        }

        private async void ReceiveC2dAsync()
        {
            if (deviceClient == null) return;

            while (true)
            {
                try
                {
                    Message receivedMessage = await deviceClient.ReceiveAsync();
                    if (receivedMessage == null) continue;

                    string meg = Encoding.ASCII.GetString(receivedMessage.GetBytes());
                    EventHelper(meg);
                    //MegReceived?.Invoke(meg, EventArgs.Empty);

                    Debug.WriteLine("reciver message: " + meg);
                    //Console.ForegroundColor = ConsoleColor.Yellow;
                    //Console.WriteLine("Received message: {0}", Encoding.ASCII.GetString(receivedMessage.GetBytes()));
                    //Console.ResetColor();
                    await deviceClient.CompleteAsync(receivedMessage);
                }
                catch (Exception ex)
                {
                    throw (new Exception(ex.Message));
                }
            }
        }
    }
}

using System;
using System.Text;
using Microsoft.Azure.Devices.Client;
using Newtonsoft.Json;
using System.Threading;

namespace DeviceTest2
{
    //Nuget install device.client package first!
    class Program
    {
        static DeviceClient deviceClient;

        //static string iotHubUri = "OWVendorMachinehub.azure-devices.net";
        //static string deviceKey = "vsYpWqz1uvfEmM9wxvmZK6EhKc6A86mqw8747+U9BgE=";


        static string iotHubUri = "OWvm1.azure-devices.net";
        //deviceId = "myDevice1";
        static string deviceKey = "34J8wLXHHwnpAoIEw2ZIzP8R5TzxjhiS4MP0h2dRtHE=";

        static void Main(string[] args)
        {
            Console.WriteLine("Simulated device\n");
            deviceClient = DeviceClient.Create(iotHubUri, new DeviceAuthenticationWithRegistrySymmetricKey("myDevice1", deviceKey), TransportType.Amqp); //Amqp或者http协议，树莓派上需要测试一下哪个能用

            //SendDeviceToCloudMessagesAsync();
            ReceiveC2dAsync();
            Console.ReadLine();
        }

        private static async void SendDeviceToCloudMessagesAsync()
        {

            while (true)
            {

                var telemetryDataPoint = new
                {
                    deviceId = "1",
                    channelId = "2",
                    countNo = "3",
                    payFee = 100,
                    payType = "4",
                    payBatch = "5",
                    transactionTime = DateTime.Now,
                    Flag = 0
                };
                //var telemetryDataPoint = new
                //{
                //    deviceId = "1",
                //    channelId = "2",
                //    addProductNo = 3,
                //    addTime = DateTime.Now,
                //    Flag = 1
                //};
                //var telemetryDataPoint = new
                //{
                //    deviceId = "1",
                //    temperature = "2",
                //    voltDrop = 3.0,
                //    powerDraw = 4.0,
                //    dutyCycle = 5.0,
                //    healthFlag = "6",
                //    addProductNo = 3,
                //    addDate = DateTime.Now,
                //    Flag = 2
                //};
                var messageString = JsonConvert.SerializeObject(telemetryDataPoint);
                var message = new Message(Encoding.ASCII.GetBytes(messageString));

                await deviceClient.SendEventAsync(message);
                Console.WriteLine("{0} > Sending message: {1}", DateTime.Now, messageString);

                Thread.Sleep(1000);
            }
        }

        private static async void ReceiveC2dAsync()
        {
            Console.WriteLine("\nReceiving cloud to device messages from service");
            while (true)
            {
                Message receivedMessage = await deviceClient.ReceiveAsync();
                if (receivedMessage == null) continue;

                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("Received message: {0}", Encoding.ASCII.GetString(receivedMessage.GetBytes()));
                Console.ResetColor();

                await deviceClient.CompleteAsync(receivedMessage);
            }
        }
    }
}

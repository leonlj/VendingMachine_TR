using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Azure.Devices;

namespace SendCloudToDevice
{
    //First install Azure.Device nuget package
    class Program
    {
        static ServiceClient serviceClient;

        //static string connectionString = "HostName=OWvm1.azure-devices.net;SharedAccessKeyName=iothubowner;SharedAccessKey=AycyzDzXd+6zcOSFnhPqHG1BfxLX/X9nY2NzVYuAWyY=";

        //static string connectionString = "HostName=OWVendorMachineBak.azure-devices.net;SharedAccessKeyName=iothubowner;SharedAccessKey=Vebl82iu12NEStD2A1aaIBWFxmhildCTVNDRnDWj75w=";

        static string connectionString = "HostName=IoTHubnewtest.azure-devices.net;SharedAccessKeyName=iothubowner;SharedAccessKey=g2XUzmT1Q/Vgx0cCoN3MjtcWyQUukkxZDmODXCZmcSQ=";


        static void Main(string[] args)
        {
            Console.WriteLine("Send Cloud-to-Device message\n");
            serviceClient = ServiceClient.CreateFromConnectionString(connectionString);
            ReceiveFeedbackAsync();
            Console.WriteLine("Press any key to send a C2D message.");
            Console.ReadLine();
            SendCloudToDeviceMessageAsync().Wait();
            Console.ReadLine();
        }
        private async static Task SendCloudToDeviceMessageAsync()
        {
            var commandMessage = new Message(Encoding.ASCII.GetBytes("Cloud to device message."));
            commandMessage.Ack = DeliveryAcknowledgement.Full;
            await serviceClient.SendAsync("1122345", commandMessage);

        }

        private async static void ReceiveFeedbackAsync()
        {
            var feedbackReceiver = serviceClient.GetFeedbackReceiver();

            Console.WriteLine("\nReceiving c2d feedback from service");
            while (true)
            {
                var feedbackBatch = await feedbackReceiver.ReceiveAsync();
                if (feedbackBatch == null) continue;

                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("Received feedback: {0}", string.Join(", ", feedbackBatch.Records.Select(f => f.StatusCode)));
                Console.ResetColor();

                await feedbackReceiver.CompleteAsync(feedbackBatch);
            }
        }
    }
}

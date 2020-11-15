using System;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace UDPSensorStop
{
    class Program
    {
        static void Main(string[] args)
        {
            //UdpClient
            //When defining receiver you have to mention port number here
            //you have to define the port number so it knows where to read from
            UdpClient udpBroadcastSender = new UdpClient(0);

            udpBroadcastSender.EnableBroadcast = true;


            //broadcasts to port 1111
            IPEndPoint ipEndPoint = new IPEndPoint(IPAddress.Broadcast, 1111);
            Console.WriteLine("Insert stop to stop the UDP receiver");
            var input = Console.ReadLine();
            int number = 0;
            
            try
            {
                while (true)
                {
                    Byte[] sendBytes = Encoding.ASCII.GetBytes(input);
                    Task.Run(() =>
                    {
                        udpBroadcastSender.Send(sendBytes, sendBytes.Length, ipEndPoint);
                    });
                    Console.WriteLine(number);
                    number++;
                    Thread.Sleep(500);
                }

                

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.ReadKey();
            }
        }
    }
}

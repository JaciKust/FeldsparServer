using System;
using System.Text.RegularExpressions;
using NetMQ;
using NetMQ.Sockets;

namespace FeldsparServer
{
    class Program
    {
        public static void Main()
        {
			//new PublisherMessageBus().Send();
			new MessageBus().Receive();

			// Send
			//using (var client = new RequestSocket())
			//{
			//	client.Connect("tcp://192.168.0.158:5555");
			//	client.SendFrame("Hello");
			//	var msg = client.ReceiveFrameString();
			//	Console.WriteLine("From Server: {0}", msg);
			//}
		}
    }
}

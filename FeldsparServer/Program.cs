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
			using (var server = new ResponseSocket())
			{
				server.Bind("tcp://*:5556");
				Console.WriteLine("Waiting...");
				Console.WriteLine();
				string msg = server.ReceiveFrameString();
				Console.WriteLine("From Client: {0}", msg);
				Console.WriteLine();
				server.SendFrame("ack");
			}

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

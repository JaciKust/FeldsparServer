using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FeldsparServer.DataObjects;
using NetMQ;
using NetMQ.Sockets;

namespace FeldsparServer
{
	public class MessageBus
	{
		public MessageBus()
		{
			
		}

		public void Receive() 
		{
			using (var server = new ResponseSocket())
			{
				Console.WriteLine("Waiting...");
				Console.WriteLine();
				server.Bind("tcp://*:5556");

				while (true)
				{
					string msg = server.ReceiveFrameString();
					Console.WriteLine("From Client: {0}", msg);
					Console.WriteLine();
					server.SendFrame("ack");

					var obj = DataObjectParser.FromJson<ButtonPressedDataObject>(msg);
					Console.WriteLine($"Press Time: {obj.ButtonPressTime}");
				}
			}
		}

		public event EventHandler OnRecieve;
	}
}

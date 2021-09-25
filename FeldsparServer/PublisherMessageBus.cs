using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using NetMQ;
using NetMQ.Sockets;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;

namespace FeldsparServer
{
	public class PublisherMessageBus
	{
		public PublisherMessageBus()
		{

		}

		public void Send() 
		{
			using (var publisher = new PublisherSocket())
			{
				publisher.Bind("tcp://*:5556");

				int i = 0;

				while (true)
				{
					Console.WriteLine($"Sending: {i}");
					publisher
						.SendMoreFrame("A") // Topic
						.SendFrame(i.ToString()); // Message

					i++;
					Thread.Sleep(1000);
				}
			}
		}
	}
}

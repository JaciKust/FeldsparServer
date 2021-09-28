using System;
using System.Threading;
using System.Threading.Tasks;
using FeldsparServer.DataObjects;
using NetMQ;
using NetMQ.Sockets;

namespace FeldsparServer.Messaging
{
	public class MessageBus : IMessageBus
	{
		public MessageBus()
		{
			StartReceive();
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

		private void RunReceive()
		{
			using (var server = new ResponseSocket())
			{
				Console.WriteLine("Waiting...");
				Console.WriteLine();
				server.Bind("tcp://*:5556");

				while (!stopReceive)
				{
					string msg = server.ReceiveFrameString();
					Console.WriteLine("From Client: {0}", msg);
					Console.WriteLine();
					server.SendFrame("ack");

					var obj = DataObjectParser.FromJson<ButtonPressedDataObject>(msg);
					Console.WriteLine($"Press Time: {obj.ButtonPressTime}");
					OnRecieve?.Invoke(this, EventArgs.Empty);
				}
			}
		}

		private bool stopReceive = false;

		public void StopReceive()
		{
			stopReceive = true;
		}

		public void StartReceive()
		{
			stopReceive = false;
			Task.Run(() => RunReceive());
		}

		public event EventHandler OnRecieve;
	}
}

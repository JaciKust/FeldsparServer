using System;
using System.Text.Json;
using System.Threading.Tasks;
using FeldsparServer.DataObjects;
using NetMQ;
using NetMQ.Sockets;

namespace FeldsparServer.Messaging
{
	public class MessageBus : IMessageBus
	{
		private static MessageBus _instance;
		private readonly PublisherSocket _socket = null;

		public static MessageBus Instance
		{
			get
			{
				if (_instance == null)
				{
					_instance = new MessageBus();
				}
				return _instance;
			}
		}

		private MessageBus()
		{
			StartReceive();
			_socket = new PublisherSocket();
			_socket.Bind("tcp://*:5557");
		}

		public void Send(IDataObject dataObject)
		{
			using (var publisher = new PublisherSocket())
			{
				lock (this)
				{
					var jsonString = dataObject.ToJsonString();
					Console.WriteLine($"Sending: {jsonString}");
					_socket
						.SendMoreFrame(dataObject.Topic)
						.SendFrame(jsonString); // Message
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

					var obj = JsonSerializer.Deserialize<DataObjectButtonPressed>(msg);
					Console.WriteLine($"Press Time: {obj.ButtonPressTime}");
					var eventArgs = new ButtonPressEventArgs(obj);
					OnRecieve?.Invoke(this, eventArgs);
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

		public event EventHandler<ButtonPressEventArgs> OnRecieve;
	}
}

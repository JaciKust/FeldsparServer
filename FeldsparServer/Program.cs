using System;
using System.Text.RegularExpressions;
using System.Threading;
using NetMQ;
using NetMQ.Sockets;
using FeldsparServer.Messaging;
namespace FeldsparServer
{
	class Program
	{
		public static void Main()
		{
			IMessageBus mb = new MessageBus();
			mb.OnRecieve += OnReceive;
			while (true) {
				Thread.Sleep(1000);
				Console.WriteLine("\t\ttick");
			}
		}

		private static void OnReceive(object sender, EventArgs e){
			Console.WriteLine("Received Event! ");
		}
	}
}

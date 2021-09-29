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
			IMessageBus mb = MessageBus.Instance;

			FeldsparRunner runner = new FeldsparRunner(mb);
			
			while (true) {
				Thread.Sleep(1000);
				Console.WriteLine("\t\ttick");

				runner.OnTick(DateTime.Now);
			}
		}
	}
}

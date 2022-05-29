using System;
using System.Threading;
using Communication.MessageBus;

namespace FeldsparServer
{
	class Program
	{
		//public static void Main()
		//{
		//	LightBulb bulb = new LightBulb("192.168.0.206", new byte[] { 0xD0, 0x73, 0xD5, 0x2A, 0x93, 0x0C });


		//	var client = LifxClient.CreateAsync();
		//	client.
		//	client
		//	client.DeviceDiscovered += Client_DeviceDiscovered;
		//	client.DeviceLost += Client_DeviceLost;
		//	client.StartDeviceDiscovery();



		//	// 'D0:73:D5:2A:93:0C', '192.168.0.206', 'Golf'
		//	//IMessageBus mb = MessageBus.Instance;

		//	//FeldsparRunner runner = new FeldsparRunner(mb);
		//	//Pushover p = new Pushover();
		//	//p.Send("Hello Friend!");
		//	//while (true) {
		//	//	Thread.Sleep(1000);
		//	//	Console.WriteLine("\t\ttick");

		//	//	runner.OnTick(DateTime.Now);
		//	//}
		//}

		static LifxNet.LifxClient client;
		static void Main(string[] args)
		{
			IMessageBus mb = NetMQMessageBus.Instance;
			FeldsparRunner runner = new FeldsparRunner(mb);
			int i = 0;
			while (true)
			{
				Thread.Sleep(1000);
				if (i++ % 60 == 0)
				{
					Console.WriteLine("\t\ttick");
				}

				runner.OnTick(DateTime.Now);
			}
		}
	}
}

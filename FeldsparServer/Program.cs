using System;
using System.Text.RegularExpressions;
using System.Threading;
using NetMQ;
using NetMQ.Sockets;
using FeldsparServer.Messaging;
using LifxNet;
using FeldsparServer.Interactable;

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
			var bulb = LifxBulbs.alpha;
			bulb.TurnOn(Colors.Blue);
			Console.ReadKey();
		}

		private static void Client_DeviceLost(object sender, LifxClient.DeviceDiscoveryEventArgs e)
		{
			Console.WriteLine("Device lost");
		}

		private static async void Client_DeviceDiscovered(object sender, LifxClient.DeviceDiscoveryEventArgs e)
		{
			Console.WriteLine($"Device {e.Device.MacAddressName} found @ {e.Device.HostName}");
			var version = await client.GetDeviceVersionAsync(e.Device);
			//var label = await client.GetDeviceLabelAsync(e.Device);
			var state = await client.GetLightStateAsync(e.Device as LightBulb);
			Console.WriteLine($"{state.Label}\n\tIs on: {state.IsOn}\n\tHue: {state.Hue}\n\tSaturation: {state.Saturation}\n\tBrightness: {state.Brightness}\n\tTemperature: {state.Kelvin}");
		}
	}
}

using System;
using System.Linq;
using Common;
using Communication.MessageBus;
using LifxClient = LifxNet.LifxClient;
using LightBulb = LifxNet.LightBulb;

namespace FeldsparServer.Interactable
{
	public class LifxLightBulb : ILight
	{
		private readonly LightBulb _lightBulb;
		private IMessageBus _messageBus { get; set; }

		private static LifxClient _lifxClient = null;
		public static LifxClient LifxClient
		{
			get
			{
				if (_lifxClient == null)
				{
					var task = LifxClient.CreateAsync();
					task.Wait();
					_lifxClient = task.Result;
				}

				return _lifxClient;
			}
		}

		public static Color DefaultColor { get; set; } = Colors.WhiteDaylight;

		public LifxLightBulb(string macAddress, string ipAddress, string name)
		{
			Name = name;
			IpAddress = ipAddress;
			MacAddress = macAddress;

			byte[] macAddressArray = MacAddress.Split(':').Select(x => Convert.ToByte(x, 16)).ToArray();
			_lightBulb = new LightBulb(ipAddress, macAddressArray);
		}

		public Color CurrentColor { get; internal set; } = DefaultColor;

		public string Name { get; }
		public string IpAddress { get; }
		public string MacAddress { get; }

		public void TurnOn(Color color, double transitionTime = 0.1)
		{
			CurrentColor = color;
			LifxClient.SetDevicePowerStateAsync(_lightBulb, true);
			LifxClient.SetColorAsync(_lightBulb, color.ToLifxColor(), (ushort)color.Kelvin, new TimeSpan(days: 0, hours: 0, minutes: 0, seconds: 0, milliseconds: (int)transitionTime*1000));
		}

		public event EventHandler OnStateChanged;

		public void TurnOff(double transitionTime = 0.1)
		{
			TurnOn(Colors.Black, transitionTime);
		}
	}
}

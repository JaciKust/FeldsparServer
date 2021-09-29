using System;
using FeldsparServer.DataObjects;
using FeldsparServer.Messaging;

namespace FeldsparServer.Interactable
{
	public class LifxLightBulb : ILight
	{
		private IMessageBus _messageBus { get; set; }
		public static Color DefaultColor { get; set; } = Colors.WhiteDaylight;

		public LifxLightBulb(string name, string ipAddress, string macAddress)
		{
			Name = name;
			IpAddress = ipAddress;
			MacAddress = macAddress;
		}

		public Color CurrentColor { get; internal set; } = DefaultColor;

		public string Name { get; }
		public string IpAddress { get; }
		public string MacAddress { get; }

		public void TurnOn(Color color, double transitionTime = 0.1)
		{
			CurrentColor = color;
			LightStateDataObject dataObject = new LightStateDataObject(
				new string[] { IpAddress }, 
				new string[] { MacAddress }, 
				color.toArray(), 
				transitionTime
			);

			OnStateChanged?.Invoke(this, EventArgs.Empty);

			//_messageBus.Send(dataObject, dataObject.Topic);
		}

		public event EventHandler OnStateChanged;

		public void TurnOff(double transitionTime = 0.1)
		{
			TurnOn(Colors.Black, transitionTime);
		}
	}
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FeldsparServer.Messaging;

namespace FeldsparServer.Interactable
{
	public class LifxLamp : ILight
	{
		IMessageBus MessageBus { get; }
		LifxLightBulb[] LightBulbs { get; }
		public string Name { get; set; }
		public LifxLamp(LifxLightBulb[] lightBulbs, string name)
		{
			LightBulbs = lightBulbs;
			Name = name;
		}

		public void TurnOff(double transitionTime = 0.1)
		{
			foreach (var bulb in LightBulbs)
			{
				bulb.TurnOff(transitionTime);
			}
		}

		public void TurnOn(Color color, double transitionTime = 0.1)
		{
			foreach (var bulb in LightBulbs)
			{
				bulb.TurnOn(color, transitionTime);
			}
		}
	}
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FeldsparServer.Messaging;

namespace FeldsparServer.Interactable
{
	public class LifxLamp
	{
		IMessageBus MessageBus { get; }
		LifxLightBulb[] LightBulbs  { get; }
		public string Name { get; set; }
		public LifxLamp(LifxLightBulb[] lightBulbs, string name) 
		{
			LightBulbs = lightBulbs;
			Name = name;
		}
	}
}

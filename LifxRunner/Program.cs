using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using Common;
using FeldsparServer.Interactable;

namespace LifxRunner
{
	class Program
	{
		static void Main(string[] args)
		{
			Console.WriteLine("Hello World!");
			List<Color> colors = new List<Color>{
				Colors.Red,
				Colors.Green,
				Colors.Blue,
				Colors.Magenta,
				Colors.Cyan,
				Colors.Yellow
			};

			List<LifxLamp> lifxLights = new List<LifxLamp>{
				LifxBulbs.RedLamp,
				LifxBulbs.YellowLamp,
				LifxBulbs.WhiteLamp,
				LifxBulbs.BlackLamp,
				LifxBulbs.SilverLamp
			};

			int transitionTime = 5;

			Console.WriteLine("Done");
			while (true)
			{
				foreach (var light in lifxLights)
				{
					var random = new Random();
					int randomEntry = random.Next(colors.Count);
					Color randomColor = colors.ElementAt(randomEntry);

					light.TurnOn(randomColor, transitionTime);
					Thread.Sleep(transitionTime * 1000);
				}
			}
		}
	}
}

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

			List<ILight> lifxLights = new List<ILight>{
				LifxBulbs.RedLamp,
				LifxBulbs.YellowLamp,
				LifxBulbs.WhiteLamp,
				LifxBulbs.BlackLamp,
				LifxBulbs.SilverLamp
			};

			int waitTime = 0;
			int transitionTime = 5000;

			Console.WriteLine("Done");
			RunBarColor(colors, transitionTime, waitTime);
			//RunMultiColor(colors, lifxLights, transitionTime, waitTime);
			//RunMonoColor(colors, lifxLights, transitionTime, waitTime);
		}

		private static void RunBarColor(List<Color> colors, int transitionTime, int waitTime){
			var lifxLights = new List<ILight> {
				//LifxBulbs.Hotel,
				//LifxBulbs.Juliet,
				//LifxBulbs.Kilo,
				//LifxBulbs.Romeo,
				//LifxBulbs.Sierra,
				//LifxBulbs.Lima,
				//LifxBulbs.Mike,
				//LifxBulbs.India
				LifxBulbs.RedLamp,
				LifxBulbs.YellowLamp,
				LifxBulbs.WhiteLamp,
				LifxBulbs.BlackLamp,
				LifxBulbs.SilverLamp
			};

			int delay = transitionTime;

			while (true){
				var color = GetRandomColor(colors);

				foreach (var light in lifxLights){
					light.TurnOn(color, (double)transitionTime/1000d);
				}
				Thread.Sleep(delay);

				Console.WriteLine("Here");
				Thread.Sleep(waitTime);
			}
		}

		private static void RunMultiColor(List<Color> colors, List<ILight> lifxLights, int transitionTime, int waitTime)
		{
			while (true)
			{
				foreach (var light in lifxLights)
				{
					Color randomColor = GetRandomColor(colors);

					light.TurnOn(randomColor, (double)transitionTime / 1000d);
				}
				Thread.Sleep((transitionTime + waitTime));
			}
		}

		private static Color GetRandomColor(List<Color> colors)
		{
			var random = new Random();
			int randomEntry = random.Next(colors.Count);
			Color randomColor = colors.ElementAt(randomEntry);
			return randomColor;
		}

		private static void RunMonoColor(List<Color> colors, List<ILight> lifxLights, int transitionTime, int waitTime)
		{
			while (true)
			{
				Color randomColor = GetRandomColor(colors);
				foreach (var light in lifxLights)
				{
					light.TurnOn(randomColor, (double)transitionTime / 1000d);
				}

				Thread.Sleep((transitionTime + waitTime));
			}
		}
	}
}

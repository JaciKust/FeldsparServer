using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Common;
using FeldsparServer.Interactable;

namespace FeldsparServer.State.Rainbow
{
	internal class LightShow
	{
		private bool _shouldAbort = false;
		public int TransitionTime { get; }
		public int WaitTime { get; }
		public int Scene { get; }
		public LightShow(int transitionTime, int waitTime, int scene)
		{
			TransitionTime = transitionTime;
			WaitTime = waitTime;
			Scene = scene;
			if (TransitionTime == 0 && WaitTime == 0){
				TransitionTime = 1;
			}
		}

		private Task _lightShowTask = null;

		public void Stop()
		{
			_shouldAbort = true;
			_lightShowTask.Wait(300);
			//_lightShowTask.Dispose();
		}

		public void Start()
		{
			Console.WriteLine($"Starting: W: {WaitTime}, T: {TransitionTime}, S: {Scene}");
			_lightShowTask = Task.Run(RunShow);
		}
		public bool IsRunning { get; private set; }
		private void RunShow()
		{
			try
			{
				IsRunning = true;
				switch (Scene)
				{
					case 0:
						RunOneColor();
						break;
					case 1:
						RunMultiColor();
						break;
					default:
						break;
				}
			}
			finally {
				IsRunning = false;
			}
		}

		List<ILight> lifxLights = new List<ILight>{
				LifxBulbs.RedLamp,
				LifxBulbs.YellowLamp,
				LifxBulbs.WhiteLamp,
				LifxBulbs.BlackLamp,
				LifxBulbs.SilverLamp
			};

		List<Color> colors = new List<Color>{
				Colors.Red,
				Colors.Green,
				Colors.Blue,
				Colors.Magenta,
				Colors.Cyan,
				Colors.Yellow
			};

		private void RunOneColor()
		{
			while (true)
			{
				Color randomColor = GetRandomColor(colors);
				foreach (var light in lifxLights)
				{
					light.TurnOn(randomColor, TransitionTime);
				}

				for (int i = 0; i < (TransitionTime + WaitTime) * 4; i++)
				{
					Thread.Sleep(250);
					if (_shouldAbort)
					{
						Console.WriteLine("Aborted.");
						return;
					}
				}
				Thread.Sleep(5);
			}
		}
		private void RunMultiColor()
		{
			while (true)
			{
				foreach (var light in lifxLights)
				{
					Color randomColor = GetRandomColor(colors);
					light.TurnOn(randomColor, TransitionTime);
				}

				for (int i = 0; i < (TransitionTime + WaitTime) * 4; i++)
				{
					Thread.Sleep(250);
					if (_shouldAbort)
					{
						Console.WriteLine("Aborted");
						return;
					}
				}
				Thread.Sleep(5);
			}
		}

		private static Color GetRandomColor(List<Color> colors)
		{
			var random = new Random();
			int randomEntry = random.Next(colors.Count);
			Color randomColor = colors.ElementAt(randomEntry);
			return randomColor;
		}
	}
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common;

namespace FeldsparServer.State.Rainbow
{
	internal class RainbowSetting
	{
		public RainbowSetting(Color buttonColor, int value)
		{
			ButtonColor = buttonColor;
			_value = value;
		}

		public RainbowSetting(Color buttonColor)
		{
			ButtonColor = buttonColor;
			_value = null;
		}

		public Color ButtonColor { get; }

		private int? _value;
		public int Value
		{
			get
			{
				if (_value.HasValue)
				{
					return _value.Value;
				}
				var randomWaits = new int[] { 0, 1, 5, 10, 30, 60, 120 };
				Random rand = new Random();
				int randomIndex = rand.Next(randomWaits.Length);
				return randomWaits[randomIndex];
			}
		}
	}
}

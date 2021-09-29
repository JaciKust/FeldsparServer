using System;

namespace FeldsparServer
{
	public class Color
	{
		public Color(int redPercent, int greenPercent, int bluePercent, Kelvin kelvin = Kelvin.BlueIce)
		{
			RedPercent = redPercent;
			GreenPercent = greenPercent;
			BluePercent = bluePercent;
			Kelvin = kelvin;
		}

		private int redPercent;

		public int RedPercent
		{
			get { return redPercent; }
			set
			{
				ValidatePercent(value, nameof(RedPercent));
				redPercent = value;
			}
		}

		private int greenPercent;

		public int GreenPercent
		{
			get { return greenPercent; }
			set
			{
				ValidatePercent(value, nameof(GreenPercent));
				greenPercent = value;
			}
		}

		private int bluePercent;

		public int BluePercent
		{
			get { return bluePercent; }
			set
			{
				ValidatePercent(value, nameof(BluePercent));
				bluePercent = value;
			}
		}

		public Kelvin Kelvin { get; set; }

		private void ValidatePercent(int percent, string property)
		{
			if (percent > Colors.ColorMaximum || percent < Colors.ColorMinimum)
			{
				throw new ArgumentOutOfRangeException($"{property} must be between [{Colors.ColorMinimum},{Colors.ColorMinimum}]");
			}
		}

		/// <summary>
		/// Returns the color as an array [red, green, blue, kelvin]
		/// </summary>
		public int[] toArray()
		{
			return new int[] { RedPercent, GreenPercent, BluePercent, (int)Kelvin };
		}
	}
}

using System;

namespace LaundryService
{
	public class AxisReading
	{
		public AxisReading(double xAcceleration, double yAcceleration, double zAcceleration, DateTime time)
		{
			XAcceleration = xAcceleration;
			YAcceleration = yAcceleration;
			ZAcceleration = zAcceleration;
			Time = time;
		}

		public double XAcceleration { get; }
		public double YAcceleration { get; }
		public double ZAcceleration { get; }
		public DateTime Time { get; }
	}
}

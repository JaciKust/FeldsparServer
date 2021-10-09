using System;
using System.Collections.Generic;
using System.Linq;

namespace LaundryService
{
	public class WasherDataSet
	{
		private const int timeSpanMinutes = 3;
		private const int washingThreshold = 1;
		private const int spinningThreshold = 10;

		public IEnumerable<AxisReading> Data { get; }


		public WasherDataSet(IEnumerable<AxisReading> data)
		{
			Data = data;
		}

		public WasherState GetState(DateTime? atTime = null)
		{
			if (atTime == null)
			{
				atTime = DateTime.UtcNow;
			}

			var data = GetDataOverTime(atTime);

			if (data.Count() < 2)
			{
				return WasherState.Idle;
			}

			double xMin = data.Min(d => d.XAcceleration);
			double xMax = data.Max(d => d.XAcceleration);
			double xRange = xMax - xMin;

			double yMin = data.Min(d => d.YAcceleration);
			double yMax = data.Max(d => d.YAcceleration);
			double yRange = yMax - yMin;

			double zMin = data.Min(d => d.ZAcceleration);
			double zMax = data.Max(d => d.ZAcceleration);
			double zRange = zMax - zMin;

			double biggestRange = new[] { xRange, yRange, zRange }.Max();

			if (biggestRange >= spinningThreshold)
			{
				return WasherState.Spinning;
			}

			if (biggestRange >= washingThreshold)
			{
				return WasherState.Washing;
			}

			return WasherState.Idle;
		}

		public DateTime? GetStartTime()
		{
			foreach (var d in Data)
			{
				if (GetState(d.Time).IsMoving)
				{
					return d.Time;
				}
			}

			return null;
		}

		public WasherDataSet GetSubSet(DateTime? startTime = null, DateTime? endTime = null)
		{
			if (startTime == null)
			{
				startTime = Data.First().Time;
			}

			if (endTime == null)
			{
				endTime = Data.Last().Time;
			}

			if (startTime > endTime)
			{
				throw new ArgumentException("start time must be before end time.");
			}

			return new WasherDataSet(GetDataForTime(startTime.Value, endTime.Value));
		}

		private IEnumerable<AxisReading> GetDataForTime(DateTime startTime, DateTime endTime)
		{
			return Data.Where(x => x.Time >= startTime && x.Time <= endTime);
		}

		private IEnumerable<AxisReading> GetDataOverTime(DateTime? endTime = null, int? overTimeMinutes = null)
		{
			if (endTime == null)
			{
				endTime = DateTime.UtcNow;
			}

			if (overTimeMinutes == null)
			{
				overTimeMinutes = timeSpanMinutes;
			}

			DateTime startTime = endTime.Value.AddMinutes(-overTimeMinutes.Value);

			return GetDataForTime(startTime, endTime.Value);
		}
	}
}

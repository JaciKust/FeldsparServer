using System.Text.Json;

namespace Communication.DataObject
{
	public class DataObjectTransmitterCode : DataObjectBase
	{
		public DataObjectTransmitterCode(
			string code,
			double oneHighTime,
			double oneLowTime,
			double zeroHighTime,
			double zeroLowTime,
			double intervalTime
		) : base(nameof(DataObjectTransmitterCode), DataTopic.Transmitter443)
		{
			Code = code;

			OneHighTime = oneHighTime;
			OneLowTime = oneLowTime;
			ZeroHighTime = zeroHighTime;
			ZeroLowTime = zeroLowTime;
			IntervalTime = intervalTime;
		}

		public string Code { get; }

		public double OneHighTime { get; }
		public double OneLowTime { get; }
		public double ZeroHighTime { get; }
		public double ZeroLowTime { get; }
		public double IntervalTime { get; }
		public override string ToJsonString()
		{
			return JsonSerializer.Serialize(this);
		}
	}
}

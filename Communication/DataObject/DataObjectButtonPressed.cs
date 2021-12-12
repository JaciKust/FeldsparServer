using System.Text.Json;

namespace Communication.DataObject
{
	public class DataObjectButtonPressed : DataObjectBase
	{
		public DataObjectButtonPressed(
			string buttonName,
			string group,
			string category,
			int triggerPin,
			double buttonPressTime
		) : base(nameof(DataObjectButtonPressed), DataTopic.ButtonPress)
		{
			ButtonName = buttonName;
			Group = group;
			Category = category;
			TriggerPin = triggerPin;
			ButtonPressTime = buttonPressTime;
		}

		public string ButtonName { get; }
		public string Group { get; }
		public string Category { get; }
		public int TriggerPin { get; }
		public double ButtonPressTime { get; }

		public override string ToJsonString()
		{
			return JsonSerializer.Serialize(this);
		}
	}
}

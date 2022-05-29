using System.Text.Json;

namespace Communication.DataObject
{
	public class DataObjectButtonPressed : DataObjectBase
	{
		public DataObjectButtonPressed(
			string buttonName,
			string category,
			int triggerPin,
			double buttonPressTime,
			string controlPanelName
		) : base(nameof(DataObjectButtonPressed), DataTopic.ButtonPress)
		{
			ButtonName = buttonName;
			Category = category;
			TriggerPin = triggerPin;
			ButtonPressTime = buttonPressTime;
			ControlPanelName = controlPanelName;
		}

		public string ButtonName { get; }
		public string Category { get; }
		public int TriggerPin { get; }
		public double ButtonPressTime { get; }

		public string ControlPanelName { get; }

		public double GetPressTime()
		{
			if (ButtonPressTime > ButtonTime.Long)
			{
				return ButtonTime.Long;
			}
			else if (ButtonPressTime > ButtonTime.Medium)
			{
				return ButtonTime.Medium;
			}
			else
			{
				return ButtonTime.Short;
			}
		}

		public override string ToJsonString()
		{
			return JsonSerializer.Serialize(this);
		}
	}

	public static class ButtonTime
	{
		public static double Short { get; } = 0;
		public static double Medium { get; } = 0.5;
		public static double Long { get; } = 2;
	}

	public static class ButtonGroup
	{
		public static string Primary { get; } = nameof(Primary);
		public static string Accessory { get; } = nameof(Accessory);
		public static string Special { get; } = nameof(Special);
	}

	public static class ButtonControlPanel
	{
		public static string Desk { get; } = nameof(Desk);
		public static string Door { get; } = nameof(Door);
		public static string BlackBedside { get; } = nameof(BlackBedside);
	}
}

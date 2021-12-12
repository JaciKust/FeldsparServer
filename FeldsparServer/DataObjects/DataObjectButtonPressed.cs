using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace FeldsparServer.DataObjects
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

		public string ButtonName { get; set; }
		public string Group { get; set; }
		public string Category { get; set; }
		public int TriggerPin { get; set; }
		public double ButtonPressTime { get; set; }

		public override string ToJson()
		{
			return JsonSerializer.Serialize(this);
		}
	}
}

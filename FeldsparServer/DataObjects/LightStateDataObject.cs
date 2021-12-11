using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace FeldsparServer.DataObjects
{
	public class LightStateDataObject : BaseDataObject
	{
		public LightStateDataObject(
			string[] lightIpAddresses, 
			string[] lightMacAddresses,
			int[] rgbColor, 
			double transitionTimeSeconds
		) : base(nameof(LightStateDataObject), DataObjectTopic.LifxCommand)
		{
			LightIpAddresses = lightIpAddresses;
			LightMacAddresses = lightMacAddresses;
			RgbColor = rgbColor;
			TransitionTimeSeconds = transitionTimeSeconds;
		}

		public string[] LightIpAddresses { get; set; }
		public string[] LightMacAddresses { get; set; }

		public int[] RgbColor { get; set; }
		public double TransitionTimeSeconds { get; set; }

		public override string ToJson()
		{
			return JsonSerializer.Serialize(this);
		}
	}
}

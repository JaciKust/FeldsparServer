using System.Text.Json;

namespace FeldsparServer.DataObjects
{
	public class PanelStateDataObject : BaseDataObject
	{
		public PanelStateDataObject(string state) : base(nameof(PanelStateDataObject), DataObjectTopic.ControlPanelState)
		{
			State = state;
		}

		public string State { get; set; }

		public override string ToJson()
		{
			return JsonSerializer.Serialize(this);
		}
	}
}

using System.Text.Json;

namespace FeldsparServer.DataObjects
{
	public class PanelStateDataObject : DataObjectBase
	{
		public PanelStateDataObject(string state) : base(nameof(PanelStateDataObject), DataTopic.ControlPanelState)
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
